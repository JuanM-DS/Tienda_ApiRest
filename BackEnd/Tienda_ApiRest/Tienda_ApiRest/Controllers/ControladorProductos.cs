using Microsoft.AspNetCore.Mvc;
using Tienda_ApiRest.Modelos;
using Tienda_ApiRest.Servicios;

namespace Tienda_ApiRest.Controllers
{
	/*Controlador para manejar los datos del los productos*/

	[ApiController]
	[Route("Api/Productos")]
	public class ControladorProductos : Controller
	{
		private Respuesta _Respuesta;
		private readonly IRepositorio<Producto> _Repo;
		public ControladorProductos(IRepositorio<Producto> repo, Respuesta respuesta)
		{
			_Repo = repo;
			_Respuesta = respuesta;
		}

		[HttpPost]
		[Route("Insertar")]
		public async Task<ActionResult<Respuesta>> Insertar(Producto modelo)
		{
			return View(_Respuesta);
		}

	}
}
