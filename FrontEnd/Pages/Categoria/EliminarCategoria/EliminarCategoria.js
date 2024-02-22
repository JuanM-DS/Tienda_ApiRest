import {ObtenerCategoriaPorId, EliminarCategoria} from '../../../Api/appCategoria.js'

const parametro = new URLSearchParams(window.location.search);
const id = parametro.get('id');
const inputNombre = document.getElementById('nombreCategoria');
const btnEliminar = document.getElementById('btnEliminar');
const alerta = document.getElementById('alerta');



const Categoria =  await ObtenerCategoriaPorId(id);
if(Categoria != null){
    inputNombre.innerHTML = `Seguro de que deceas Eliminar la categoria : ${Categoria.nombre}`
}

btnEliminar.addEventListener('click', async ()=>{
    if(id!=null || id!=0){
        // Insertar el producto utilizando la API
        try {
            const respuesta = await EliminarCategoria(id);
            if (respuesta.estado != 200) {
                alerta.innerHTML = `<div class="alert alert-danger" role="alert"><p>${respuesta.mensaje}</p></div>`;
            } else {
                alerta.innerHTML = `<div class="alert alert-primary" role="alert"><p>${respuesta.mensaje}</p></div>`;
            }
        } catch (error) {
            alerta.innerHTML = `<div class="alert alert-danger" role="alert"><p>Error al eliminar la categoria</p></div>`;
        }
        window.location.href = "../ListarCategoria/Listarcategoria.html";

    }
})