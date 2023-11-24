namespace WM.ControleEstoque.Dominio.Interfaces
{
    public interface IUnitOfWork<T>: IAsyncDisposable
    {
        IReadRepository<T> ReadRepository { get; }
        IWriteRepository<T> WriteRepository { get; }

        Task SaveChangesAsync();
    }
}
