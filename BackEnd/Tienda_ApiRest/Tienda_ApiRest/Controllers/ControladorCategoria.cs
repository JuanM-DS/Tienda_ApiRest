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
	public class ControladorCategoria : Controller , IControladores<Categoria>
	{
		private readonly IRepositorio<Categoria> _Repo;

		public ControladorCategoria(IRepositorio<Categoria> Repo)
		{
			_Repo = Repo;
		}

		public Task<ActionResult<RespuestaDto>> Actualizar(Categoria modelo)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<RespuestaDto>> Eliminar(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<RespuestaDto>> Insertar([FromBody] Categoria modelo)
		{
			throw new NotImplementedException();
		}

		/*EndPont para listar las categorias*/
		[HttpGet]
		[Route("Listar")]
		public async Task<ActionResult<RespuestaDto>> Listar()
		{
			var lista = await _Repo.Listar();

			return (lista != null) ? Ok(RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.Ok, lista)) 
									: StatusCode(500, RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.InternalServerError, lista));
		}

		/*EndPoint para buscar la categoria por id*/
		[HttpGet]
		[Route("PorId")]
		public async Task<ActionResult<RespuestaDto>> PorId(int id)
		{
			var respuesta  = await _Repo.BuscarPorId(id);
			return (respuesta != null) ? Ok(RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.Ok, respuesta))
										: StatusCode(500, RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.InternalServerError, respuesta));
		}
	}

}
