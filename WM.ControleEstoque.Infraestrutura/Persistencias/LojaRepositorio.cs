using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Infraestrutura.Persistencias
{
    public class LojaRepositorio : ILojaRepositorio
    {
        private readonly IRepositorio<Loja> _repositorio;

        public LojaRepositorio(IRepositorio<Loja> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task CadastroDeLoja(Loja loja)
        {
            await _repositorio.AddAsync(loja);
        }

        public async Task<Loja> GetLoja(Guid id)
        {
            return await _repositorio.GetAsync(id);
        }
    }
}
