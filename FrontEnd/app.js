const btnInicio = document.getElementById('btnInicio');
const btnProducto = document.getElementById('btnProducto');
const btnCategoria = document.getElementById('btnCategoria');
const contenido = document.getElementById('contenido');
const alertas = document.getElementById('alertas');


const ObjetenerCategorias = async () => {
    const url = "https://localhost:7017/Api/Categoria/Listar"
    const selectCategorias = document.getElementById('selectCategoria');
   try{
        const respuesta = await fetch(url);
        console.log(respuesta);
        const datos = await respuesta.json();
        if(datos.estado === 200){
            console.log(datos.estado);
            const lista = datos.entidad;
            let catgeorias = ''; 
            lista.forEach(item => {
                catgeorias += `<option value="1">${item.nombre}</option>`;
                
            });
            selectCategorias.innerHTML += catgeorias;
        }
        else{
            alert(datos.mensaje);
        }
   }
   catch(ex){
        console.log(ex)
   }
}

btnInicio.addEventListener('click', async () =>{
    try{
        let res = await fetch('Index.html');
        let html = await res.text();
        contenido.innerHTML = html;
    }
    catch(ex){
        console.log(ex)
    }
})

btnProducto.addEventListener('click', async () => {
   try{
        let res = await fetch('CrearProducto.html');
        let html = await res.text();
        contenido.innerHTML = html; 
        ObjetenerCategorias();
   }
   catch(Ex){
        console.log(Ex);
   }
});