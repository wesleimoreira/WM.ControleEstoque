using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Dominio.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        Task<Funcionario> BuscarFuncionario(Guid id);

        Task CadastroDeFuncionario(Funcionario funcionario);
    }
}
