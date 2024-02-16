namespace Tienda_ApiRest.Modelos
{
	public class Producto : Modelo
	{
		public decimal Precio { get; set; }
		public int Unidades { get; set; }
		public int IdCategoria { get; set; }
	}
}
