using Tienda_ApiRest.Modelos;

namespace Tienda_ApiRest.Servicios
{
	public interface IRepositorio<T>
	{
		public Task<Mensaje> Insertar(T modelo);
	}
}
