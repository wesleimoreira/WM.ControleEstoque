using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Infraestrutura.Configuracao
{
    internal class FuncionarioConfiguracao : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.Property(x => x.Cpf).HasColumnType("NVARCHAR(11)").IsRequired();
            builder.Property(x => x.FuncionarioNome).HasColumnType("NVARCHAR(150)").IsRequired();
            builder.Property(x => x.FuncionarioSenha).HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(x => x.Datacadastro).HasColumnType("DATETIME").ValueGeneratedOnAdd();
        }
    }
}
