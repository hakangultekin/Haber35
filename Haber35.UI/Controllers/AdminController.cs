using Haber35.CORE.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Haber35.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //AppUser user = await _userManager.GetUserAsync(HttpContext.User);
            //var bbh = await _userManager.GetClaimsAsync(user);
            //var aa = User.Claims.First().Value;
            return View();
        }
    }
}
