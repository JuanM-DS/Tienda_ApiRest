import { ObtenerListaProductos } from "../../../Api/appProducto.js";
import { ObtenerCategoriaPorId } from "../../../Api/appCategoria.js";

const tbody = document.getElementById('tbody');

let ListaProductos = await ObtenerListaProductos();
if(ListaProductos != null){
    let filas = ''
    for(let item in ListaProductos){
        let itemCategoria = await ObtenerCategoriaPorId(ListaProductos[item].idCategoria);
        filas += `
        <tr>
            <td>${ListaProductos[item].nombre}</td>
            <td>${ListaProductos[item].precio}</td>
            <td>${ListaProductos[item].unidades}</td>
            <td>${itemCategoria.nombre}</td>
            <td>
                <a class="btn btn-primary btn-sm" id="btnEditar">Editar</a>
                <a class="btn btn-danger btn-sm" id="btnEditar">Eliminar</a>
            </td>
        </tr>
        `
    }
    tbody.innerHTML = filas;
}

console.log("listar")

/*Configurando los botones de listar*/
const btneditar = document.getElementById('btnEditar');
const contenido = document.getElementById('contenido');
const btnCrearNuevo = document.getElementById('btnCrearNuevo');

/*Metodo para crear llamar al formulario de crear producto*/
btnCrearNuevo.addEventListener('click', async ()=>{
    try{
        let datos = await fetch('../Producto/CrearProducto/CrearProducto.html');
        let html = await datos.text();
        contenido.innerHTML = html;

         // Importar y ejecutar el JavaScript asociado al HTML
         const script = document.createElement('script');
         script.src = '../Producto/CrearProducto/CrearProducto.js';
         script.type = 'module';
         script.onload = () => {
             console.log('Script cargado exitosamente');
         };
         script.onerror = (error) => {
             console.error('Error al cargar el script:', error);
         };
         document.body.appendChild(script);
     } catch (Ex) {
         console.log(Ex);
     }
})
