using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Queries.EnderecoQueries
{
    public class EnderecoQueryHandler : IRequestHandler<EnderecoPorIdQuery, EnderecoDto>
    {
        private readonly IUnitOfWork<Endereco> _unitOfWork;

        public EnderecoQueryHandler(IUnitOfWork<Endereco> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EnderecoDto> Handle(EnderecoPorIdQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Id.ToString())) return default!;

            var Endereco = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

            if (Endereco is null) return default!;

            return new EnderecoDto(Endereco.Id, Endereco.Cep, Endereco.Pais, Endereco.Estado, Endereco.Cidade, Endereco.Bairro, Endereco.Rua, Endereco.Numero, Endereco.Complemento);
        }
    }
}
