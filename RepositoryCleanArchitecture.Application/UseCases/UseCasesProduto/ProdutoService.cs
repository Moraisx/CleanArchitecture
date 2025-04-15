using RepositoryCleanArchitecture.Domain.Interfaces.IProduto;
using RepositoryCleanArchitecture.Domain.Entities;
using RepositoryCleanArchitecture.Domain.Interfaces.IProdutoService;
using RepositoryCleanArchitecture.Domain.Interfaces.IUnitOfWork;

namespace RepositoryCleanArchitecture.Application.UseCases.UseCasesProduto
{
  
    public class ProdutoService : IProdutoService
    {
        private readonly IBuscarTodosProdutos _buscarTodosProdutos;
        private readonly ICriarProduto _criarProduto;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoService(IBuscarTodosProdutos buscarTodosProdutos, ICriarProduto criarProduto, IUnitOfWork unitOfWork)
        {
            _buscarTodosProdutos = buscarTodosProdutos;
            _criarProduto = criarProduto;
            _unitOfWork = unitOfWork;
        }

        public async Task CriarProduto(Produto produto)
        {
            await _criarProduto.CriarProduto(produto);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutos(int skip, int take)
        {
            return await _buscarTodosProdutos.ObterTodosProdutos(skip, take);
        }
    }
}
