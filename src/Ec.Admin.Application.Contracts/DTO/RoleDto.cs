using System;
using Volo.Abp.Application.Dtos;

namespace Ec.Admin.DTO
{
    public class RoleDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
