using Microsoft.AspNetCore.Mvc;
using NerdStore.Modulo.Catalogo.Application.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace NerdStore.MVC.Controllers
{
    public class VitrineController : Controller
    {

        private readonly IProdutoAppService _produtoService;

        public VitrineController(IProdutoAppService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [Route("")]
        [Route("vitrine")]
        public async Task <IActionResult> Index()
        {
            return View(await _produtoService.ObterTodos());
        }

        [HttpGet]
        [Route("produto-detalhe/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id)
        {
            return View(await _produtoService.ObterPorId(id));
        }
    }
}
