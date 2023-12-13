using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.FornecedorQueries
{
    public class FornecedorListaQuery : IRequest<IEnumerable<FornecedorDto>> { }

    public class FornecedorPorIdQuery : IRequest<FornecedorDto>
    {
        public FornecedorPorIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
