using Ec.Admin.Domain.AggregateRoot;
using Ec.Admin.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ec.Admin.EntityFrameworkCore.SqlServer.Repository
{
    public class RoleRepository : EfCoreRepository<AdminDbContext, Role, Guid>, IRoleRepository
    {
        public RoleRepository(IDbContextProvider<AdminDbContext> dbContextProvider)
            : base(dbContextProvider)
        { 
        }

        public async Task DeleteRoleByName(string name)
        {
            await DbContext.Database.ExecuteSqlRawAsync($"delete from role where name={name}");
        }
    }
}
