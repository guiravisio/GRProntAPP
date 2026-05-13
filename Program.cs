using GRProntAPP.Context;
using GRProntAPP.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPatientService, PatientsService>(); 

builder.Services.AddControllers();
// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Mapeia a raiz para evitar 404 quando não houver uma rota padrão ou páginas estáticas
app.MapGet("/", () => Results.Content("<html><body><h1>Aplicação em execução</h1><p>API disponível em <a href=\"/swagger\">Swagger</a> ou use as rotas dos controllers.</p></body></html>", "text/html"));

app.Run();
