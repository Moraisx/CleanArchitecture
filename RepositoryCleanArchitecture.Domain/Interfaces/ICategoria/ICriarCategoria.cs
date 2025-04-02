using RepositoryCleanArchitecture.Domain.Entities;

namespace RepositoryCleanArchitecture.Domain.Interfaces.ICategoria
{
    public interface ICriarCategoria
    {
        Task CriarCategoria(Categoria categoria);
    }
}
