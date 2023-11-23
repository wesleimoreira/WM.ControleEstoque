using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WM.ControleEstoque.Dominio.Interfaces;
using WM.ControleEstoque.Infraestrutura.DB;
using WM.ControleEstoque.Infraestrutura.Persistencias;

namespace WM.ControleEstoque.Infraestrutura
{
    public static class InfraestruturaExtensoes
    {
        public static void AddInfraestruturaExtensoes(this IServiceCollection services, string stringConexao)
        {
            services.AddDbContext<AplicacaoDbContexto>(options =>
            {
                options.UseSqlServer(stringConexao, b =>
                {
                    b.MigrationsAssembly("WM.ControleEstoque.Api");
                });
            });

            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));

            services.AddScoped<ILojaRepositorio, LojaRepositorio>();
            services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
            services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();
            services.AddScoped<IVendaProdutoRepositorio, VendaProdutoRepositorio>();
            services.AddScoped<ICompraProdutoRepositorio, CompraProdutoRepositorio>();
        }
    }
}
