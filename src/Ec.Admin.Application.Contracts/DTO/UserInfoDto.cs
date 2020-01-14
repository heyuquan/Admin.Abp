using System;
using Volo.Abp.Application.Dtos;

namespace Ec.Admin.DTO
{
    public class UserInfoDto : EntityDto<Guid>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
