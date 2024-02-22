import { ValidarProducto } from '../../../Utilidades/ValidacionesProductos.js';
import { InsertarProducto } from '../../../Api/appProducto.js';
import {ObjetenerCategorias} from '../../../Api/appCategoria.js';

const formulario = document.getElementById('formulario');
const selectCategorias = document.getElementById('selectCategoria');
const alerta = document.getElementById('alerta');

/*Obtener las categorias que nos proporciona la API*/
let listaCategorias = await ObjetenerCategorias(); 
if (listaCategorias != null) {
    let categorias = '';
    listaCategorias.forEach(item => {
        categorias += `<option value="${item.id}">${item.nombre}</option>`;
    });
    selectCategorias.innerHTML += categorias; 
}
/*Evento que obtiene los datos del formulario y los procesa*/
if (formulario) {
    formulario.addEventListener('submit', async function(e) {
        e.preventDefault();
        const datos = new FormData(formulario);

         // Convertir FormData a un objeto JavaScript
         const datosObjeto = {};
         for (const [key, value] of datos.entries()) {
             datosObjeto[key] = key === 'IdCategoria' ? selectCategorias.value : value;
         }

        // Validar los datos
        const { nombre, precio, unidades, IdCategoria } = datosObjeto;
        const errores = ValidarProducto(nombre, precio, unidades, IdCategoria);
        if (errores.length > 0) {
            const alertaHTML = errores.map(error => `<p>${error}</p>`).join('');
            alerta.innerHTML = `<div class="alert alert-danger" role="alert">${alertaHTML}</div>`;
            return;
        }
        console.log(datosObjeto.Categorias)
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



 