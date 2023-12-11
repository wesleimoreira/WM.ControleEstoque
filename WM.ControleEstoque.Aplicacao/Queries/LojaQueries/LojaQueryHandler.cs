using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Queries.LojaQueries
{
    public class LojaQueryHandler : IRequestHandler<LojaPorIdQuery, LojaDto>, IRequestHandler<LojaListaQuery, IEnumerable<LojaDto>>
    {
        private readonly IUnitOfWork<Loja> _unitOfWork;

        public LojaQueryHandler(IUnitOfWork<Loja> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LojaDto> Handle(LojaPorIdQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Id.ToString())) return default!;

            var loja = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

            if (loja is null) return default!;

            return new LojaDto(loja.Id, loja.Cnpj, loja.EnderecoId, loja.RazaoSocial);
        }

        public async Task<IEnumerable<LojaDto>> Handle(LojaListaQuery request, CancellationToken cancellationToken)
        {
            var lojas = await _unitOfWork.ReadRepository.GetAllAsync();

            if (lojas is null) return default!;

            return (from loja in lojas select new LojaDto(loja.Id, loja.Cnpj, loja.EnderecoId, loja.RazaoSocial)).ToList();
        }
    }
}
