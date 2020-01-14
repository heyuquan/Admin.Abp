using System.Threading.Tasks;

namespace Ec.Admin.Migrations
{
    public interface IAdminDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
