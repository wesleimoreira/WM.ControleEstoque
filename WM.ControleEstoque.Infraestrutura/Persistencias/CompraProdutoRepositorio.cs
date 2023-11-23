using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Infraestrutura.Persistencias
{
    public class CompraProdutoRepositorio : ICompraProdutoRepositorio
    {
        private readonly IRepositorio<CompraProduto> _repositorio;

        public CompraProdutoRepositorio(IRepositorio<CompraProduto> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<CompraProduto>> BuscarProdutosComprados()
        {
            return await _repositorio.GetAllAsync();
        }

        public async Task CadastroDeProdutoComprado(CompraProduto compraProduto)
        {
            await _repositorio.AddAsync(compraProduto);
        }
    }
}
