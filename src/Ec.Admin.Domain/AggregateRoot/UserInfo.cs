using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Ec.Admin.Domain.AggregateRoot
{
    public class UserInfo : AggregateRoot<Guid>
    {
        public UserInfo(Guid id) : base(id) { }

        public string Name { get; set; }
        public string Email { get; set; }

        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
