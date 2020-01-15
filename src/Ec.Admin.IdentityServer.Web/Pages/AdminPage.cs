using Ec.Admin.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Ec.Admin.IdentityServer.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits BlogStore.Web.Pages.BlogStorePage
     */
    public abstract class AdminPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<AdminResource> L { get; set; }
    }
}
