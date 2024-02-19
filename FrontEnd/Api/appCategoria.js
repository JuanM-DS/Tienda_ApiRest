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
          const url = 'https://localhost:7017/Api/Categoria/PorId'
          let respuesta  = await fetch(url, {
               method: 'POST',
               body: id 
          });
          let datos = respuesta.json();
          if(datos.estado === 200){
               return datos.entidad;
          }
     }
     return null;
}