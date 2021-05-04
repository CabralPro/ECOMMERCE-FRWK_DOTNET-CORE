using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CabralStore.Catalogo.Application.Services;
using CabralStore.Catalogo.Application.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace CabralStore.WebApp.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VitrineController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public VitrineController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ProdutoViewModel>> ListaProdutos()
        {
            return await _produtoAppService.ObterTodos();
        }
    }
}