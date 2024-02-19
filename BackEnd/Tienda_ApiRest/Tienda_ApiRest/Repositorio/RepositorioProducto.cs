using System.Data.SqlClient;
using Tienda_ApiRest.Modelos;
using System.Data;

namespace Tienda_ApiRest.Servicios
{
	public class RepositorioProducto : IRepositorio<Producto>
	{
		private readonly string? _StrSqlServer;
		public RepositorioProducto(ConexionSql strSqlServer)
		{
			_StrSqlServer = strSqlServer.StrSqlServer;
		}

		public Task<Producto> BuscarPorId(int id)
		{
			throw new NotImplementedException();
		}

		/* Metodo encargado de insertar los productos en la base de datos*/
		public async Task<bool> Insertar(Producto modelo)
		{
			try
			{
				using (var con = new SqlConnection(_StrSqlServer))
				{
					using (var cmd = new SqlCommand("sp_AggProductos", con))
					{
						cmd.CommandType = System.Data.CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@Nombre", modelo.Nombre);
						cmd.Parameters.AddWithValue("@Precio", modelo.Precio);
						cmd.Parameters.AddWithValue("@Unidades", modelo.Unidades);
						cmd.Parameters.AddWithValue("@IdCategoria", modelo.IdCategoria);
						await con.OpenAsync();
						await cmd.ExecuteNonQueryAsync();

						return true;
					}
				}
			}
			catch
			{
				return false;
			}
		}

		/*Metodo para devolver la lista de productos creada*/
		public async Task<List<Producto>> Listar()
		{
			var lista = new List<Producto>();
			try
			{
				using (var con = new SqlConnection(_StrSqlServer))
				{
					using (var cmd = new SqlCommand("sp_ListarProductos", con))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						await con.OpenAsync();
						using (var rd = await cmd.ExecuteReaderAsync())
						{
							if (rd.HasRows)
							{
								while (rd.Read())
								{
									var producto = new Producto();
									producto.Id = Convert.ToInt32(rd["IdProducto"]);
									producto.Nombre = rd["Nombre"].ToString();
									producto.Precio = Convert.ToDecimal(rd["Precio"]);
									producto.Unidades = Convert.ToInt32(rd["unidades"]);
									producto.IdCategoria = Convert.ToInt32(rd["IdCategoria"]);

									lista.Add(producto);
								}
							}
						}
					}
				}
				return lista;
			}
			catch
			{
				return null;
			}
		}
	}
}
