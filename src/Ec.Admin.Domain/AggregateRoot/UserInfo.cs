using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace Ec.Admin.AggregateRoot
{
    public class UserInfo : AggregateRoot<Guid>
    {
        public UserInfo(Guid id) : base(id) { }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; }
    }
}
