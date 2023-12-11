using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Commands.FornecedorCommands
{
    public class FornecedorCadastroCommand : IRequest<FornecedorDto>
    {
        public FornecedorCadastroCommand(string fornecedorNome, string fornecedorTelefone, Guid enderecoId)
        {
            EnderecoId = enderecoId;
            FornecedorNome = fornecedorNome;
            FornecedorTelefone = fornecedorTelefone;
        }

        public Guid EnderecoId { get; private set; }
        public string FornecedorNome { get; private set; }
        public string FornecedorTelefone { get; private set; }
    }
}
