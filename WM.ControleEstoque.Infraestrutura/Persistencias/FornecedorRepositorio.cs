using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Infraestrutura.Persistencias
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly IRepositorio<Fornecedor> _repositorio;

        public FornecedorRepositorio(IRepositorio<Fornecedor> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Fornecedor> BuscarFornecedor(Guid id)
        {
            return await _repositorio.GetAsync(id);
        }

        public async Task CadastroDeFornecedor(Fornecedor fornecedor)
        {
            await _repositorio.AddAsync(fornecedor);
        }
    }
}
