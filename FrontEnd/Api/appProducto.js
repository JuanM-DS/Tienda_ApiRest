export const InsertarProducto = async (datosAEnviar) => {
    try {
        const url = 'https://localhost:7017/Api/Productos/Insertar';
        const respuesta = await fetch(url, {
            method: 'POST',
            body: datosAEnviar, // Convertir datos a JSON
            headers: {
                'Content-Type': 'application/json' // Configurar el tipo de contenido como JSON
            }
        });
        const datosRespuesta = await respuesta.json();
        return datosRespuesta;
    } catch (ex) {
        console.log(ex);
        return null;
    }
}
