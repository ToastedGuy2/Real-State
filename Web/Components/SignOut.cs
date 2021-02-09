using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Components
{
    public class SignOut : ViewComponent
    {
        private readonly SignInManager<AppUser> _signInManager;

        public SignOut(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IViewComponentResult Invoke()
        {
            var user = HttpContext.User;
            ViewData["IsHeSigIn"] = _signInManager.IsSignedIn(user);
            ViewData["Username"] = _signInManager.UserManager.GetUserName(user);
            return View();
        }
    }
}