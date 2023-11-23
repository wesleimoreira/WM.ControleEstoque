using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Infraestrutura.Configuracao
{
    internal class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(x => x.QuantidadeEstoque).HasColumnType("INT").IsRequired();
            builder.Property(x => x.ProdutoNome).HasColumnType("NVARCHAR(150)").IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnType("DATETIME").ValueGeneratedOnAdd();
            builder.Property(x => x.ProdutoValorUnitario).HasColumnType("DECIMAL(10,2)").IsRequired();            
        }
    }
}
