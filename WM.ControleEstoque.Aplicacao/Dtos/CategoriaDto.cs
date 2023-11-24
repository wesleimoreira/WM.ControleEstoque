namespace WM.ControleEstoque.Aplicacao.Dtos
{
    public record CategoriaDto
    {
        public CategoriaDto(Guid id, string categoriaNome)
        {
            Id = id;
            CategoriaNome = categoriaNome;
        }

        public Guid Id { get; private set; }
        public string CategoriaNome { get; private set; }
    }
}
