using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Infraestrutura.Persistencias
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly IRepositorio<Categoria> _repositorio;

        public CategoriaRepositorio(IRepositorio<Categoria> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Categoria> BuscarCategoria(Guid id)
        {
            return await _repositorio.GetAsync(id);
        }

        public async Task CadastroDeCategoria(Categoria categoria)
        {
           await _repositorio.AddAsync(categoria);
        }
    }
}
