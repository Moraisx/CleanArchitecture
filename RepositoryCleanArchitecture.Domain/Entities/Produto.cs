using RepositoryCleanArchitecture.Domain.Abstractions;
using RepositoryCleanArchitecture.Domain.Exceptions;
using RepositoryCleanArchitecture.Domain.Exeptions.Models;
using RepositoryCleanArchitecture.Domain.ValueObject.Produto;
using System.ComponentModel.DataAnnotations;

namespace RepositoryCleanArchitecture.Domain.Entities
{
    public sealed class Produto : Entity
    {
        [Key]
        public int Id { get; set; }
        
        public NomeProduto Nome { get; init; }

        public CategoriaProduto Categoria { get; init; }

        public bool Ativo { get; private set; } 

        public DescricaoProduto Descricao { get; private set; }

        private Produto(NomeProduto nome, CategoriaProduto categoria, bool ativo, DescricaoProduto descricao)
        {
            Nome = nome;
            Categoria = categoria;
            Ativo = ativo;
            Descricao = descricao;
        }

        public static Produto CriarProduto(string nome, int categoria, bool ativo, string descricao)
        {
            var listaErros = new List<DefaultError>();

            var nomeProduto = NomeProduto.CriarNomeProduto(nome, listaErros);
            var categoriaProduto = CategoriaProduto.CriarCategoriaProduto(categoria, listaErros);
            var descricaoProduto = DescricaoProduto.CriarDescricaoProduto(descricao, listaErros);

            if (listaErros.Any())
                throw DefaultExceptionHandler.ListErros(listaErros);

            return new Produto(nomeProduto, categoriaProduto, ativo, descricaoProduto);
        }
    }
}
