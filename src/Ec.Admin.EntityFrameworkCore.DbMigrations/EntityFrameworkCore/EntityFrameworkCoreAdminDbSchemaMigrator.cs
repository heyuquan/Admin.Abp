using Ec.Admin.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Ec.Admin.EntityFrameworkCore
{
    [Volo.Abp.DependencyInjection.Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreAdminDbSchemaMigrator
        : IAdminDbSchemaMigrator, ITransientDependency
    {
        private readonly AdminMigrationsDbContext _dbContext;

        public EntityFrameworkCoreAdminDbSchemaMigrator(AdminMigrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}
