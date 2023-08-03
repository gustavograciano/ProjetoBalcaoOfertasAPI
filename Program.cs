using BalcãoDeOfertasAPI;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
// Importe o namespace System.Net
using System.Net;

// Desative a verificação do certificado SSL
ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

var builder = WebApplication.CreateBuilder(args);

// Configurar a conexão com o banco de dados
var connectionString = "Data Source=GUSTAVO\\MSSQLSERVER01;Initial Catalog=BalcaoOfertas;Integrated Security=True;TrustServerCertificate=True";
builder.Services.AddDbContext<MeuDbContext>(options =>
    options.UseSqlServer(connectionString));

// Adicionar serviços ao contêiner de injeção de dependência
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Balcão de Ofertas API", Version = "v1" });
});

var app = builder.Build();

// Configurar o pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Balcão de Ofertas API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
