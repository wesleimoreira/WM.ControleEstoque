namespace WM.ControleEstoque.Dominio.Entidades
{
    public class Loja : EntidadeBase
    {
        private Loja(string cnpj, string razaoSocial, Guid enderecoId)
        {
            Cnpj = cnpj;
            EnderecoId = enderecoId;
            RazaoSocial = razaoSocial;
        }

        public string Cnpj { get; private set; }    
        public Guid EnderecoId { get; private set; }
        public string RazaoSocial { get; private set; }
        public IEnumerable<Funcionario> Funcionarios { get; private set; } = default!; // EF

        public static Loja CadastroDeLoja(string cnpj, string razaoSocial, Guid enderecoId)
        {
            if (string.IsNullOrWhiteSpace(cnpj)) return default!;
            
            if (string.IsNullOrWhiteSpace(razaoSocial)) return default!;

            if (string.IsNullOrWhiteSpace(enderecoId.ToString())) return default!;

            return new Loja(cnpj, razaoSocial, enderecoId);
        }
    }
}
