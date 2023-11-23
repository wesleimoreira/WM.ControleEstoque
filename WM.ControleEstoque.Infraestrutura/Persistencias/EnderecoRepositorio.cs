using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Infraestrutura.Persistencias
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly IRepositorio<Endereco> _repositorio;

        public EnderecoRepositorio(IRepositorio<Endereco> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Endereco> BuscarEndereco(Guid id)
        {
            return await _repositorio.GetAsync(id);
        }

        public async Task CadastroDeEndereco(Endereco endereco)
        {
            await _repositorio.AddAsync(endereco);
        }
    }
}
