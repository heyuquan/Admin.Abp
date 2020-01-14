using Ec.Admin.Localization;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.Resources.AbpValidation;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.VirtualFileSystem;

namespace Ec.Admin
{
    [DependsOn(
        // module
        typeof(AbpIdentityDomainSharedModule),
        typeof(AbpPermissionManagementDomainSharedModule)
        )]
    public class AdminDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AdminDomainSharedModule>("Ec.Admin");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AdminResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Domain");
            });
        }
    }
}
