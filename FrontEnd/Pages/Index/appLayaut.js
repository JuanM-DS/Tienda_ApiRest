// Resto de tu código...
const btnInicio = document.getElementById('btnInicio');
const btnProducto = document.getElementById('btnProducto');
const btnCategoria = document.getElementById('btnCategoria');
const contenido = document.getElementById('contenido');
const alertas = document.getElementById('alertas');

/*Metodo para redireccionar a la pagina de inicio*/
btnInicio.addEventListener('click', async () => {
});

btnProducto.addEventListener('click', async () => {
    try {
        let res = await fetch('../Producto/ListarProductos/Listar.html');
        let html = await res.text();
        contenido.innerHTML = html;

        // Importar y ejecutar el JavaScript asociado al HTML
        const script = document.createElement('script');
        script.src = '../Producto/ListarProductos/appListar.js'; // Ajusta la ruta según sea necesario
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
});


