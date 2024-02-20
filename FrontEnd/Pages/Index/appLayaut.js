import { ObtenerListaProductos } from "../../Api/appProducto.js";
import { ObtenerCategoriaPorId } from "../../Api/appCategoria.js";
import {ScripListar} from "../Producto/ListarProductos/appListar.js"
import { ValidarProducto } from '../../Utilidades/ValidacionesProductos.js';
import { InsertarProducto } from '../../Api/appProducto.js';
import {ObjetenerCategorias} from '../../Api/appCategoria.js';
import {ScripCrearProductp} from '../Producto/CrearProducto/appCrearProducto.js';



const btnInicio = document.getElementById('btnInicio');
const btnProducto = document.getElementById('btnProducto');
const btnCategoria = document.getElementById('btnCategoria');
const contenido = document.getElementById('contenido');
const alertas = document.getElementById('alertas');
const btnCrearNuevo = null;
/*Metodo para redireccionar a la pagina de inicio*/
btnInicio.addEventListener('click', async () => {
});

btnProducto.addEventListener('click', async () => {
    try {
        let res = await fetch('../Producto/ListarProductos/Listar.html');
        let html = await res.text();
        contenido.innerHTML = html;
        ScripListar(ObtenerListaProductos, ObtenerCategoriaPorId);
        
        /*Configurando boton crear producto*/
        btnCrearNuevo = document.getElementById('btnCrearNuevo');
    } catch (Ex) {
        console.log(Ex);
    }
});



/*Metodo para crear llamar al formulario de crear producto*/
btnCrearNuevo.addEventListener('click', async ()=>{
    try{
        let datos = await fetch('../Producto/CrearProducto/CrearProducto.html');
        let html = await datos.text();
        contenido.innerHTML = html;

        ScripCrearProductp(ValidarProducto, InsertarProducto, ObjetenerCategorias)
         
     } catch (Ex) {
         console.log(Ex);
     }
})


/*------------------------------------------------------- */
