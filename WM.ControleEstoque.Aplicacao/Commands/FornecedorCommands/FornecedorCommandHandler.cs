using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Commands.FornecedorCommands
{
    public class FornecedorCommandHandler : IRequestHandler<FornecedorCadastroCommand, FornecedorDto>
    {
        private readonly IUnitOfWork<Fornecedor> _unitOfWork;

        public FornecedorCommandHandler(IUnitOfWork<Fornecedor> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FornecedorDto> Handle(FornecedorCadastroCommand request, CancellationToken cancellationToken)
        {
            var fornecedor = _unitOfWork.WriteRepository.CreateAsync(
                Fornecedor.CadastroDeFornecedor(request.FornecedorNome, request.FornecedorTelefone, request.EnderecoId));

            if (fornecedor is null) return default!;

            await _unitOfWork.SaveChangesAsync();

            return new FornecedorDto(fornecedor.Id, fornecedor.FornecedorNome, fornecedor.FornecedorTelefone, fornecedor.EnderecoId);
        }
    }
}
