namespace WM.ControleEstoque.Dominio.Entidades
{
    public class Endereco : EntidadeBase
    {
        private Endereco(string cep, string pais, string estado, string cidade, string bairro, string rua, int numero, string complemento)
        {
            Cep = cep;
            Rua = rua;
            Pais = pais;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Numero = numero;
            Complemento = complemento;
        }

        public string Cep { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }
        public string Pais {  get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }

        public Loja Loja { get; private set; } = default!; // EF
        public Fornecedor Fornecedor { get; private set; } = default!; // EF
        public Funcionario Funcionario { get; private set; } = default!; // EF

        public static Endereco CadastroDeEndereco(string cep, string pais, string estado, string cidade, string bairro, string rua, int numero, string complemento)
        {
            if (numero.Equals(0)) return default!;     
            
            if (string.IsNullOrWhiteSpace(rua)) return default!;

            if (string.IsNullOrWhiteSpace(cep)) return default!;

            if (string.IsNullOrWhiteSpace(pais)) return default!;

            if (string.IsNullOrWhiteSpace(estado)) return default!;

            if (string.IsNullOrWhiteSpace(cidade)) return default!;

            return new Endereco(cep, pais, estado, cidade, bairro, rua, numero, complemento);
        }
    }
}
