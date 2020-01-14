using Ec.Admin.AggregateRoot;
using Ec.Admin.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ec.Admin.Repository
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
