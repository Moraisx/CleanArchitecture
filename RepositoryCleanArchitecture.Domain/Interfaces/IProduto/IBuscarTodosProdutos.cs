using RepositoryCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryCleanArchitecture.Domain.Interfaces.IProduto
{
    public interface IBuscarTodosProdutos
    {
        Task<IEnumerable<Produto>> ObterTodosProdutos(int skip, int Take);
    }
}
