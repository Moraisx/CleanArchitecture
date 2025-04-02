using RepositoryCleanArchitecture.Domain.Exceptions;
using RepositoryCleanArchitecture.Domain.Exeptions.Models;
using System.ComponentModel.DataAnnotations;

namespace RepositoryCleanArchitecture.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        public int Codigo { get; set; }

        public string Nome { get; set; } = String.Empty;

        public string Descricao { get; set; } = String.Empty;

        private Categoria(int id, string nome, int codigo)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;         
        }

        public Categoria()
        {

        }

        public Categoria CriarCategoria(Categoria categoria)
        {
            var categoriaCriada = new Categoria(categoria.Id, categoria.Nome, categoria.Codigo);
            ValidarCategoria();
            return categoriaCriada;
        }
        public void ValidarCategoria()
        {
            var listaExeption = new List<DefaultError>();

            if (string.IsNullOrWhiteSpace(Nome))
                listaExeption.Add(new DefaultError($"Nome {Nome} inválido", "Nome não pode ser nulo ou vazio"));
            if (Nome.Length < 3 || Nome.Length > 255)
                listaExeption.Add(new DefaultError($"Nome {Nome} inválido", "Nome deve ter entre 3 e 255 caratectes"));
            if (Codigo <= 0)
                listaExeption.Add(new DefaultError($"Codigo {Codigo} inválido", "Codigo deve ser maior que 0"));           
            if (string.IsNullOrWhiteSpace(Descricao))
                listaExeption.Add(new DefaultError($"Descrição {Descricao} inválida", "Descrição não pode ser nula ou vazia"));
            if (Descricao.Length < 3 || Descricao.Length > 255)
                listaExeption.Add(new DefaultError($"Descrição {Descricao} inválido", "Descrição deve ter entre 3 e 255 caratectes"));

            if(string.IsNullOrEmpty(Nome)|| (Nome.Length < 3 || Nome.Length > 255) || 
                Codigo <= 0 || string.IsNullOrWhiteSpace(Descricao) || (Descricao.Length < 3 || 
                Descricao.Length > 255))

                throw DefaultExceptionHandler.ListErros(listaExeption);
        }
    }
}
