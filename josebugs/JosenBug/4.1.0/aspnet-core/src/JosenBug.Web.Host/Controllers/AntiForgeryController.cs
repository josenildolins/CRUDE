using Microsoft.AspNetCore.Antiforgery;
using JosenBug.Controllers;

namespace JosenBug.Web.Host.Controllers
{
    public class AntiForgeryController : JosenBugControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
