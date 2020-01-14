using System;
using Volo.Abp.Domain.Entities;

namespace Ec.Admin.AggregateRoot
{
    public class Role : AggregateRoot<Guid>
    {
        public Role(Guid id) : base(id) { }

        public string Name { get; set; }
    }
}
