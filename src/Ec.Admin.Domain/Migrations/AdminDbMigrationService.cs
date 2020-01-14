using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Ec.Admin.Migrations
{
    public class AdminDbMigrationService : ITransientDependency
    {
        public ILogger<AdminDbMigrationService> Logger { get; set; }

        private readonly IDataSeeder _dataSeeder;
        private readonly IAdminDbSchemaMigrator _dbSchemaMigrator;
        // 数据种子，方便调试查看数据
        private readonly AbpDataSeedOptions _sendOptions;
        private readonly AbpPermissionOptions _pmsOptions;

        public AdminDbMigrationService(
            IDataSeeder dataSeeder,
            IAdminDbSchemaMigrator dbSchemaMigrator,
            IOptionsMonitor<AbpDataSeedOptions> sendOptions,
            IOptionsMonitor<AbpPermissionOptions> pmsOptions
            ) 
        {
            _dataSeeder = dataSeeder;
            _dbSchemaMigrator = dbSchemaMigrator;
            _sendOptions = sendOptions.CurrentValue;
            _pmsOptions = pmsOptions.CurrentValue;

            Logger = NullLogger<AdminDbMigrationService>.Instance;
        }

        public async Task MigrateAsync()
        {
            Logger.LogInformation("Started database migrations...");

            Logger.LogInformation("Migrating database schema...");
            await _dbSchemaMigrator.MigrateAsync();

            Logger.LogInformation("Executing database seed...");
            await _dataSeeder.SeedAsync();

            Logger.LogInformation("Successfully completed database migrations.");
        }
    }
}
