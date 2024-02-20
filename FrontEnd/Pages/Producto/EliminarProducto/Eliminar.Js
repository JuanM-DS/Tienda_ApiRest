import {ObtenerProductoPorId, EliminarProducto} from '../../../Api/appProducto.js'

const parametro = new URLSearchParams(window.location.search);
const id = parametro.get('id');
const inputNombre = document.getElementById('nombreProducto');
const btnEliminar = document.getElementById('btnEliminar');
const alerta = document.getElementById('alerta');



const producto =  await ObtenerProductoPorId(id);
if(producto != null){
    inputNombre.innerHTML = `Seguro de que deceas Eliminar el producto : ${producto.nombre}`
}

btnEliminar.addEventListener('click', async ()=>{
    if(id!=null || id!=0){
        // Insertar el producto utilizando la API
        try {
            const respuesta = await EliminarProducto(id);
            if (respuesta.estado != 200) {
                alerta.innerHTML = `<div class="alert alert-danger" role="alert"><p>${respuesta.mensaje}</p></div>`;
            } else {
                alerta.innerHTML = `<div class="alert alert-primary" role="alert"><p>${respuesta.mensaje}</p></div>`;
            }
        } catch (error) {
            console.log('Error al insertar el producto:', error);
            alerta.innerHTML = `<div class="alert alert-danger" role="alert"><p>Error al eliminar el producto</p></div>`;
        }
        window.location.href = "../ListarProductos/Listar.html";

    }
})