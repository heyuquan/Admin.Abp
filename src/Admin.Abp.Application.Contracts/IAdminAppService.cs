using Admin.Abp.Application.Contracts.DTO;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Admin.Abp.Application.Contracts
{
    public interface IAdminAppService: IApplicationService
    {
        Task<bool> CreateUser(UserInfoDto userInfoDto);
    }
}
