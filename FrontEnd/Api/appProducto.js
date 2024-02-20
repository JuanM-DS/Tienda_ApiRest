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
    const url = 'https://localhost:7017/Api/Productos/Listar'
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

/*Obtener producto por Id */
export const ObtenerProductoPorId =  async (id) =>{
    if(id != null || id != 0){
        const url = `https://localhost:7017/Api/Productos/PorId?id=${id}`;
        const respuesta = await fetch(url);
        const datos = await respuesta.json();
        if(datos.estado === 200){
            return datos.entidad;
        }
    }
    return null;
} 

export const EditarProducto = async (producto) =>{
    try{
        const url = 'https://localhost:7017/Api/Productos/Actualizar'
        const respuesta  = fetch(url, {
            method: 'PUT',
            body: producto,
            headers: {
                'Content-Type': 'application/json' // Configurar el tipo de contenido como JSON
            }
        });
        const datos = await respuesta.json();
        return datos;
    }catch (ex) {
        console.log(ex);
        return null;
    }
}