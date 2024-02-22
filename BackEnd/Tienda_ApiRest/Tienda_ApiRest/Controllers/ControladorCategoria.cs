using FluentValidation;
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
	[Route("Api/Categoria")]
	public class ControladorCategoria : Controller , IControladores<Categoria>
	{
		private readonly IRepositorio<Categoria> _Repo;
        private RespuestaDto _Respuesta;
        private readonly ValidarCategoria _Validaciones;

        public ControladorCategoria(IRepositorio<Categoria> Repo, RespuestaDto respuesta, ValidarCategoria validaciones)
		{
			_Repo = Repo;
            _Respuesta = respuesta;
            _Validaciones = validaciones;
        }

        [HttpPut]
        [Route("Actualizar")]
        public async Task<ActionResult<RespuestaDto>> Actualizar([FromBody] Categoria modelo)
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

        public Task<ActionResult<RespuestaDto>> Eliminar(int id)
		{
			throw new NotImplementedException();
		}

        [HttpPost]
        [Route("Insertar")]
        public async Task<ActionResult<RespuestaDto>> Insertar([FromBody] Categoria modelo)
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
