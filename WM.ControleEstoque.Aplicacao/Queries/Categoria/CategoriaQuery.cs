using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.Categoria
{
    public class CategoriaQuery : IRequest<CategoriaDto>
    {
        public CategoriaQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
