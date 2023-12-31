﻿using MediatR;
using WM.ControleEstoque.Aplicacao.Dtos;

namespace WM.ControleEstoque.Aplicacao.Queries.FuncionarioQueries
{
    public class FuncionarioListaQuery : IRequest<IEnumerable<FuncionarioDto>>
    { }

    public class FuncionarioPorIdQuery : IRequest<FuncionarioDto>
    {
        public FuncionarioPorIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
