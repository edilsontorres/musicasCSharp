using Musica.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Buscando as informações do meu Contexto e conectando com o Banco de Dados configurado no appsettings.json
builder.Services.AddDbContext<MusicaDBContext>(opt => opt.UseMySql(builder.Configuration.GetConnectionString("DataBase"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DataBase"))
    ));


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

app.Run();
