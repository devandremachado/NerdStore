using MediatR;
using NerdStore.Shared.Messages;
using NerdStore.Vendas.Domain.Entities;
using NerdStore.Vendas.Domain.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Application.Commands.Handlers
{
    public class PedidoCommandHandler :
        IRequestHandler<AdicionarItemPedidoCommand, bool>
    {

        private readonly IPedidoRepository _pedidoRepository;

        public PedidoCommandHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<bool> Handle(AdicionarItemPedidoCommand request, CancellationToken cancellationToken)
        {
            if (ValidarComando(request) == false) return false;

            var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(request.ClienteId);
            var pedidoItem = new PedidoItem(request.ProdutoId, request.Nome, request.Quantidade, request.ValorUnitario);

            if (pedido == null)
            {
                pedido = Pedido.PedidoFactory.NovoPedidoRascunho(request.ClienteId);
                pedido.AdicionarItem(pedidoItem);

                _pedidoRepository.Adicionar(pedido);
            }
            else
            {
                var pedidoItemExistente = pedido.PedidoItemExistente(pedidoItem);
                pedido.AdicionarItem(pedidoItem);

                if (pedidoItemExistente == true)
                {
                    _pedidoRepository.AtualizarItem(pedido.PedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId));
                }
                else
                {
                    _pedidoRepository.AdicionarItem(pedidoItem);
                }
            }


            return await _pedidoRepository.UnitOfWork.Commit();
        }

        public bool ValidarComando(Command request)
        {
            if (request.EhValido() == true) return true;

            foreach (var error in request.ValidationResult.Errors)
            {
                
            }

            return false;
        }
    }


}
