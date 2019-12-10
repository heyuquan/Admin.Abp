using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Ec.Admin.Application.Contracts.DTO
{
    public class RoleDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
