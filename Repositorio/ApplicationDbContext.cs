using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Usuario> Usuario {get; set;}

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Venda> Venda { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<VendaProdutos> VendaProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VendaProdutos>().HasKey(x => new { x.IdVenda, x.IdProduto });

            builder.Entity<VendaProdutos>()
                .HasOne(x => x.Venda)
                .WithMany(y => y.Produtos)
                .HasForeignKey(x => x.IdVenda);

            builder.Entity<VendaProdutos>()
                .HasOne(x => x.Produto)
                .WithMany(y => y.Vendas)
                .HasForeignKey(x => x.IdProduto);
        }
    }
}
