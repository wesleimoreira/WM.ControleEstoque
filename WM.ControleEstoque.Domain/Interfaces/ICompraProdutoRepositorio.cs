using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Dominio.Interfaces
{
    public interface ICompraProdutoRepositorio
    {
        Task<IEnumerable<CompraProduto>> BuscarProdutosComprados();
        Task CadastroDeProdutoComprado(CompraProduto compraProduto);

    }
}
