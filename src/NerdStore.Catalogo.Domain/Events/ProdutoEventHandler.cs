using MediatR;
using NerdStore.Catalogo.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoEstoqueBaixoEvent>
    {

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoEventHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Handle(ProdutoEstoqueBaixoEvent notification, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(notification.AggregateId);

            // Enviar e-mail informando o estoque baixo
        }
    }
}
