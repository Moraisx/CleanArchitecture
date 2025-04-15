using RepositoryCleanArchitecture.Domain.Entities;

namespace RepositoryCleanArchitecture.Domain.Interfaces.IProdutoService
{
    public interface IProdutoService
    {
        public Task<IEnumerable<Produto>> ObterTodosProdutos(int skip, int take);
        public Task CriarProduto(Produto produto);
    }
}
