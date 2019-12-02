using Ec.Admin.Domain.AggregateRoot;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace Ec.Admin.EntityFrameworkCore
{
    public static class AdminDbContextModelCreatingExtensions
    {
        public static void ConfigureAdmin(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            //builder.Entity<UserInfo>()
            //    .HasOne(p => p.Role)
            //    .WithMany()
            //    .HasForeignKey(p => p.RoleId);

            builder.Entity<Blog>()
                .ToTable("EcBlog");

            builder.Entity<Post>()
                // 表映射
                .ToTable("EcPost")
                // 关系
                .HasOne(p => p.Blog)
                .WithMany(b => b.Posts)
                .HasForeignKey(p => p.BlogId);

        }
    }
}
