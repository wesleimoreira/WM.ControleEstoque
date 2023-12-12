using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Queries.VendaProdutoQueries
{
    public class VendaProdutoQueryHandler :
        IRequestHandler<VendaProdutoListaQuery, IEnumerable<VendaProdutoDto>>,
        IRequestHandler<VendaProdutoPorPeriodoQuery, IEnumerable<VendaProdutoDto>>
    {
        private readonly IUnitOfWork<VendaProduto> _unitOfWork;

        public VendaProdutoQueryHandler(IUnitOfWork<VendaProduto> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VendaProdutoDto>> Handle(VendaProdutoListaQuery request, CancellationToken cancellationToken)
        {
            var vendas = await _unitOfWork.ReadRepository.GetAllAsync();

            return (from venda in vendas
                    select new VendaProdutoDto(venda.Id, venda.ProdutoId, venda.QuantidadeVendida, venda.ValorVendaTotal, venda.DataVenda)).ToList();
        }

        public async Task<IEnumerable<VendaProdutoDto>> Handle(VendaProdutoPorPeriodoQuery request, CancellationToken cancellationToken)
        {
            var vendas = await _unitOfWork.ReadRepository.GetAllAsync();

            return (from venda in vendas
                    where (venda.DataVenda.Date >= request.DataInicio.Date && venda.DataVenda.Date <= request.DataFim.Date)
                    select new VendaProdutoDto(venda.Id, venda.ProdutoId, venda.QuantidadeVendida, venda.ValorVendaTotal, venda.DataVenda)).ToList();
        }
    }
}
