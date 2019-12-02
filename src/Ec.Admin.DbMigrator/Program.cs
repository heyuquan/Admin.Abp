using Ec.Admin.Domain.Migration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp;
using Volo.Abp.Threading;

namespace Ec.Admin.DbMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application = AbpApplicationFactory.Create<AdminDbMigratorModule>(options =>
              {
                  options.UseAutofac();
                  // options
              }))
            {
                application.Initialize();

                AsyncHelper.RunSync(
                    () => application
                        .ServiceProvider
                        .GetRequiredService<AdminDbMigrationService>()
                        .MigrateAsync()
                    );

                application.Shutdown();
            }
        }
    }
}
