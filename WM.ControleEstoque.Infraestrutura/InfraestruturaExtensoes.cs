using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WM.ControleEstoque.Dominio.Interfaces;
using WM.ControleEstoque.Infraestrutura.DB;
using WM.ControleEstoque.Infraestrutura.UnitOfWorks;

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

            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        }
    }
}
