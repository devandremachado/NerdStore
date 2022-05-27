using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.DTO;
using NerdStore.Catalogo.Application.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NerdStore.MVC.Controllers.Admin
{
    public class AdminProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoService;

        public AdminProdutosController(IProdutoAppService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [Route("admin-produtos")]
        public async Task<IActionResult> Index()
        {
            return View(await _produtoService.ObterTodos());
        }

        [HttpGet]
        [Route("novo-produto")]
        public async Task<IActionResult> NovoProduto()
        {
            return View(await PopularCategorias(new ProdutoDTO()));
        }

        [HttpPost]
        [Route("novo-produto")]
        public async Task<IActionResult> NovoProduto(ProdutoDTO produtoDto)
        {
            if (!ModelState.IsValid) return View(await PopularCategorias(produtoDto));

            await _produtoService.AdicionarProduto(produtoDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("editar-produto")]
        public async Task<IActionResult> AtualizarProduto(Guid id)
        {
            return View(await PopularCategorias(await _produtoService.ObterPorId(id)));
        }

        [HttpPost]
        [Route("editar-produto")]
        public async Task<IActionResult> AtualizarProduto(Guid id, ProdutoDTO produtoDto)
        {
            var produto = await _produtoService.ObterPorId(id);
            produtoDto.QuantidadeEstoque = produto.QuantidadeEstoque;

            ModelState.Remove("QuantidadeEstoque");
            if (!ModelState.IsValid) return View(await PopularCategorias(produtoDto));

            await _produtoService.AtualizarProduto(produtoDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("produto-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id)
        {
            return View("Estoque", await _produtoService.ObterPorId(id));
        }

        [HttpPost]
        [Route("produto-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id, int quantidade)
        {
            if (quantidade > 0)
            {
                await _produtoService.ReporEstoque(id, quantidade);
            }
            else
            {
                await _produtoService.DebitarEstoque(id, quantidade);
            }

            return View("Index", await _produtoService.ObterTodos());
        }

        private async Task<ProdutoDTO> PopularCategorias(ProdutoDTO produtoDto)
        {
            produtoDto.Categorias = await _produtoService.ObterCategorias();
            return produtoDto;
        }
    }
}
