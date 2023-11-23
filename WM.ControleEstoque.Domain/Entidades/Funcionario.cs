namespace WM.ControleEstoque.Dominio.Entidades
{
    public class Funcionario : EntidadeBase
    {
        private Funcionario(string cpf, string funcionarioNome, string funcionarioSenha, Guid lojaId, Guid enderecoId)
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
        public string FuncionarioNome {  get; private set; }
        public string FuncionarioSenha { get; private set; }

        public static Funcionario CadastroDeFuncionario(string cpf, string funcionarioNome, string funcionarioSenha, Guid lojaId, Guid enderecoId)
        {
            if (string.IsNullOrWhiteSpace(cpf)) return default!;

            if (string.IsNullOrWhiteSpace(funcionarioNome)) return default!;

            if (string.IsNullOrWhiteSpace(funcionarioSenha)) return default!;

            if (string.IsNullOrWhiteSpace(lojaId.ToString())) return default!;

            if (string.IsNullOrWhiteSpace(enderecoId.ToString())) return default!;

            return new Funcionario(cpf, funcionarioNome, funcionarioSenha, lojaId, enderecoId);
        }
    }
}
