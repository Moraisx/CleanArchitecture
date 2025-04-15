using RepositoryCleanArchitecture.Domain.Exeptions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryCleanArchitecture.Domain.ValueObject.Produto
{
    public sealed record DescricaoProduto
    {
        public string Descricao { get; init; }

        protected DescricaoProduto() { }
        private DescricaoProduto(string descricao)
        {
            Descricao = descricao;
        }
        public static DescricaoProduto CriarDescricaoProduto(string descricao, List<DefaultError> listDefaultErros)
        {
            if (string.IsNullOrEmpty(descricao))
                listDefaultErros.Add(new DefaultError($"Descrição {descricao} inválido", "Descrição não pode ser nula ou vazia"));
            if (!string.IsNullOrEmpty(descricao))
                if (descricao.Length < 3)
                    listDefaultErros.Add(new DefaultError($"Descrição {descricao} inválida", "Descrição deve ter mais de 3 caracteres"));
            return new DescricaoProduto(descricao); 
        }
    }
}
