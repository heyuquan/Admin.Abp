using Ec.Admin.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Threading;

namespace Ec.Admin
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
