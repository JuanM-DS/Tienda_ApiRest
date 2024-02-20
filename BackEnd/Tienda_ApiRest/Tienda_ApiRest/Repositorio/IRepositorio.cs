using Tienda_ApiRest.Modelos;

namespace Tienda_ApiRest.Servicios
{
	/*Infertaz general de los repositorios*/
	public interface IRepositorio<T>
	{
		public Task<bool> Insertar(T modelo);

		public Task<List<T>> Listar();

		public Task<T> BuscarPorId(int id);

		public Task<bool> Actualizar(T modelo);
	}
}
