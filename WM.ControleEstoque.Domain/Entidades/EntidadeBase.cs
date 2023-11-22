namespace WM.ControleEstoque.Dominio.Entidades
{
    public class EntidadeBase
    {
        public EntidadeBase() => Id = Guid.NewGuid();
        public Guid Id { get; private set; }
    }
}
