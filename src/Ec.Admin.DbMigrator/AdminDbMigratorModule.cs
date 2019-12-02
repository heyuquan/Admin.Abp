using Ec.Admin.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Ec.Admin.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AdminEntityFrameworkCoreDbMigrationsModule)
        )]
    public class AdminDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
