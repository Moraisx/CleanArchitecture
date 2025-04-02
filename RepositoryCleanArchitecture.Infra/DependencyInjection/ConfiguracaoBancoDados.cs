using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepositoryCleanArchitecture.Infra.Data.Context;

namespace RepositoryCleanArchitecture.Infra
{
    public static class ConfiguracaoBancoDados
    {
        public static IServiceCollection AdicionarBancoDados(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("BancoEmMemoria"));

            return services;
        }
    }
}
