using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Infraestrutura.Persistencias
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly IRepositorio<Funcionario> _repositorio;

        public FuncionarioRepositorio(IRepositorio<Funcionario> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Funcionario> BuscarFuncionario(Guid id)
        {
           return await _repositorio.GetAsync(id);
        }

        public async Task CadastroDeFuncionario(Funcionario funcionario)
        {
            await _repositorio.AddAsync(funcionario);
        }
    }
}
