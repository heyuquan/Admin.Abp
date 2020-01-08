using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Ec.Admin.Web
{
    [Dependency(ReplaceServices = true)]
    public class AdminBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Ec.Admin";
    }
}
