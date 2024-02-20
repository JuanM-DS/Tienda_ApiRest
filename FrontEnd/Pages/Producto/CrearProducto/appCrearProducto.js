import { ValidarProducto } from '../../../Utilidades/ValidacionesProductos.js';
import { InsertarProducto } from '../../../Api/appProducto.js';
import {ObjetenerCategorias} from '../../../Api/appCategoria.js';

const formulario = document.getElementById('formulario');
const selectCategorias = document.getElementById('selectCategoria');
const alerta = document.getElementById('alerta');

/*Evento que obtiene los datos del formulario y los procesa*/
if (formulario) {
    formulario.addEventListener('submit', async function(e) {
        e.preventDefault();
        const datos = new FormData(formulario);
        // Validar los datos
        const errores = ValidarProducto(datos.get('nombre'), datos.get('precio'), datos.get('unidades'), datos.get('Categorias'));

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


/*Obtener las categorias que nos proporciona la API*/
let listaCategorias = await ObjetenerCategorias(); 
if (listaCategorias != null) {
    let categorias = '';
    let cont = 1;
    listaCategorias.forEach(item => {
        categorias += `<option value="${cont}">${item.nombre}</option>`;
        cont++;
    });
    selectCategorias.innerHTML += categorias; 
}
 