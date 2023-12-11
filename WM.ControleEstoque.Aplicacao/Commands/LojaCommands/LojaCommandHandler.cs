using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Commands.LojaCommands
{
    public class LojaCommandHandler : IRequestHandler<LojaCadastroCommand, LojaDto>
    {
        private readonly IUnitOfWork<Loja> _unitOfWork;

        public LojaCommandHandler(IUnitOfWork<Loja> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LojaDto> Handle(LojaCadastroCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return default!;

            var loja = _unitOfWork.WriteRepository.CreateAsync(Loja.CadastroDeLoja(request.Cnpj, request.RazaoSocial, request.EnderecoId));

            if (loja is null) return default!;

            await _unitOfWork.SaveChangesAsync();

            return new LojaDto(loja.Id, loja.Cnpj, loja.EnderecoId, loja.RazaoSocial);
        }
    }
}
