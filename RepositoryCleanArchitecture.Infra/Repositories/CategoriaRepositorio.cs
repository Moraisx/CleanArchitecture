using Microsoft.EntityFrameworkCore;
using RepositoryCleanArchitecture.Domain.Entities;
using RepositoryCleanArchitecture.Domain.Interfaces.ICategoria;
using RepositoryCleanArchitecture.Infra.Data.Context;

namespace RepositoryCleanArchitecture.Infra.Repositories
{
    public class CategoriaRepositorio : IBuscarTodasCategorias, ICriarCategoria
    {
        private readonly AppDbContext _context;

        public CategoriaRepositorio(AppDbContext context)
        {
            _context = context;
        }


        public async Task CriarCategoria(Categoria categoria)
        {
            await _context.Set<Categoria>().AddAsync(categoria);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Categoria>> ObterTodasCategorias(int skip, int take)
        {
            return await _context.Set<Categoria>()
                 .Skip(skip)
                 .Take(take)
                 .AsNoTracking()
                 .ToListAsync();
        }
    }
}
