using Tienda_ApiRest.Compartir;
using Tienda_ApiRest.Modelos;
using Tienda_ApiRest.Servicios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Inyeccion de dependencias
builder.Services.AddScoped<Microsoft.Extensions.Configuration.ConfigurationBuilder>(); // Configuración de ámbito
builder.Services.AddScoped<IRepositorio<Producto>, RepositorioProducto>();
builder.Services.AddScoped<IRepositorio<Categoria>, RepositorioCategoria>();
builder.Services.AddScoped<ConexionSql>();
builder.Services.AddScoped<Respuesta>();


var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
