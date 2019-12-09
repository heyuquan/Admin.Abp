using Ec.Admin.Application.Contracts;
using Ec.Admin.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Ec.Admin.Application
{
    [DependsOn(
        typeof(AdminApplicationContractsModule),
        typeof(AdminDomainModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AdminApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AdminApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AdminApplicationAutoMapperProfile>(validate: true);
            });
        }
    }
}
