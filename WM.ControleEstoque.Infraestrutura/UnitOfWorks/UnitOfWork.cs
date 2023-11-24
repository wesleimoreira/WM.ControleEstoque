
using WM.ControleEstoque.Dominio.Interfaces;
using WM.ControleEstoque.Infraestrutura.DB;

namespace WM.ControleEstoque.Infraestrutura.UnitOfWorks
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly AplicacaoDbContexto _dbContexto;

        public UnitOfWork(AplicacaoDbContexto dbContexto, IReadRepository<T> readRepository, IWriteRepository<T> writeRepository)
        {
            _dbContexto = dbContexto;
            ReadRepository = readRepository;
            WriteRepository = writeRepository;
        }

        public IReadRepository<T> ReadRepository { get; private set; }
        public IWriteRepository<T> WriteRepository { get; private set; }

        public async ValueTask DisposeAsync()
        {
            await _dbContexto.DisposeAsync();

            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContexto.SaveChangesAsync();
        }
    }
}
