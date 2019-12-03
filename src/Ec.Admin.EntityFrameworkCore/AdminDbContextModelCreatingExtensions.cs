using Ec.Admin.Domain.AggregateRoot;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ec.Admin.EntityFrameworkCore
{
    // HasOne 或 HasMany 标识正在开始配置的实体类型上的导航属性。 
    // 然后，调用 WithOne 或 WithMany 来标识反向导航
    public static class AdminDbContextModelCreatingExtensions
    {
        public static void ConfigureAdmin(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Role>(b =>
            {
                b.ToTable("EcRole");
                b.ConfigureByConvention();
            });


            builder.Entity<UserInfo>(b =>
            {
                b.ToTable("EcUserInfo");
                b.ConfigureByConvention();

                b.HasOne(p => p.Role)
                 .WithMany()
                 .HasForeignKey(p => p.RoleId);
            });


            builder.Entity<Blog>(b =>
            {
                b.ToTable("EcBlog");
                b.ConfigureByConvention();
            });

            builder.Entity<Post>(b =>
            {
                b.ToTable("EcPost");
                b.ConfigureByConvention();

                b.HasOne(p => p.Blog)
                 .WithMany(b => b.Posts)
                 .HasForeignKey(p => p.BlogId);
            });
        }
    }
}
