using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CabralStore.Catalogo.Application.Services;
using System.Collections.Generic;
using CabralStore.Vendas.Application.Queries.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CabralStore.WebApp.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CarrinhoController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public CarrinhoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<bool> Checkout(List<CarrinhoItemViewModel> Items)
        {
            foreach (var item in Items)
            {
                await AtualizarEstoque(item.ProdutoId, item.Quantidade * -1);
            }

            return true;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task AtualizarEstoque(Guid id, int quantidade)
        {
            if (quantidade > 0)
            {
                await _produtoAppService.ReporEstoque(id, quantidade);
            }
            else
            {
                await _produtoAppService.DebitarEstoque(id, quantidade);
            }
        }

    }
}