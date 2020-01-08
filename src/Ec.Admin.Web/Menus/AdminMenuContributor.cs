using Ec.Admin.Domain.Shared.Localization;
using Ec.Admin.Domain.Shared.MultiTenancy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Ec.Admin.Web.Menus
{
    public class AdminMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            if (!MultiTenancyConsts.IsEnabled)
            {
                var administration = context.Menu.GetAdministration();
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<AdminResource>>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem("Ec.Admin.Home", l["Menu:Home"], "/"));
        }
    }
}
