using Ec.Admin.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Ec.Admin.IdentityServer.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class AdminPageModel : AbpPageModel
    {
        protected AdminPageModel()
        {
            LocalizationResourceType = typeof(AdminResource);
        }
    }
}