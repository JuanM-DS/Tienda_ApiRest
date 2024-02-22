using Microsoft.AspNetCore.Mvc;
using Tienda_ApiRest.Compartir;
using Tienda_ApiRest.Factory;
using Tienda_ApiRest.Modelos;
using Tienda_ApiRest.Servicios;
using Tienda_ApiRest.Tipos;
using Tienda_ApiRest.Validaciones;

namespace Tienda_ApiRest.Controllers
{

	[ApiController]
	[Route("Api/Productos")]
	public class ControladorProductos : Controller, IControladores<Producto>
	{
		private RespuestaDto _Respuesta;
		private readonly ValidarProducto _Validaciones;
		private readonly IRepositorio<Producto> _Repo;
		public ControladorProductos(IRepositorio<Producto> repo, RespuestaDto respuesta, ValidarProducto validaciones)
		{
			_Repo = repo;
			_Respuesta = respuesta;
			_Validaciones = validaciones;
		}

		/*Metodo para insertar los productos*/
		[HttpPost]
		[Route("Insertar")]
		public async Task<ActionResult<RespuestaDto>> Insertar([FromBody] Producto modelo)
		{
			var valido = _Validaciones.Validate(modelo);

			if (!valido.IsValid)
			{
				string errores = String.Empty;
				foreach (var item in valido.Errors)
				{
					errores += $"\n Propiedad : {item.PropertyName} fallo con el error: {item.ErrorMessage}";
				}

				_Respuesta = RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.BadRequest, modelo, errores);
			}
			else if (await _Repo.Insertar(modelo))
			{
				_Respuesta = RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.Created, modelo);
			}
			else
			{
				_Respuesta = RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.InternalServerError, modelo);
			}

			return _Respuesta;
		}

		/*Metodo par Listar los productos*/
		[HttpGet]
		[Route("Listar")]
		public async Task<ActionResult<RespuestaDto>> Listar()
		{
			var lista = await _Repo.Listar();
			return (lista != null) ? Ok(RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.Ok, lista)) : StatusCode(500, RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.InternalServerError, lista));
		}

		[HttpGet]
		[Route("PorId")]
		public async Task<ActionResult<RespuestaDto>> PorId(int id)
		{
			var producto = await _Repo.BuscarPorId(id);
			return (producto != null) ? Ok(RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.Ok, producto)) : StatusCode(500, RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.InternalServerError, producto));
		}

		[HttpPut]
		[Route("Actualizar")]
		public async Task<ActionResult<RespuestaDto>> Actualizar([FromBody]Producto modelo)
		{
			var valido = _Validaciones.Validate(modelo);
			if (!valido.IsValid)
			{
				string errores = String.Empty;
				foreach (var item in valido.Errors)
				{
					errores += $"\n Propiedad : {item.PropertyName} fallo con el error: {item.ErrorMessage}";
				}

				_Respuesta = RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.BadRequest, modelo, errores);
			}
			else if (await _Repo.Actualizar(modelo))
			{
				_Respuesta = RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.Ok, modelo);
			}
			else
			{
				_Respuesta = RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.InternalServerError, modelo);
			}

			return _Respuesta;
		}

		[HttpDelete]
		[Route("Eliminar")]
		public async Task<ActionResult<RespuestaDto>> Eliminar(int id)
		{
			var producto = await _Repo.Eliminar(id);
			return (producto == true) ? Ok(RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.Ok, producto)) : StatusCode(500, RespuestaFactory.CrearRespuesta(TipoRespuestaHttp.InternalServerError, producto));
		}
	}
}
