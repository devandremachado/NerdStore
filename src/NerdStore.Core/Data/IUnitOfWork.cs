using System.Threading.Tasks;

namespace NerdStore.Shared.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
