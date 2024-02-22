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
                <a href="../EditarProducto/EditarProducto.html?id=${ListaProductos[item].id}" class="btn btn-primary btn-sm" id="btnEditar">Editar</a>
                <a href="../EliminarProducto/EliminarProducto.html?id=${ListaProductos[item].id}" class="btn btn-danger btn-sm" id="btnEditar">Eliminar</a>
            </td>
        </tr>
        `
    }
    tbody.innerHTML = filas;
}
