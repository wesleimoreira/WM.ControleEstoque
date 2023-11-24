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

        public async Task<IEnumerable<Categoria>> BuscarCategorias()
        {
            return await _repositorio.GetAllAsync();
        }

        public async Task<Categoria> CadastroDeCategoria(Categoria categoria)
        {
            var result = await _repositorio.AddAsync(categoria);

            if (await _repositorio.SaveChangesAsync()) return result;

            return default!;
        }
    }
}
