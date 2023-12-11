﻿using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;
using WM.ControleEstoque.Dominio.Entidades;
using WM.ControleEstoque.Infraestrutura.UnitOfWorks;

namespace WM.ControleEstoque.Aplicacao.Queries.ProdutoQueries
{
    public class ProdutoQueryHandler : IRequestHandler<ProdutoPorIdQuery, ProdutoDto>, IRequestHandler<ProdutoListaQuery, IEnumerable<ProdutoDto>>
    {
        private readonly UnitOfWork<Produto> _uniOfwork;

        public ProdutoQueryHandler(UnitOfWork<Produto> uniOfwork)
        {
            _uniOfwork = uniOfwork;
        }

        public async Task<ProdutoDto> Handle(ProdutoPorIdQuery request, CancellationToken cancellationToken)
        {
            if (request is null) return default!;

            var produto = await _uniOfwork.ReadRepository.GetByIdAsync(request.Id);

            if (produto is null) return default!;

            return new ProdutoDto(produto.Id, produto.ProdutoNome, produto.QuantidadeEstoque, produto.ProdutoValorUnitario, produto.CategoriaId, produto.FornecedorId);
        }

        public async Task<IEnumerable<ProdutoDto>> Handle(ProdutoListaQuery request, CancellationToken cancellationToken)
        {
            var produtos = await _uniOfwork.ReadRepository.GetAllAsync();

            if (produtos is null) return default!;

            return (from produto in produtos
                    select new ProdutoDto(produto.Id, produto.ProdutoNome, produto.QuantidadeEstoque, produto.ProdutoValorUnitario, produto.CategoriaId, produto.FornecedorId)).ToList();
        }
    }
}