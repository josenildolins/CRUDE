using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace JosenBug.Controllers
{
    public abstract class JosenBugControllerBase: AbpController
    {
        protected JosenBugControllerBase()
        {
            LocalizationSourceName = JosenBugConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
