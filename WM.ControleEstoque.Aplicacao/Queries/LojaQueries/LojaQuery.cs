using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.LojaQueries
{
    public class LojaListaQuery : IRequest<IEnumerable<LojaDto>>
    {}

    public class LojaPorIdQuery : IRequest<LojaDto>
    {
        public LojaPorIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
