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

            entity.OwnsOne(p => p.Nome, nome =>
            {
                nome.Property(n => n.Nome)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            entity.OwnsOne(p => p.Categoria, categoria =>
            {
                categoria.Property(n => n.Value)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            entity.Property(p => p.Ativo)
                .IsRequired();

            entity.OwnsOne(p => p.Descricao, descricao =>
            {
                descricao.Property(n => n.Descricao)
                .IsRequired()
                .HasMaxLength(255);
            });
        }
    }
}
