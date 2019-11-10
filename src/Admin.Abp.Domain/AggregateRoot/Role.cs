using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Admin.Abp.Domain.AggregateRoot
{
    public class Role : AggregateRoot<Guid>
    {
        public string Name { get; set; }
    }
}
