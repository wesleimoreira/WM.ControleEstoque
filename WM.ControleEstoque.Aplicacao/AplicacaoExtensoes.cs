using System.Reflection;
using WM.ControleEstoque.Infraestrutura;
using Microsoft.Extensions.DependencyInjection;

namespace WM.ControleEstoque.Aplicacao
{
    public static class AplicacaoExtensoes
    {
        public static void AddAplicacaoExtensoes(this IServiceCollection services, string connectionString)
        {
            services.AddInfraestruturaExtensoes(connectionString);

            services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }
    }
}
