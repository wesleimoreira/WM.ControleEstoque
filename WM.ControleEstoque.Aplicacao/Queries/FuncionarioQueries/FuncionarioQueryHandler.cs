using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Queries.FuncionarioQueries
{
    public class FuncionarioQueryHandler : IRequestHandler<FuncionarioListaQuery, IEnumerable<FuncionarioDto>>, IRequestHandler<FuncionarioPorIdQuery, FuncionarioDto>
    {
        private readonly IUnitOfWork<Funcionario> _unitOfWork;

        public FuncionarioQueryHandler(IUnitOfWork<Funcionario> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FuncionarioDto>> Handle(FuncionarioListaQuery request, CancellationToken cancellationToken)
        {
            var funcionarios = await _unitOfWork.ReadRepository.GetAllAsync(null, null);

            if (funcionarios is null) return default!;

            return (from funcionario in funcionarios
                    select new FuncionarioDto(funcionario.Id, funcionario.Cpf, funcionario.FuncionarioNome, funcionario.FuncionarioSenha, funcionario.Datacadastro, funcionario.LojaId, funcionario.EnderecoId)).ToList();
        }

        public async Task<FuncionarioDto> Handle(FuncionarioPorIdQuery request, CancellationToken cancellationToken)
        {
            var funcionario = await _unitOfWork.ReadRepository.GetByIdAsync(request.Id);

            if (funcionario is null) return default!;

            return new FuncionarioDto(funcionario.Id, funcionario.Cpf, funcionario.FuncionarioNome, funcionario.FuncionarioSenha, funcionario.Datacadastro, funcionario.LojaId, funcionario.EnderecoId);
        }
    }
}
