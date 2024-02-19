
export const ValidarProducto = (nombre, precio, unidades, categoria) => {
    const errores = [];

    if (!nombre || !/^[a-zA-Z]+$/.test(nombre)) {
        errores.push("Campo nombre no válido");
    }
    if (!precio || !/^[0-9]+$/.test(precio)) {
        errores.push("Campo precio no válido");
    }
    if (!unidades || !/^[0-9]+$/.test(unidades)) {
        errores.push("Campo unidades no válido");
    }
    if (categoria === "Selecciona categoria") {
        errores.push("Campo categorías no válido");
    }

    return errores;
}
