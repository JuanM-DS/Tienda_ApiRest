import { ValidarCategoria } from '../../../Utilidades//ValidacionesCategoria.js';
import { InsertarCategoria } from '../../../Api/appCategoria.js';

const formulario = document.getElementById('formulario');

/*Evento que obtiene los datos del formulario y los procesa*/
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
        const { nombre, descripcion} = datosObjeto;
        const errores = ValidarCategoria(nombre, descripcion);
        if (errores.length > 0) {
            const alertaHTML = errores.map(error => `<p>${error}</p>`).join('');
            alerta.innerHTML = `<div class="alert alert-danger" role="alert">${alertaHTML}</div>`;
            return;
        }
        // Insertar categoria utilizando la API
        try {
            const respuesta = await InsertarCategoria(JSON.stringify(datosObjeto));
            if (respuesta.estado != 201) {
                alerta.innerHTML = `<div class="alert alert-danger" role="alert"><p>${respuesta.mensaje}</p></div>`;
            } else {
                alerta.innerHTML = `<div class="alert alert-primary" role="alert"><p>${respuesta.mensaje}</p></div>`;
            }
        } catch (error) {
            console.log('Error al insertar la categoria:', error);
            alerta.innerHTML = `<div class="alert alert-danger" role="alert"><p>Error al insertar el producto</p></div>`;
        }
    });
}



 