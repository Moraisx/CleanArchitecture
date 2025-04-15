using RepositoryCleanArchitecture.Domain.Exeptions.Models;

namespace RepositoryCleanArchitecture.Domain.ValueObject.Produto
{
    public sealed record NomeProduto
    {
        public string Nome{ get; init; }

        protected NomeProduto() { }
        private NomeProduto(string nome)
        {
            Nome = nome;
        }
        public static NomeProduto CriarNomeProduto(string nome, List<DefaultError> listDefaultErros)
        {
            if (string.IsNullOrEmpty(nome))
                listDefaultErros.Add(new DefaultError($"Nome {nome} inválido", "Nome não pode ser nulo ou vazio"));
            if (!string.IsNullOrEmpty(nome))
                if (nome.Length < 3)
                    listDefaultErros.Add(new DefaultError($"Nome {nome} inválido", "Nome deve ter mais de 3 caracteres"));
            return new NomeProduto(nome);
        }
    }
}
