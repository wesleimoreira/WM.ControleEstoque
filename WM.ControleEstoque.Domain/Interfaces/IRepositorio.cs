using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Dominio.Interfaces
{
    public interface IRepositorio<T> where T : EntidadeBase
    {
        Task<T> GetAsync(Guid id);
        Task AddAsync(T entidade);
        Task DeleteAsync(Guid id);        
        Task<IEnumerable<T>> GetAllAsync();
    }
}
