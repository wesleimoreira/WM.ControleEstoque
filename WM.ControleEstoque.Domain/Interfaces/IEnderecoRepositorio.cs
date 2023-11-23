using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Dominio.Interfaces
{
    public interface IEnderecoRepositorio
    {
        Task<Endereco> BuscarEndereco(Guid id);

        Task CadastroDeEndereco(Endereco endereco);
    }
}
