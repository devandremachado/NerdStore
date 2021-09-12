using Microsoft.AspNetCore.Mvc;
using NerdStore.Modulo.Catalogo.Application.Interfaces.Services;
using NerdStore.Shared.Bus;
using NerdStore.Vendas.Application.Commands;
using System;
using System.Threading.Tasks;

namespace NerdStore.MVC.Controllers
{
    public class CarrinhoController : ControllerBase
    {

        private readonly IProdutoAppService _produtoAppService;
        private readonly IMediatorHandler _mediatorHandler;

        public CarrinhoController(
                IProdutoAppService produtoAppService,
                IMediatorHandler mediatorHandler)
        {
            _produtoAppService = produtoAppService;
            _mediatorHandler = mediatorHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            if (produto == null) return BadRequest();

            if(produto.QuantidadeEstoque < quantidade)
            {
                TempData["Erro"] = "Produto com estoque insuficiente";
                return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
            }

            var comando = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);
            await _mediatorHandler.EnviarComando(comando);



            TempData["Erro"] = "Produto indisponível";
            return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });

        }
    }
}
