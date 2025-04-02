using Microsoft.Extensions.DependencyInjection;
using RepositoryCleanArchitecture.Domain.Interfaces.ICategoria;
using RepositoryCleanArchitecture.Domain.Interfaces.IProduto;
using RepositoryCleanArchitecture.Infra.Repositories;

namespace RepositoryCleanArchitecture.Infra
{
    public static class ConfiguracaoRepositorios
    {
        public static IServiceCollection AdicionarRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IBuscarTodosProdutos, ProdutoRepositorio>();
            services.AddScoped<ICriarProduto, ProdutoRepositorio>();
            services.AddScoped<IBuscarTodasCategorias, CategoriaRepositorio>();
            services.AddScoped<ICriarCategoria, CategoriaRepositorio>();

            return services;
        }
    }
}
