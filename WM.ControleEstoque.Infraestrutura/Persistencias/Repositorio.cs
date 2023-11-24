using Microsoft.EntityFrameworkCore;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;
using WM.ControleEstoque.Infraestrutura.DB;

namespace WM.ControleEstoque.Infraestrutura.Persistencias
{
    internal class Repositorio<T> : IRepositorio<T> where T : EntidadeBase
    {
        private readonly AplicacaoDbContexto _dbContexto;

        public Repositorio(AplicacaoDbContexto dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public async Task<T> AddAsync(T entidade)
        {
            var result = await _dbContexto.AddAsync(entidade);

            if (!result.State.Equals(EntityState.Added)) return default!;

            return result.Entity;
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            var result = _dbContexto.Remove(await GetAsync(id));

            if (!result.State.Equals(EntityState.Deleted)) return default!;

            return result.Entity;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _dbContexto.SaveChangesAsync();

            if (result.Equals(0)) return false;

            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbContexto.Set<T>().ToListAsync();

        public async Task<T> GetAsync(Guid id) => await _dbContexto.Set<T>().SingleOrDefaultAsync(x => x.Id.Equals(id)) ?? default!;
    }
}
