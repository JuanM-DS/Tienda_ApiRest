namespace Tienda_ApiRest.Modelos
{
	public class Productos
	{
		public int IdProducto { get; set; }
		public string? Nombre { get; set; }
		public decimal Precio { get; set; }
		public int Unidades { get; set; }
		public int IdCategoria { get; set; }
	}
}
