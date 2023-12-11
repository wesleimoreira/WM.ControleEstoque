using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Commands.FuncionarioCommands
{
    public class FuncionarioCadastroCommand : IRequest<FuncionarioDto>
    {
        public FuncionarioCadastroCommand(string cpf, string funcionarioNome, string funcionarioSenha, Guid lojaId, Guid enderecoId)
        {
            Cpf = cpf;
            LojaId = lojaId;
            EnderecoId = enderecoId;
            Datacadastro = DateTime.Now;
            FuncionarioNome = funcionarioNome;
            FuncionarioSenha = funcionarioSenha;
        }

        public string Cpf { get; private set; }
        public Guid LojaId { get; private set; }
        public Guid EnderecoId { get; private set; }
        public DateTime Datacadastro { get; private set; }
        public string FuncionarioNome { get; private set; }
        public string FuncionarioSenha { get; private set; }
    }
}
