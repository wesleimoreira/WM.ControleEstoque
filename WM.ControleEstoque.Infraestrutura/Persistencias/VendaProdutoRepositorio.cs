using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Infraestrutura.Persistencias
{
    public class VendaProdutoRepositorio : IVendaProdutoRepositorio
    {
        private readonly IRepositorio<VendaProduto> _repositorio;

        public VendaProdutoRepositorio(IRepositorio<VendaProduto> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<VendaProduto>> BuscarProdutosVendidos()
        {
            return await _repositorio.GetAllAsync();
        }

        public async Task CadastroDeVendaProduto(VendaProduto vendaProduto)
        {
            await _repositorio.AddAsync(vendaProduto);
        }
    }
}
