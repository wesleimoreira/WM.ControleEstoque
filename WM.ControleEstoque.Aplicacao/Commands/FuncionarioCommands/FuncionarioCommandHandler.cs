using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Commands.FuncionarioCommands
{
    public class FuncionarioCommandHandler : IRequestHandler<FuncionarioCadastroCommand, FuncionarioDto>
    {
        private readonly IUnitOfWork<Funcionario> _unitOfWork;

        public FuncionarioCommandHandler(IUnitOfWork<Funcionario> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FuncionarioDto> Handle(FuncionarioCadastroCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return default!;

            var funcionario = _unitOfWork.WriteRepository.CreateAsync(
                Funcionario.CadastroDeFuncionario(request.Cpf, request.FuncionarioNome, request.FuncionarioSenha, request.LojaId, request.EnderecoId));

            if (funcionario is null) return default!;

            await _unitOfWork.SaveChangesAsync();

            return new FuncionarioDto(funcionario.Id, funcionario.Cpf, funcionario.FuncionarioNome, funcionario.FuncionarioSenha, funcionario.Datacadastro, funcionario.LojaId, funcionario.EnderecoId);
        }
    }
}
