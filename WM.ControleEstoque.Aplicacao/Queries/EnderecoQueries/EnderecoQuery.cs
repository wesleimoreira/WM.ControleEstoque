using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.EnderecoQueries
{
    public class EnderecoPorIdQuery : IRequest<EnderecoDto>
    {
        public EnderecoPorIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
