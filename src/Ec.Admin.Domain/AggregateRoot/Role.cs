using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Ec.Admin.Domain.AggregateRoot
{
    public class Role : AggregateRoot<Guid>
    {
        public string Name { get; set; }
    }
}
