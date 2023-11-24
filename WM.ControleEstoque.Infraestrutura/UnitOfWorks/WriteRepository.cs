using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;
using WM.ControleEstoque.Infraestrutura.DB;

namespace WM.ControleEstoque.Infraestrutura.UnitOfWorks
{
    public class WriteRepository<T> : IWriteRepository<T> where T : EntidadeBase
    {
        private readonly AplicacaoDbContexto _dbContexto;

        public WriteRepository(AplicacaoDbContexto dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public T CreateAsync(T objectValue)
        {
            return (T)_dbContexto.Add(objectValue).Entity;
        }

        public T DeleteAsync(T objectValue)
        {
            return (T)_dbContexto.Remove(objectValue).Entity;
        }

        public T UpdateAsync(T objectValue)
        {
            return (T)_dbContexto.Update(objectValue).Entity;
        }
    }
}
