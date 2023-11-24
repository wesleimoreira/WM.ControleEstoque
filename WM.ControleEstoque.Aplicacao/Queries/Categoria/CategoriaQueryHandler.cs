using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Aplicacao.Helps;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Queries.Categoria
{
    public class CategoriaQueryHandler :
        IRequestHandler<CategoriaQuery, CategoriaDto>,
        IRequestHandler<CategoriaListaQuery, IEnumerable<CategoriaDto>>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaQueryHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<CategoriaDto> Handle(CategoriaQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepositorio.BuscarCategoria(request.Id);

            if (categoria is null) return default!;

            return MetodosJson.JsonSerializerObject<CategoriaDto>(categoria);
        }

        public async Task<IEnumerable<CategoriaDto>> Handle(CategoriaListaQuery request, CancellationToken cancellationToken)
        {
            var categorias = await _categoriaRepositorio.BuscarCategorias();

            return MetodosJson.JsonSerializerObject<IEnumerable<CategoriaDto>>(categorias);
        }
    }
}
