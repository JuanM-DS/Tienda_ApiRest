using System.ComponentModel.DataAnnotations;

namespace Tienda_ApiRest.Modelos
{
	public class Categoria : Modelo
	{
		[Required]
		public string? Descripcion { get; set; }
	}
}
