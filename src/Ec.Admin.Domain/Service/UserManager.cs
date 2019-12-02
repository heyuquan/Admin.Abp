using Ec.Admin.Domain.AggregateRoot;
using Ec.Admin.Domain.IRepository;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Ec.Admin.Domain.Service
{
    public class UserManager : DomainService, IUserManager, ISingletonDependency
    {
        private readonly IRepository<UserInfo, Guid> _userInfoRepository;
        private readonly IRoleRepository _roleRepository;

        public UserManager(
            IRepository<UserInfo, Guid> userInfoRpository
            , IRoleRepository roleRepository)
        {
            _userInfoRepository = userInfoRpository;
            _roleRepository = roleRepository;
        }

        public async Task<UserInfo> CreateUserInfo(string name, string email)
        {
            Check.NotNullOrEmpty(name, nameof(name));

            var userInfo = new UserInfo(GuidGenerator.Create())
            {
                Name = name,
                Email = email
            };

            await _userInfoRepository.InsertAsync(userInfo);

            return userInfo;
        }

        public async Task DeleteRoleByName(string name)
        {
            Check.NotNullOrEmpty(name, nameof(name));

            await _roleRepository.DeleteRoleByName(name);
        }
    }
}
