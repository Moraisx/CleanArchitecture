using Microsoft.EntityFrameworkCore;
using RepositoryCleanArchitecture.Domain.Entities;
using RepositoryCleanArchitecture.Infra.Data.Mappings;

namespace RepositoryCleanArchitecture.Infra.Data.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
