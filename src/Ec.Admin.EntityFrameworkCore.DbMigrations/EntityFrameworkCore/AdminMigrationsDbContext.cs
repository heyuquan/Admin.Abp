using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ec.Admin.EntityFrameworkCore
{
    public class AdminMigrationsDbContext : AbpDbContext<AdminMigrationsDbContext>
    {
        public AdminMigrationsDbContext(DbContextOptions<AdminMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureAdmin();
        }
    }
}
