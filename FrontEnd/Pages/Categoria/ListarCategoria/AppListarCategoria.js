import { ObjetenerCategorias } from "../../../Api/appCategoria.js";

const tbody = document.getElementById('tbody');

let ListaCategoria = await ObjetenerCategorias();
if(ListaCategoria != null){
    let filas = ''
    for(let item in ListaCategoria){
        filas += `
        <tr>
            <td>${ListaCategoria[item].nombre}</td>
            <td>${ListaCategoria[item].descripcion}</td>
            <td>
                <a href="../EditarCategoria/EditarCategoria.html?id=${ListaCategoria[item].id}" class="btn btn-primary btn-sm" id="btnEditar">Editar</a>
                <a href="../EliminarCategoria/Eliminar.html?id=${ListaCategoria[item].id}" class="btn btn-danger btn-sm" id="btnEditar">Eliminar</a>
            </td>
        </tr>
        `
    }
    tbody.innerHTML = filas;
}