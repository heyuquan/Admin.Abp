using System.Threading.Tasks;

namespace Ec.Admin.Domain.Service
{
    public interface IUserManager
    {
        Task<UserInfo> CreateUserInfo(string name, string email);

        Task DeleteRoleByName(string name);
    }
}
