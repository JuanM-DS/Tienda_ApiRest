/*------------------------------------ Api------------------------------------------------*/

/*Metodo para consumir con la api mediante un get, y obtener las categorias*/
export const ObjetenerCategorias = async () => {
    const url = "https://localhost:7017/Api/Categoria/Listar"
   try{
        const respuesta = await fetch(url);
        const datos = await respuesta.json();
        if(datos.estado === 200){
            const lista = datos.entidad;
            let catgeorias = ''; 
            let cont = 1;
            lista.forEach(item => {
                catgeorias += `<option value="${cont}">${item.nombre}</option>`;
                cont++;
            });
            return catgeorias;
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

 