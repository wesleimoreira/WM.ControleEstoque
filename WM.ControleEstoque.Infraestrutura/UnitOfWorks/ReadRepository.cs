using Microsoft.EntityFrameworkCore;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;
using WM.ControleEstoque.Infraestrutura.DB;

namespace WM.ControleEstoque.Infraestrutura.UnitOfWorks
{
    public class ReadRepository<T> : IReadRepository<T> where T : EntidadeBase
    {
        private readonly AplicacaoDbContexto _dbContexto;

        public ReadRepository(AplicacaoDbContexto dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContexto.Set<T>().SingleOrDefaultAsync(x => x.Id.Equals(id)) ?? default!;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string? tipo1, string? tipo2)
        {
            if (!string.IsNullOrEmpty(tipo1) && string.IsNullOrEmpty(tipo2))
                return await _dbContexto.Set<T>().Include(tipo1).ToListAsync();

            if (string.IsNullOrEmpty(tipo1) && !string.IsNullOrEmpty(tipo2))
                return await _dbContexto.Set<T>().Include(tipo2).ToListAsync();

            if (!string.IsNullOrEmpty(tipo1) && !string.IsNullOrEmpty(tipo2))
                return await _dbContexto.Set<T>().Include(tipo1).Include(tipo2).ToListAsync();

            return await _dbContexto.Set<T>().ToListAsync();
        }
    }
}
