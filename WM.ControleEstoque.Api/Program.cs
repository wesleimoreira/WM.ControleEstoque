using Microsoft.EntityFrameworkCore;
using WM.ControleEstoque.Infraestrutura;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfraestruturaExtensoes(builder.Configuration.GetConnectionString("controleEstoqueDb"));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
