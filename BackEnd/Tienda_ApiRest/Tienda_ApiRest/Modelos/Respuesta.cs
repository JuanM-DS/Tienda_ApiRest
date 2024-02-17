namespace Tienda_ApiRest.Modelos
{
	public class Respuesta
	{
		public TipoRespuestaHttp Estado{ get; set; }
		public string? Mensaje { get; set; }
		public Modelo? Entidad { get; set; }
	}
}
