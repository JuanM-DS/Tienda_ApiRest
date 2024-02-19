using System.ComponentModel.DataAnnotations;

namespace Tienda_ApiRest.Modelos
{
	public abstract class Modelo
	{
		[Required]
		public string? Nombre { get; set; }
		[Required]
		public int Id { get; set; }
	}
}
