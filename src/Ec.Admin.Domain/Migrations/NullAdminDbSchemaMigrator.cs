using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Ec.Admin.Migrations
{
    public class NullAdminDbSchemaMigrator: IAdminDbSchemaMigrator,ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}
