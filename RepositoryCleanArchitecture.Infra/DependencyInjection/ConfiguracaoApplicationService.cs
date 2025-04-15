using Microsoft.Extensions.DependencyInjection;
using RepositoryCleanArchitecture.Application.UseCases.UseCasesProduto;
using RepositoryCleanArchitecture.Domain.Interfaces.IProdutoService;

namespace RepositoryCleanArchitecture.Infra.DependencyInjection
{
    public static class ConfiguracaoApplicationService
    {
        public static IServiceCollection AdicionarServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();

            return services;
        }
    }
}
