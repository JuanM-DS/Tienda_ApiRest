using Tienda_ApiRest.Modelos;
using Tienda_ApiRest.Tipos;

namespace Tienda_ApiRest.Compartir
{
    /*Clase encargada de devolver respuestas*/
    public class Respuesta
    {
        public TipoRespuestaHttp Estado { get; set; }
        public string? Mensaje { get; set; }
        public dynamic? Entidad { get; set; }
    }
}
