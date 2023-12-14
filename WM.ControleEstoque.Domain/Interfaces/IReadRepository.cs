namespace WM.ControleEstoque.Dominio.Interfaces
{
    public interface IReadRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(string? tipo1, string? tipo2);
    }
}
