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

        public async Task AddAsync(T entidade)
        {
            await _dbContexto.AddAsync(entidade);
        }

        public async Task DeleteAsync(Guid id)
        {
            _dbContexto.Remove(await GetAsync(id));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContexto.Set<T>().ToListAsync();
        }
        public async Task<T> GetAsync(Guid id)
        {
            return await _dbContexto.Set<T>().SingleOrDefaultAsync(x => x.Id.Equals(id)) ?? default!;
        }

    }
}
