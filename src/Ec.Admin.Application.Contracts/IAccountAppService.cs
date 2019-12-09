using Ec.Admin.Application.Contracts.DTO;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Ec.Admin.Application.Contracts
{
    public interface IAccountAppService: IApplicationService
    {
        Task<UserInfoDto> CreateUser(AccountUserCreateDto userCreateDto);

        Task<bool> DeleteRoleByName(string name);
    }
}
