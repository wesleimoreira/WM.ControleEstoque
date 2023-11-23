using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Infraestrutura.Configuracao
{
    internal class VendaProdutoConfiguracao : IEntityTypeConfiguration<VendaProduto>
    {
        public void Configure(EntityTypeBuilder<VendaProduto> builder)
        {
            builder.Property(x => x.QuantidadeVendida).HasColumnType("INT").IsRequired();
            builder.Property(x => x.DataVenda).HasColumnType("DATETIME").ValueGeneratedOnAdd();
            builder.Property(x => x.ValorVendaTotal).HasColumnType("DECIMAL(10,2)").IsRequired();
        }
    }
}
