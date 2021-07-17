using MediatR;
using NerdStore.Shared.Messages;
using System.Threading.Tasks;

namespace NerdStore.Shared.Bus
{
    public class MediatrHandler : IMediatrHandler
    {

        private readonly IMediator _mediator;

        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }
    }
}
