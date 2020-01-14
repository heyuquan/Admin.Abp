using Ec.Admin.DTO;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Ec.Admin
{
    public interface IAccountAppService: IApplicationService
    {
        Task<UserInfoDto> CreateUser(UserCreateDto userCreateDto);

        Task<bool> DeleteRoleByName(string name);

        Task<RoleDto> CreateRole(RoleCreateDto userCreateDto);
    }
}
