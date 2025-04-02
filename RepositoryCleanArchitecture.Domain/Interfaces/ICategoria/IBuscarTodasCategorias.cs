using RepositoryCleanArchitecture.Domain.Entities;

namespace RepositoryCleanArchitecture.Domain.Interfaces.ICategoria
{
    public interface IBuscarTodasCategorias
    {
        Task<IEnumerable<Categoria>> ObterTodasCategorias(int skip, int take);
    }
}
    