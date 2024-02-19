/*Metodo para ingresar los productos a la base de datos*/
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


/*Metodo para obtener los productos*/
export const ObtenerListaProductos = async () => {
    const url = 'https://localhost:7017/Api/Producto/Listar'
    try{
        const respuesta = await fetch(url);
        const datos = await respuesta.json();
        if(datos.estado === 200){
            return datos.entidad;
        }
        else{
            return null; 
        }
    }
    catch(ex){
        console.log(ex)
        return null;
    }
}