namespace WM.ControleEstoque.Dominio.Entidades
{
    public class Categoria : EntidadeBase
    {
        public Categoria(string categoriaNome)
        {
            CategoriaNome = categoriaNome;
        }

        public string CategoriaNome { get; private set; }
        public IEnumerable<Produto> Produtos { get; private set; } = default!; // EF

        public static Categoria CadastroDeCategoria(string categoriaNome)
        {
            if (string.IsNullOrWhiteSpace(categoriaNome)) return default!;

            return new Categoria(categoriaNome);
        }
    }
}
