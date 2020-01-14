using Ec.Admin.AggregateRoot;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ec.Admin
{
    public class AdminDbContext : AbpDbContext<AdminDbContext>
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options)
            : base(options)
        { }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureAdmin();
        }
    }
}
