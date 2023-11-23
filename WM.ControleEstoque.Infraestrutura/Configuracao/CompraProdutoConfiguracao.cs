using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Infraestrutura.Configuracao
{
    internal class CompraProdutoConfiguracao : IEntityTypeConfiguration<CompraProduto>
    {
        public void Configure(EntityTypeBuilder<CompraProduto> builder)
        {
            builder.Property(x => x.QuantidadeCompra).HasColumnType("INT").IsRequired();
            builder.Property(x => x.ValorCompraTotal).HasColumnType("DECIMAL(10,2)").IsRequired();
            builder.Property(x => x.DataDaCompra).HasColumnType("DATETIME").ValueGeneratedOnAdd();
        }
    }
}
