namespace RepositoryCleanArchitecture.Application.DTOs.ProdutoDTO
{
    public record ProdutoDTO
    {
        public int Id { get; }
        public string Nome { get; init; } = String.Empty;

        public int Categoria { get; init; }

        public bool Ativo { get; init; } 

        public string Descricao { get; init; } = String.Empty;

        public ProdutoDTO(int id,  string nome, int categoria, bool ativo, string descricao)
        {
            Id = id;
            Nome = nome;
            Categoria = categoria;
            Ativo = ativo;
            Descricao = descricao;
        }
    }
}
