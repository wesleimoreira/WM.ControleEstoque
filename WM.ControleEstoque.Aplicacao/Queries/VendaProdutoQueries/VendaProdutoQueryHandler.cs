using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Dominio.Interfaces;

namespace WM.ControleEstoque.Aplicacao.Queries.VendaProdutoQueries
{
    public class VendaProdutoQueryHandler :
        IRequestHandler<VendaProdutoListaQuery, IEnumerable<VendaProdutoDto>>,
        IRequestHandler<VendaProdutoHistoricoQuery, IEnumerable<HistoricoDeComprasDto>>
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

        public Task<IEnumerable<HistoricoDeComprasDto>> Handle(VendaProdutoHistoricoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
