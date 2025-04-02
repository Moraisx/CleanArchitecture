using RepositoryCleanArchitecture.Domain.Entities;

namespace RepositoryCleanArchitecture.Domain.Interfaces.IProduto
{
    public interface ICriarProduto
    {
        Task CriarProduto(Produto produto);
    }
}
