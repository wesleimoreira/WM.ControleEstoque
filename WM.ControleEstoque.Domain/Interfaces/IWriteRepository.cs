namespace WM.ControleEstoque.Dominio.Interfaces
{
    public interface IWriteRepository<T>
    {
        T CreateAsync(T objectValue);
        T DeleteAsync(T objectValue);
        T UpdateAsync(T objectValue);
    }
}
