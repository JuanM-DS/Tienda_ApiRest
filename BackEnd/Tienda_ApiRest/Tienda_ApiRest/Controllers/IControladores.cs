using Microsoft.AspNetCore.Mvc;
using Tienda_ApiRest.Compartir;
using Tienda_ApiRest.Modelos;

namespace Tienda_ApiRest.Controllers
{
	/*Controlador para manejar los datos del los productos*/

	public interface IControladores<T>
	{
		public  Task<ActionResult<RespuestaDto>> Insertar([FromBody] T modelo);
		public  Task<ActionResult<RespuestaDto>> Listar();
		public Task<ActionResult<RespuestaDto>> PorId(int id);
		public Task<ActionResult<RespuestaDto>> Actualizar(T modelo);
		public Task<ActionResult<RespuestaDto>> Eliminar(int id);

	}
}
