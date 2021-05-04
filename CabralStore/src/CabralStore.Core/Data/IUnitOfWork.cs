using System.Threading.Tasks;

namespace CabralStore.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
