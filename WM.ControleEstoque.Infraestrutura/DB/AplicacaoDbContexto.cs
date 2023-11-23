using Microsoft.EntityFrameworkCore;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Infraestrutura.Configuracao;

namespace WM.ControleEstoque.Infraestrutura.DB
{
    public class AplicacaoDbContexto : DbContext
    {
        public AplicacaoDbContexto(DbContextOptions<AplicacaoDbContexto> opcoes) : base(opcoes) { }

        public DbSet<Loja> Lojas => Set<Loja>();
        public DbSet<Produto> Produtos => Set<Produto>();
        public DbSet<Endereco> Enderecos => Set<Endereco>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Fornecedor> Fornecedores => Set<Fornecedor>();
        public DbSet<Funcionario> Funcionarios => Set<Funcionario>();
        public DbSet<VendaProduto> VendaProdutos => Set<VendaProduto>();
        public DbSet<CompraProduto> CompraProdutos => Set<CompraProduto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoriaConfiguracao).Assembly);
        }
    }
}
