using LocadoraVeiculosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculosApi.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Locacao>()
                .HasOne(r => r.Veiculo)
                .WithMany()
                .HasForeignKey(r => r.VeiculoId);

            modelBuilder.Entity<Locacao>()
                .HasOne(r => r.Cliente)
                .WithMany()
                .HasForeignKey(r => r.ClienteId);
        }
    }
}
