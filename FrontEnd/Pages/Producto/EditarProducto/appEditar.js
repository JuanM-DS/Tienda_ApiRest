import {ObtenerProductoPorId} from '../../../Api/appProducto.js'
import {ObtenerCategoriaPorId} from '../../../Api/appCategoria.js'
import {ObjetenerCategorias} from '../../../Api/appCategoria.js'
import {EditarProducto} from '../../../Api/appProducto.js'
import {ValidarProducto} from '../../../Utilidades/ValidacionesProductos.js'

const UrlParametros = new URLSearchParams(window.location.search);
const id = UrlParametros.get('id');
const inputNombre = document.getElementById('nombre');
const inputPrecio = document.getElementById('precio');
const inputUnidades = document.getElementById('unidades');
const selectCategorias = document.getElementById('selectCategoria');
const formulario = document.getElementById('formulario');
const alerta = document.getElementById('alerta');

/*Metodo para optener los elementos pertenecientes al id enviado */

const producto = await ObtenerProductoPorId(id);
const categoria = await ObtenerCategoriaPorId(producto.idCategoria);
const listaCategorias = await ObjetenerCategorias();

/*Ingresando los datos */
if(categoria!=null){

    if (listaCategorias != null) {
        let categorias = '';
        let cont = 1;
        listaCategorias.forEach(item => {
            categorias += `<option value="${cont}">${item.nombre}</option>`;
            cont++; 
        });
        selectCategorias.innerHTML += categorias;
    }
    inputNombre.value = producto.nombre;
    inputUnidades.value = producto.unidades;
    inputPrecio.value = producto.precio;
    selectCategorias.value = categoria.id
}

/* Editando */
if (formulario) {
    formulario.addEventListener('submit', async function(e) {
        e.preventDefault();
        const datos = new FormData(formulario);

         // Convertir FormData a un objeto JavaScript
         const datosObjeto = {};
         for (const [key, value] of datos.entries()) {
             datosObjeto[key] = key === 'IdCategoria' ? selectCategorias.value : value;
         }
         datosObjeto['Id'] = id;

        // Validar los datos
        const { nombre, precio, unidades, IdCategoria } = datosObjeto;
        console.log(datosObjeto.IdCategoria)

        const errores = ValidarProducto(nombre, precio, unidades, IdCategoria);
        if (errores.length > 0) {
            const alertaHTML = errores.map(error => `<p>${error}</p>`).join('');
            alerta.innerHTML = `<div class="alert alert-danger" role="alert">${alertaHTML}</div>`;
            return;
        }
        // Insertar el producto utilizando la API
        try {
            const respuesta = await EditarProducto(JSON.stringify(datosObjeto));
            if (respuesta.estado != 201) {
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