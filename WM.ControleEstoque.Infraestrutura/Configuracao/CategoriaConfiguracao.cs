using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Infraestrutura.Configuracao
{
    internal class CategoriaConfiguracao : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(x => x.CategoriaNome).HasColumnType("NVARCHAR(100)").IsRequired();

            // EF
            builder.HasMany(x => x.Produtos).WithOne().HasForeignKey(x => x.CategoriaId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
