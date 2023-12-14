using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Infraestrutura.Configuracao
{
    internal class FornecedorConfiguracao : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {          
            builder.Property(x => x.FornecedorNome).HasColumnType("NVARCHAR(100)");
            builder.Property(x => x.FornecedorTelefone).HasColumnType("NVARCHAR(11)");

            // EF
            builder.HasMany(x => x.Produtos).WithOne().HasForeignKey(x => x.FornecedorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.CompraProdutos).WithOne(x => x.Fornecedor).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
