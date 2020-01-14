using System;

namespace Ec.Admin.DTO
{
    public class UserCreateDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
    }
}
