using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Commands.EnderecoCommands
{
    public class EnderecoCadastroCommand : IRequest<EnderecoDto>
    {
        public EnderecoCadastroCommand(string cep, string rua, int numero, string pais, string estado, string cidade, string bairro, string complemento)
        {
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Pais = pais;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Complemento = complemento;
        }

        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
    }
}
