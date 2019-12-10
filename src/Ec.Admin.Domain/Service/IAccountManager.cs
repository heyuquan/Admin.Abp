using Ec.Admin.Domain.AggregateRoot;
using System;
using System.Threading.Tasks;

namespace Ec.Admin.Domain.Service
{
    public interface IAccountManager
    {
        Task<UserInfo> CreateUserInfo(string name, string email, Guid roleId);

        Task<bool> DeleteRoleByName(string name);

        Task<Role> CreateRole(string name);
    }
}
