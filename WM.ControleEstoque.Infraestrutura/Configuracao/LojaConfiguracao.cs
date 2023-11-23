using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Infraestrutura.Configuracao
{
    internal class LojaConfiguracao : IEntityTypeConfiguration<Loja>
    {
        public void Configure(EntityTypeBuilder<Loja> builder)
        {
            builder.Property(x => x.Cnpj).HasColumnType("NVARCHAR(14)").IsRequired();
            builder.Property(x => x.RazaoSocial).HasColumnType("NVARCHAR(150)").IsRequired();

            // EF
            builder.HasMany(x => x.Funcionarios).WithOne().HasForeignKey(x => x.LojaId).OnDelete(DeleteBehavior.Restrict);       
        }
    }
}
