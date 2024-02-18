using System.ComponentModel.DataAnnotations;

namespace Tienda_ApiRest.Modelos
{
	public class Producto : Modelo
	{
		[Required]
		public decimal Precio { get; set; }
		[Required]
		public int Unidades { get; set; }
		[Required]
		public int IdCategoria { get; set; }
	}
}
