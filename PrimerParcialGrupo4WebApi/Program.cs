using Microsoft.EntityFrameworkCore;
using PrimerParcialGrupo4WebApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar EF Core con SQL Server
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Servicios esenciales
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Para Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Activar Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();