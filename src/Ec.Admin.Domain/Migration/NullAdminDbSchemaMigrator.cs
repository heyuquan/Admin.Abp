using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Ec.Admin.Domain.Migration
{
    public class NullAdminDbSchemaMigrator: IAdminDbSchemaMigrator,ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}
