using NerdStore.Shared.Messages;
using NerdStore.Shared.Messages.CommonMessages.Notifications;
using System.Threading.Tasks;

namespace NerdStore.Shared.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarNotification<T>(T notificacao) where T : DomainNotification;

    }
}
