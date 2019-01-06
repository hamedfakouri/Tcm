using Framework.Core;
using Framework.Persistence.Ef;
using Tcm.Domain.Model;

namespace Tcm.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User, long>
    {
    }
}
