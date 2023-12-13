using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Commands.LojaCommands
{
    public class LojaCadastroCommand : IRequest<LojaDto>
    {
        public LojaCadastroCommand(string cnpj, string razaoSocial, Guid enderecoId)
        {
            Cnpj = cnpj;
            EnderecoId = enderecoId;
            RazaoSocial = razaoSocial;
        }

        public string Cnpj { get; private set; }
        public Guid EnderecoId { get; private set; }
        public string RazaoSocial { get; private set; }
    }
}
