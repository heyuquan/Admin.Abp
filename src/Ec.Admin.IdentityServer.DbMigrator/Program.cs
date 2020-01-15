using Ec.Admin.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Threading;

namespace Ec.Admin.IdentityServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application = AbpApplicationFactory.Create<AdminIdentityServerDbMigratorModule>(options =>
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
