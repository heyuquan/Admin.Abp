using Ec.Admin.Domain;
using Ec.Admin.Domain.AggregateRoot;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore;

namespace Ec.Admin.EntityFrameworkCore.SqlServer
{
    public class AdminDbContext : AbpDbContext<AdminDbContext>
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options)
            : base(options)
        { }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserInfo> UserInfos { get; set; }
    }
}
