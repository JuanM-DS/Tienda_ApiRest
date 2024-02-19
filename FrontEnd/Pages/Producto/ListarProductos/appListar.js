import { ObtenerListaProductos } from "../../../Api/appProducto";
import {ObtenerCategoriaPorId} from "../../../Api/appCategoria";
const tbody = document.getElementById('tbody');

let ListaProductos = await ObtenerListaProductos();
if(ListaProductos != null){
    let filas = ''
    ListaProductos.array.forEach(async item => {
        let itemCategoria = await ObtenerCategoriaPorId(item.idCategoria);
        filas += `
        <tr>
            <td>${item.nombre}</td>
            <td>${item.precio}</td>
            <td>${item.unidades}</td>
            <td>${itemCategoria.nombre}</td>
            <td>
                <a class="btn btn-primary btn-sm">Editar</a>
                <a class="btn btn-danger btn-sm">Eliminar</a>
            </td>
        </tr>
        `
    });
    tbody.innerHTML = filas;
}