using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryCleanArchitecture.Domain.Entities;
using RepositoryCleanArchitecture.Domain.ValueObject.Produto;


namespace RepositoryCleanArchitecture.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> entity)
        {
            entity.HasIndex(p => p.Id)
                .IsUnique();

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Nome)
                .HasConversion(
                    v => v.Nome,
                    v => NomeProduto.CriarParaEF(v))
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.Categoria)
              .HasConversion(
                  v => v.Value,                   
                  v => CategoriaProduto.CriarParaEF(v));  

            entity.Property(p => p.Ativo)
                .IsRequired();

            entity.Property(p => p.Descricao)
                .HasConversion(
                    v => v.Descricao,
                    v => DescricaoProduto.CriarParaEF(v))
                    .HasMaxLength(255);
        }
    }
}
