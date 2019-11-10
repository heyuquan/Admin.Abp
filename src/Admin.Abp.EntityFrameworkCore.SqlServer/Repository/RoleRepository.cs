using Admin.Abp.Domain.AggregateRoot;
using Admin.Abp.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Admin.Abp.EntityFrameworkCore.SqlServer.Repository
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
