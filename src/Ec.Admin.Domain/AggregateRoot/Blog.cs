using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Ec.Admin.Domain.AggregateRoot
{
    public class Blog : AggregateRoot<Guid>
    {
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }
}
