using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Infraestrutura.Configuracao
{
    internal class EnderecoConfiguracao : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(x => x.Numero).HasColumnType("INT").IsRequired();
            builder.Property(x => x.Cep).HasColumnType("NVARCHAR(8)").IsRequired();
            builder.Property(x => x.Pais).HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(x => x.Rua).HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(x => x.Estado).HasColumnType("NVARCHAR(2)").IsRequired();
            builder.Property(x => x.Cidade).HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(x => x.Bairro).HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(x => x.Complemento).HasColumnType("NVARCHAR(50)").IsRequired(false);


            builder.HasOne(x => x.Loja).WithOne().HasForeignKey<Loja>(x => x.EnderecoId);
            builder.HasOne(x => x.Fornecedor).WithOne().HasForeignKey<Fornecedor>(x => x.EnderecoId);
            builder.HasOne(x => x.Funcionario).WithOne().HasForeignKey<Funcionario>(x => x.EnderecoId);
        }
    }
}
