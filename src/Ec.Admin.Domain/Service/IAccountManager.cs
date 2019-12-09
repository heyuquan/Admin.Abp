using Ec.Admin.Domain.AggregateRoot;
using System.Threading.Tasks;

namespace Ec.Admin.Domain.Service
{
    public interface IAccountManager
    {
        Task<UserInfo> CreateUserInfo(string name, string email);

        Task<bool> DeleteRoleByName(string name);
    }
}
