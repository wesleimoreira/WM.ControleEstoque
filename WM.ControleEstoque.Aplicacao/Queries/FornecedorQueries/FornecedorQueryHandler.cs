using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Queries.FornecedorQueries
{
    public class FornecedorQueryHandler : IRequestHandler<FornecedorPorIdQuery, FornecedorDto>, IRequestHandler<FornecedorListaQuery, IEnumerable<FornecedorDto>>
    {
        private readonly IUnitOfWork<Fornecedor> _unitOfWork;

        public FornecedorQueryHandler(IUnitOfWork<Fornecedor> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FornecedorDto> Handle(FornecedorPorIdQuery request, CancellationToken cancellationToken)
        {
            var fornecedor = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

            if (fornecedor is null) return default!;

            return new FornecedorDto(fornecedor.Id, fornecedor.FornecedorNome, fornecedor.FornecedorTelefone, fornecedor.EnderecoId);
        }

        public async Task<IEnumerable<FornecedorDto>> Handle(FornecedorListaQuery request, CancellationToken cancellationToken)
        {
            var fornecedores = await _unitOfWork.ReadRepository.GetAllAsync();

            if (fornecedores is null) return default!;

            return (from fornecedor in fornecedores
                    select new FornecedorDto(fornecedor.Id, fornecedor.FornecedorNome, fornecedor.FornecedorTelefone, fornecedor.EnderecoId)).ToList();
        }
    }
}
