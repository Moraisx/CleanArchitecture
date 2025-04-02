using RepositoryCleanArchitecture.Domain.Interfaces.IProduto;
using RepositoryCleanArchitecture.Domain.Entities;

namespace RepositoryCleanArchitecture.Application.UseCases.UseCasesProduto
{
  
    public class ProdutoService
    {
        private readonly IBuscarTodosProdutos _buscarTodosProdutos;
        private readonly ICriarProduto _criarProduto;

        public ProdutoService(IBuscarTodosProdutos buscarTodosProdutos, ICriarProduto criarProduto)
        {
            _buscarTodosProdutos = buscarTodosProdutos;
            _criarProduto = criarProduto;
        }

        
        public async Task CriarProduto(Produto produto)
        {
            await _criarProduto.CriarProduto(produto);
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutos(int skip, int take)
        {
            return await _buscarTodosProdutos.ObterTodosProdutos(skip, take);
        }

    }
}
