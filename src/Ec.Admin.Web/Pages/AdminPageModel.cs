﻿using Ec.Admin.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Ec.Admin.Pages
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