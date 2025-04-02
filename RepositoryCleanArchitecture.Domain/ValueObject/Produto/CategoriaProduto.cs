using RepositoryCleanArchitecture.Domain.Exeptions.Models;

namespace RepositoryCleanArchitecture.Domain.ValueObject.Produto
{
    public sealed record CategoriaProduto
    {
        public int Value { get; init; }

        private CategoriaProduto(int categoria)
        {
            Value = categoria;
        }
        public static CategoriaProduto CriarParaEF(int categoria) => new CategoriaProduto(categoria);
        public static CategoriaProduto CriarCategoriaProduto(int categoria, List<DefaultError> listDefaultErros)
        {
            if (categoria <= 0)
                listDefaultErros.Add(new DefaultError($"Categoria {categoria} inválida", "Categoria tem que ser maior que 0"));
            return new CategoriaProduto(categoria);
        }

    }
}
