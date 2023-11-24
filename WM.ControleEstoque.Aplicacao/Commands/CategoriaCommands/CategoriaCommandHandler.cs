using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Aplicacao.Helps;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Commands.CategoriaCommands
{
    public class CategoriaCommandHandler : IRequestHandler<CategoriaCommand, CategoriaDto>
    {
        private readonly IUnitOfWork<Categoria> _unitOfWork;

        public CategoriaCommandHandler(IUnitOfWork<Categoria> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoriaDto> Handle(CategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = MetodosJson.JsonSerializerObject<Categoria>(request);

            if (categoria is null) return default!;

            var categoriaDto = _unitOfWork.WriteRepository.CreateAsync(categoria);

            if (categoriaDto is null) return default!;

            await _unitOfWork.SaveChangesAsync();

            return MetodosJson.JsonSerializerObject<CategoriaDto>(categoriaDto);
        }
    }
}
