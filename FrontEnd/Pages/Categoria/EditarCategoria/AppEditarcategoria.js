import {ObtenerCategoriaPorId} from '../../../Api/appCategoria.js'
import { ValidarCategoria } from '../../../Utilidades//ValidacionesCategoria.js';
import {EditarCategoria} from '../../../Api/appCategoria.js'

const UrlParametros = new URLSearchParams(window.location.search);
const id = UrlParametros.get('id');
const inputNombre = document.getElementById('nombre');
const inputdescripcion = document.getElementById('descripcion');
const formulario = document.getElementById('formulario');
const alerta = document.getElementById('alerta');

/*Metodo para optener los elementos pertenecientes al id enviado */
const categoria = await ObtenerCategoriaPorId(id);

/*Ingresando los datos */
if(categoria!=null){

    inputNombre.value = categoria.nombre;
    inputdescripcion.value = categoria.descripcion;
}

/* Editando */
if (formulario) {
    formulario.addEventListener('submit', async function(e) {
        e.preventDefault();
        const datos = new FormData(formulario);

         // Convertir FormData a un objeto JavaScript
         const datosObjeto = {};
         for (const [key, value] of datos.entries()) {
             datosObjeto[key] = value;
         }
         datosObjeto['id'] = id
        // Validar los datos
        const { nombre, descripcion} = datosObjeto;
        const errores = ValidarCategoria(nombre, descripcion);
        if (errores.length > 0) {
            const alertaHTML = errores.map(error => `<p>${error}</p>`).join('');
            alerta.innerHTML = `<div class="alert alert-danger" role="alert">${alertaHTML}</div>`;
            return;
        }
        // Insertar el producto utilizando la API
        try {
            const respuesta = await EditarCategoria(JSON.stringify(datosObjeto));
            if (respuesta.estado != 200) {
                alerta.innerHTML = `<div class="alert alert-danger" role="alert"><p>${respuesta.mensaje}</p></div>`;
            } else {
                alerta.innerHTML = `<div class="alert alert-primary" role="alert"><p>${respuesta.mensaje}</p></div>`;
            }
        } catch (error) {
            console.log('Error al insertar el producto:', error);
            alerta.innerHTML = `<div class="alert alert-danger" role="alert"><p>Error al actualizar el producto</p></div>`;
        }
    });
}