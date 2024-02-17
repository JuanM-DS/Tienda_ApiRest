using Tienda_ApiRest.Compartir;
using Tienda_ApiRest.Tipos;

namespace Tienda_ApiRest.Factory
{
	public class RespuestaFactory
	{
		private static Respuesta? _respuesta;

		public static Respuesta CrearRespuesta(TipoRespuestaHttp tipo, dynamic entidad)
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
				default:
					return null;
			}
		}
	}
}
