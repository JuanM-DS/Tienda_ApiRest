using Tienda_ApiRest.Modelos;
using Tienda_ApiRest.Servicios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Inyeccion de dependencias
builder.Services.AddScoped<IRepositorio<Producto>, RepositorioProducto>();
builder.Services.AddSingleton<ConexionSql>();
builder.Services.AddScoped<Respuesta>();
builder.Services.AddScoped<ConfigurationBuilder>();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
