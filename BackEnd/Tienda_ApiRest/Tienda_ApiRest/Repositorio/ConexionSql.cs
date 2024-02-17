namespace Tienda_ApiRest.Servicios
{
	public class ConexionSql
	{
		public string? StrSqlServer { get;}

		/* Constructor que recibe por inyeccion de dependencias un tipo ConfigurationBuilder.
		 * con el fin de obtener la cadena de conexiond de la base de datos, la cual se encuentra en el appsettings.json*/
		public ConexionSql(ConfigurationBuilder builder)
		{
			StrSqlServer = builder
								.SetBasePath(Directory.GetCurrentDirectory())
								.AddJsonFile("appsettings.json")
								.Build()
								.GetSection("ConnectionStrings:StrSqlServer")
								.Value;
		}
	}
}
