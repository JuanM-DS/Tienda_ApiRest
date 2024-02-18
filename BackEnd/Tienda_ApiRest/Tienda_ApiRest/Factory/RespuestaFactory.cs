using Tienda_ApiRest.Compartir;
using Tienda_ApiRest.Tipos;

namespace Tienda_ApiRest.Factory
{
	/*Clase la cual se encarga de crear las diferentes respuestas que se van a enviar al cliente*/

	public class RespuestaFactory
	{
		private static Respuesta? _respuesta;

		/*Dependiendo del tipo de respespuesta http que le pasemos, este creara una respuesta*/
		public static Respuesta CrearRespuesta(TipoRespuestaHttp tipo, dynamic entidad, string mensaje = "BadRequest")
		{
			switch(tipo)
			{
				case TipoRespuestaHttp.Ok:
					_respuesta = new Respuesta() {
						Estado = TipoRespuestaHttp.Ok,
						Mensaje = "Lista Encontrada y devuelta Correctamente",
						Entidad = entidad
					};
					return _respuesta;

				case TipoRespuestaHttp.Created:
					_respuesta = new Respuesta()
					{
						Estado = TipoRespuestaHttp.Created,
						Mensaje = "Entidad creada correctamente",
						Entidad = entidad
					};
					return _respuesta;

				case TipoRespuestaHttp.NotFound:
					_respuesta = new Respuesta()
					{
						Estado = TipoRespuestaHttp.NotFound,
						Mensaje = "Entidad no encontrada",
						Entidad = entidad
					};
					return _respuesta;

				case TipoRespuestaHttp.InternalServerError:
					_respuesta = new Respuesta()
					{
						Estado = TipoRespuestaHttp.InternalServerError,
						Mensaje = "Error interno del servidor",
						Entidad = entidad
					};
					return _respuesta;

				case TipoRespuestaHttp.BadRequest:
					_respuesta = new Respuesta()
					{
						Estado = TipoRespuestaHttp.BadRequest,
						Mensaje = mensaje,
						Entidad = entidad
					};
					return _respuesta;
				default:
					return null;
			}
		}
	}
}
