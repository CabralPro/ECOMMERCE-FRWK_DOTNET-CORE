using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CabralStore.Catalogo.Application.Services;
using CabralStore.Catalogo.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CabralStore.WebApp.API.Controllers.Admin
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdminProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public AdminProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpPost]
        [Authorize]
        public async Task<bool> NovoProduto(ProdutoViewModel produtoViewModel)
        {
            return await _produtoAppService.AdicionarProduto(produtoViewModel);
        }

        [HttpPut]
        [Authorize]
        public async Task<bool> AtualizarProduto(ProdutoViewModel produtoViewModel)
        {
            return await _produtoAppService.AtualizarProduto(produtoViewModel);
        }

        [HttpDelete]
        [Authorize]
        public async Task<bool> DeletarProduto(Guid id)
        {
            return await _produtoAppService.DeletarProduto(id);
        }
    }
}