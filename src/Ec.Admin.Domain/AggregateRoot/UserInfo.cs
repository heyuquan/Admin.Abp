using System;
using Volo.Abp.Domain.Entities;

namespace Ec.Admin.Domain
{
    public class UserInfo : AggregateRoot<Guid>
    {
        public UserInfo(Guid id) : base(id) { }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
