using System.Threading.Tasks;

namespace Ec.Admin.Domain.Migration
{
    public interface IAdminDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
