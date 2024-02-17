using Microsoft.AspNetCore.Mvc;
using Tienda_ApiRest.Compartir;
using Tienda_ApiRest.Factory;
using Tienda_ApiRest.Modelos;
using Tienda_ApiRest.Servicios;
using Tienda_ApiRest.Tipos;

namespace Tienda_ApiRest.Controllers
{
    [ApiController]
	[Route("Api/Categoria")]
	public class ControladorCategoria : Controller
	{
		private readonly IRepositorio<Categoria> _Repo;
		private Respuesta _Respuesta { get; set; }

		public ControladorCategoria(IRepositorio<Categoria> Repo, Respuesta respuesta)
		{
			_Repo = Repo;
			_Respuesta = respuesta;
		}

		[HttpGet]
		[Route("Listar")]
		public async Task<ActionResult<Respuesta>> Listar()
		{
			var lista = await _Repo.Listar();

			return (lista != null) ? Ok(RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.Ok, lista)) 
									: StatusCode(500, RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.InternalServerError, lista));
		}
	}
}
