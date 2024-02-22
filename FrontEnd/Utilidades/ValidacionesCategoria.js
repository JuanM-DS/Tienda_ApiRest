
/*Metodod para validar los campos que recolecto el formulario*/
export const ValidarCategoria = (nombre, descripcion) => {
    const errores = [];

    if (!nombre || !/^[a-zA-Z]+$/.test(nombre)) {
        errores.push("Campo nombre no válido");
    }
    if(descripcion == null){
        errores.push("Campo descripcion no válido");
    }

    return errores;
}
