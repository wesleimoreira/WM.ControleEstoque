using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WM.ControleEstoque.Infraestrutura.DB;

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
        }
    }
}
