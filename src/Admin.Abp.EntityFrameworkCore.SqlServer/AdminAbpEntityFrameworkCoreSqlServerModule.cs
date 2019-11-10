﻿using Admin.Abp.Domain;
using Admin.Abp.Domain.AggregateRoot;
using Admin.Abp.EntityFrameworkCore.SqlServer.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Admin.Abp.EntityFrameworkCore.SqlServer
{
    [DependsOn(
        typeof(AdminAbpDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
        )]
    public class AdminAbpEntityFrameworkCoreSqlServerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AdminDbContext>(options=> {
                options.AddDefaultRepositories();

                // 默认情况下为每个聚合根实体(AggregateRoot派生的子类)创建一个仓储. 
                // 如果想要为其他实体也创建仓储 请将includeAllEntities 设置为 true:
                //options.AddDefaultRepositories(includeAllEntities: true);

                // 覆盖默认通用仓储
                options.AddRepository<Role, RoleRepository>();
            });
        }
    }
}
