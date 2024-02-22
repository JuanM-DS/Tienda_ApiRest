/*------------------------------------ Api------------------------------------------------*/

/*Metodo para consumir con la api mediante un get, y obtener las categorias*/
export const ObjetenerCategorias = async () => {
    const url = "https://localhost:7017/Api/Categoria/Listar"
   try{
        const respuesta = await fetch(url);
        const datos = await respuesta.json();
        if(datos.estado === 200){
            const lista = datos.entidad;
            return lista;
        }
        else{
           return null;
        }
   }
   catch(ex){
        console.log(ex);
        return null;
   }
}

 
/*Metodo para obtener categoria por id*/
export const ObtenerCategoriaPorId = async (id) => {
     if(id != null || id === 0){
          const url = `https://localhost:7017/Api/Categoria/PorId?id=${id}`
          let respuesta  = await fetch(url);
          let datos = await respuesta.json();
          if(datos.estado === 200){
               return datos.entidad;
          }
     }
     return null;
}

/*Insertar Categoria */
export const InsertarCategoria = async (datosAEnviar) => {
     try {
         const url = 'https://localhost:7017/Api/Categoria/Insertar';
         const respuesta = await fetch(url, {
             method: 'POST',
             body: datosAEnviar,
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

 /*Actualizar categoria */
 export const EditarCategoria = async (producto) =>{
    try{
        const url = 'https://localhost:7017/Api/Categoria/Actualizar'
        const respuesta  = await fetch(url, {
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