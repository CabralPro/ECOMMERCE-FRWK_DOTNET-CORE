using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabralStore.Catalogo.Application.ViewModels;

namespace CabralStore.Catalogo.Application.Services
{
    public interface IProdutoAppService : IDisposable
    {
        Task<ProdutoViewModel> ObterPorId(Guid id);
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();

        Task<bool> AdicionarProduto(ProdutoViewModel produtoViewModel);
        Task<bool> AtualizarProduto(ProdutoViewModel produtoViewModel);
        Task<bool> DeletarProduto(Guid id);

        Task<ProdutoViewModel> DebitarEstoque(Guid id, int quantidade);
        Task<ProdutoViewModel> ReporEstoque(Guid id, int quantidade);
    }
}