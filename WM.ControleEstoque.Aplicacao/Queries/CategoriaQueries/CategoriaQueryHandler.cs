using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Queries.CategoriaQueries
{
    public class CategoriaQueryHandler : IRequestHandler<CategoriaQuery, CategoriaDto>, IRequestHandler<CategoriaListaQuery, IEnumerable<CategoriaDto>>
    {
        private readonly IUnitOfWork<Categoria> _unitOfWork;

        public CategoriaQueryHandler(IUnitOfWork<Categoria> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoriaDto> Handle(CategoriaQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

            if (categoria is null) return default!;

            return new CategoriaDto(categoria.Id, categoria.CategoriaNome);
        }

        public async Task<IEnumerable<CategoriaDto>> Handle(CategoriaListaQuery request, CancellationToken cancellationToken)
        {
            var categorias = await _unitOfWork.ReadRepository.GetAllAsync();

            if (categorias is null) return default!;

            return (from categoria in categorias select new CategoriaDto(categoria.Id, categoria.CategoriaNome)).ToList();
        }
    }
}
