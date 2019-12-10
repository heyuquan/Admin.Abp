using System;
using System.Collections.Generic;
using System.Text;

namespace Ec.Admin.Application.Contracts.DTO
{
    public class UserCreateDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
    }
}
