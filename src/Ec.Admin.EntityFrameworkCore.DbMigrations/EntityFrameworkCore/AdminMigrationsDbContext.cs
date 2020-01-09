using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace Ec.Admin.EntityFrameworkCore
{
    // 设置为启动项的运行程序必须引用 Ec.Admin.EntityFrameworkCore.DbMigrations 项目，否则生成的迁移文件里面没有实体对应的表信息
    // eg：将 Ec.Admin.Web 项目设置为启动项，将程序包管理器控制台默认项目设置为 Ec.Admin.EntityFrameworkCore.DbMigrations
    // 先执行 Add-Migration 生成迁移文件，确认无误后，
    // 再执行 Update-Database 更新数据库表结构
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

            /* Include modules to your migration db context */
            builder.ConfigureIdentity();
            builder.ConfigurePermissionManagement();

            /* Configure customizations for entities from the modules included  */
            builder.Entity<IdentityUser>(b =>
            {
                b.ConfigureCustomUserProperties();
            });

        }
    }
}
