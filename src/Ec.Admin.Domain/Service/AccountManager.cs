using Ec.Admin.AggregateRoot;
using Ec.Admin.IRepository;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Ec.Admin.Service
{
    public class AccountManager : DomainService, IAccountManager, ISingletonDependency
    {
        private readonly IRepository<UserInfo, Guid> _userInfoRepository;
        private readonly IRoleRepository _roleRepository;

        public AccountManager(
            IRepository<UserInfo, Guid> userInfoRpository,
             IRoleRepository roleRepository)
        {
            _userInfoRepository = userInfoRpository;
            _roleRepository = roleRepository;
        }

        public async Task<UserInfo> CreateUserInfo(string name, string email, Guid roleId)
        {
            Check.NotNullOrEmpty(name, nameof(name));

            var userInfo = new UserInfo(GuidGenerator.Create())
            {
                Name = name,
                Email = email,
                RoleId = roleId
            };

            await _userInfoRepository.InsertAsync(userInfo);

            return userInfo;
        }

        public async Task<bool> DeleteRoleByName(string name)
        {
            Check.NotNullOrEmpty(name, nameof(name));

            //return await Task.FromResult<bool>(true);
            await _roleRepository.DeleteRoleByName(name);
            return true;
        }

        public async Task<Role> CreateRole(string name)
        {
            Check.NotNullOrEmpty(name, nameof(name));
            var role = new Role(GuidGenerator.Create())
            {
                Name = name
            };
            return await _roleRepository.InsertAsync(role);
        }
    }
}
