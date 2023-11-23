using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Dominio.Interfaces
{
    public interface IFornecedorRepositorio
    {
        Task<Fornecedor> BuscarFornecedor(Guid id);
        Task CadastroDeFornecedor(Fornecedor fornecedor);
    }
}
