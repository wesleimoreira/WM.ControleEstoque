using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Dominio.Interfaces
{
    public interface IRepositorio<T> where T : EntidadeBase
    {
        Task<T> GetAsync(Guid id);
        Task<T> AddAsync(T entidade);
        Task<T> DeleteAsync(Guid id);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<T>> GetAllAsync();
    }
}
