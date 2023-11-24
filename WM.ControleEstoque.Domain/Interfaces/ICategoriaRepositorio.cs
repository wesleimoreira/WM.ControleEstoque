using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Dominio.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<Categoria> BuscarCategoria(Guid id);
        Task<IEnumerable<Categoria>> BuscarCategorias();
        Task<Categoria> CadastroDeCategoria(Categoria categoria);
    }
}
