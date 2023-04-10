using ApiWebVeiculo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWebVeiculo.Data
{
    public class VeiculoDBContext : DbContext
    {
        public VeiculoDBContext(DbContextOptions<VeiculoDBContext> veiculoDbContext) : base(veiculoDbContext) { }

        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
