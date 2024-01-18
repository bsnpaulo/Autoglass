using Autoglass.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Autoglass.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "DataSource=dbauto.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedor>()
                .HasMany(e => e.Produtos)
                .WithOne(e => e.Fornecedor)
                .HasForeignKey(e => e.FornecedorId)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .HasOne(e => e.Fornecedor)
                .WithMany(e => e.Produtos)
                .HasForeignKey(e => e.FornecedorId)
                .IsRequired();
        }
    }
}