using System.Data.SqlClient;
using Tienda_ApiRest.Modelos;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tienda_ApiRest.Servicios
{
	public class RepositorioCategoria : IRepositorio<Categoria>
	{
		private readonly string? _StrSqlServer;
		public RepositorioCategoria(ConexionSql strSqlServer)
		{
			_StrSqlServer = strSqlServer.StrSqlServer;
		}

		public Task<bool> Insertar(Categoria modelo)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Categoria>?> Listar()
		{
			var Lista = new List<Categoria>();
			try
			{
				using (var con = new SqlConnection(_StrSqlServer))
				{
					using (var cmd = new SqlCommand("sp_Listarcategorias", con))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						await con.OpenAsync();
						using (var rd = await cmd.ExecuteReaderAsync())
						{
							while (rd.Read())
							{
								var miCategoria = new Categoria();
								miCategoria.Id = Convert.ToInt32(rd["IdCategoria"]);
								miCategoria.Nombre = rd["Nombre"].ToString();
								miCategoria.Descripcion = rd["Descripcion"].ToString();

								Lista.Add(miCategoria);
							}
						}
					}
				}
				return Lista;
			}
			catch
			{
				return null;
			}
		}
	}
}
