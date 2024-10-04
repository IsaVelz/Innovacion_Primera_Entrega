using BackendInnovacion.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BackendInnovacion.Services;
using Swashbuckle.AspNetCore.Swagger; // Asegúrate de tener este using si es necesario.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<ControlConexion>();
builder.Services.AddSingleton<TokenService>();
builder.Services.AddDbContext<InnovacionContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Añadir Swagger
builder.Services.AddEndpointsApiExplorer(); // Opcional para .NET 6 y superior, necesario para algunos setups de Swagger.
builder.Services.AddSwaggerGen(); // Añade los servicios de generación de Swagger.

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger(); // Habilita Swagger
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackendInnovacion v1")); // Configura la UI de Swagger
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
