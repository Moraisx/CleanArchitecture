using Microsoft.EntityFrameworkCore;
using RepositoryCleanArchitecture.Domain.Entities;
using RepositoryCleanArchitecture.Domain.Interfaces.IProduto;
using RepositoryCleanArchitecture.Infra.Data.Context;

namespace RepositoryCleanArchitecture.Infra.Repositories
{
    public class ProdutoRepositorio : IBuscarTodosProdutos, ICriarProduto
    {
        private readonly AppDbContext _context;
        
        public ProdutoRepositorio(AppDbContext context)
        {
            _context = context;
        }

     
        public async Task CriarProduto(Produto produto)
        {
           await _context.Set<Produto>().AddAsync(produto);
           await _context.SaveChangesAsync();
     
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutos(int skip, int take)
        {
           return await _context.Set<Produto>()
                .Skip(skip)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
