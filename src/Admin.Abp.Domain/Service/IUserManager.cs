using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Abp.Domain.Service
{
    public interface IUserManager
    {
        Task<UserInfo> CreateUserInfo(string name, string email);

        Task DeleteRoleByName(string name);
    }
}
