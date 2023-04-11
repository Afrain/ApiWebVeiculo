using ApiWebVeiculo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiWebVeiculo.Data.Map
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(veiculo => veiculo.Id);
            builder.Property(veiculo => veiculo.Nome).IsRequired().HasMaxLength(50);
            builder.Property(veiculo => veiculo.Marca).IsRequired().HasMaxLength(50);
            builder.Property(veiculo => veiculo.Ano).IsRequired();
            builder.Property(veiculo => veiculo.Preco).IsRequired();
            builder.Property(veiculo => veiculo.Cor).IsRequired().HasMaxLength(20);
        }
    }
}
