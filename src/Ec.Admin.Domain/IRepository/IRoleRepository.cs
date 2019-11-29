using Ec.Admin.Domain.AggregateRoot;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ec.Admin.Domain.IRepository
{
    public interface IRoleRepository : IRepository<Role, Guid>
    {
        Task DeleteRoleByName(string name);
    }
}
