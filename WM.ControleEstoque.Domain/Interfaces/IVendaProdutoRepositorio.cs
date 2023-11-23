using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Dominio.Interfaces
{
    public interface IVendaProdutoRepositorio
    {
        Task CadastroDeVendaProduto(VendaProduto vendaProduto);
        Task<IEnumerable<VendaProduto>> BuscarProdutosVendidos();
    }
}
