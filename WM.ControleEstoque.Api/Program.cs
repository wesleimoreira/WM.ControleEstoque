using WM.ControleEstoque.Aplicacao;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAplicacaoExtensoes(builder.Configuration.GetConnectionString("controleEstoqueDb"));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
