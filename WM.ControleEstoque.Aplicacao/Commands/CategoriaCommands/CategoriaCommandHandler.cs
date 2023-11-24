using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Aplicacao.Helps;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Commands.CategoriaCommands
{
    public class CategoriaCommandHandler : IRequestHandler<CategoriaCommand, CategoriaDto>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaCommandHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<CategoriaDto> Handle(CategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = MetodosJson.JsonSerializerObject<Categoria>(request);

            if (categoria is null) return default!;

            var categoriaResult = await _categoriaRepositorio.CadastroDeCategoria(categoria);

            if (categoriaResult is null) return default!;

            return MetodosJson.JsonSerializerObject<CategoriaDto>(categoriaResult);
        }
    }
}
