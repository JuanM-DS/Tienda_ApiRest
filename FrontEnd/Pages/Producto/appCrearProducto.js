import { ValidarProducto } from '../../Utilidades/ValidacionesProductos.js';
import { InsertarProducto } from '../../Api/appProducto.js';

const formulario = document.getElementById('formulario');
const selectCategorias = document.getElementById('selectCategoria');
const alerta = document.getElementById('alerta');

if (formulario) {
    formulario.addEventListener('submit', async function(e) {
        e.preventDefault();
        const datos = new FormData(formulario);

        // Convertir FormData a un objeto JavaScript
        const datosObjeto = {};
        for (const [key, value] of datos.entries()) {
            datosObjeto[key] = value;
        }

        // Validar los datos
        const { nombre, precio, unidades, categoria } = datosObjeto;
        const errores = ValidarProducto(nombre, precio, unidades, categoria);

        if (errores.length > 0) {
            const alertaHTML = errores.map(error => `<p>${error}</p>`).join('');
            alerta.innerHTML = `<div class="alert alert-danger" role="alert">${alertaHTML}</div>`;
            return;
        }

        // Insertar el producto utilizando la API
        try {
            const respuesta = await InsertarProducto(JSON.stringify(datosObjeto));
            if (respuesta.estado != 201) {
                alerta.innerHTML = `<div class="alert alert-danger" role="alert"><p>${respuesta.mensaje}</p></div>`;
            } else {
                alerta.innerHTML = `<div class="alert alert-primary" role="alert"><p>${respuesta.mensaje}</p></div>`;
            }
        } catch (error) {
            console.log('Error al insertar el producto:', error);
            alerta.innerHTML = `<div class="alert alert-danger" role="alert"><p>Error al insertar el producto</p></div>`;
        }
    });
}



import {ObjetenerCategorias} from '../../Api/appCategoria.js';
let categorias = await ObjetenerCategorias();
if(categorias != null){
    selectCategorias.innerHTML += categorias;
} 