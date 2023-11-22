using Microsoft.EntityFrameworkCore;
using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Infraestrutura.DB
{
    public class AplicacaoDbContexto : DbContext
    {
        public AplicacaoDbContexto(DbContextOptions<AplicacaoDbContexto> opcoes) : base(opcoes) { }

        public DbSet<Produto> Produtos => Set<Produto>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Fornecedor> Fornecedores => Set<Fornecedor>();
        public DbSet<VendaProduto> VendaProdutos => Set<VendaProduto>();
        public DbSet<CompraProduto> CompraProdutos => Set<CompraProduto>();
    }
}
