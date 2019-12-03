using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Ec.Admin.Domain.AggregateRoot
{
    public class Post : AggregateRoot<Guid>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public Guid BlogId { get; set; }

        public Blog Blog { get; set; }
    }
}
