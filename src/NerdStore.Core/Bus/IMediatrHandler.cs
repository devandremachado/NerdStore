using NerdStore.Shared.Messages;
using System.Threading.Tasks;

namespace NerdStore.Shared.Bus
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}
