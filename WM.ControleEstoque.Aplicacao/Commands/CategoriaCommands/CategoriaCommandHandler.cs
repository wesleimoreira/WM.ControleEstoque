using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Commands.CategoriaCommands
{
    public class CategoriaCommandHandler : IRequestHandler<CategoriaCadastroCommand, CategoriaDto>, IRequestHandler<CategoriaDeleteCommand, CategoriaDto>
    {
        private readonly IUnitOfWork<Categoria> _unitOfWork;

        public CategoriaCommandHandler(IUnitOfWork<Categoria> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoriaDto> Handle(CategoriaCadastroCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return default!;

            var categoriaDto = _unitOfWork.WriteRepository.CreateAsync(Categoria.CadastroDeCategoria(request.CategoriaNome));

            if (categoriaDto is null) return default!;

            await _unitOfWork.SaveChangesAsync();

            return new CategoriaDto(categoriaDto.Id, categoriaDto.CategoriaNome);
        }

        public async Task<CategoriaDto> Handle(CategoriaDeleteCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return default!;

            var categoria = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

            if (categoria is null) return default!;

            var categoriaDto = _unitOfWork.WriteRepository.DeleteAsync(categoria);

            if (categoriaDto is null) return default!;

            await _unitOfWork.SaveChangesAsync();

            return new CategoriaDto(categoriaDto.Id, categoriaDto.CategoriaNome);
        }
    }
}
