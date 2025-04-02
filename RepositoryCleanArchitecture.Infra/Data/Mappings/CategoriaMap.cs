using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RepositoryCleanArchitecture.Domain.Entities;

namespace RepositoryCleanArchitecture.Infra.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> entity)
        {
            entity.HasIndex(p => p.Id)
                .IsUnique();

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(p => p.Codigo)
                .IsRequired();

            entity.Property(p => p.Descricao)
                    .HasMaxLength(500);
        }
    }
}
