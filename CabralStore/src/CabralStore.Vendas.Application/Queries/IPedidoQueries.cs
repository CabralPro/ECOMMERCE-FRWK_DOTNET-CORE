using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabralStore.Vendas.Application.Queries.ViewModels;

namespace CabralStore.Vendas.Application.Queries
{
    public interface IPedidoQueries
    {
        Task<CarrinhoViewModel> ObterCarrinhoCliente(Guid clienteId);
        Task<IEnumerable<PedidoViewModel>> ObterPedidosCliente(Guid clienteId);
    }
}