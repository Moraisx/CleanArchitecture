using RepositoryCleanArchitecture.Domain.Entities;
using RepositoryCleanArchitecture.Domain.Interfaces.ICategoria;

namespace RepositoryCleanArchitecture.Application.UseCases.UseCasesCategoria
{
    public class CategoriaService
    {
        private readonly IBuscarTodasCategorias _buscarTodasCategorias;
        private readonly ICriarCategoria _criarCategoria;

        public CategoriaService(IBuscarTodasCategorias buscarTodasCategorias, ICriarCategoria criarCategoria)
        {
            _buscarTodasCategorias = buscarTodasCategorias;
            _criarCategoria = criarCategoria;
        }

        public async Task CriarCategoria(Categoria categoria)
        {
            await _criarCategoria.CriarCategoria(categoria);
        }

        public async Task<IEnumerable<Categoria>> BuscarTodasCategorias(int skip, int take)
        {
           return await _buscarTodasCategorias.ObterTodasCategorias(skip, take);
        }
    }
}
