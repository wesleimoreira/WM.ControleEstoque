using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Commands.EnderecoCommands
{
    public class EnderecoCommadHandler : IRequestHandler<EnderecoCadastroCommand, EnderecoDto>
    {
        private readonly IUnitOfWork<Endereco> _unitOfWork;

        public EnderecoCommadHandler(IUnitOfWork<Endereco> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EnderecoDto> Handle(EnderecoCadastroCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return default!;

            var endereco = _unitOfWork.WriteRepository.CreateAsync(
                Endereco.CadastroDeEndereco(request.Cep, request.Pais, request.Estado, request.Cidade, request.Bairro, request.Rua, request.Numero, request.Complemento));

            if (endereco is null) return default!;

            await _unitOfWork.SaveChangesAsync();

            return new EnderecoDto(endereco.Id, endereco.Cep, endereco.Pais, endereco.Estado, endereco.Cidade, endereco.Bairro, endereco.Rua, endereco.Numero, endereco.Complemento);
        }
    }
}
