using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.ProdutoQueries
{
    public class ProdutoPorIdQuery : IRequest<ProdutoDto>
    {
        public ProdutoPorIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
