using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.ViewModels.Account;
using Web.ViewModels.House;
using Entities.Enums;
//using Web.Models;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        // private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<AccountController> logger,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            // this._roleManager = roleManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            // TODO: Your code here
            await Task.Yield();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                returnUrl = returnUrl ?? Url.Content("~/");
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }

            }

            return View(model);
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            // TODO: Your code here
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model, string returnUrl)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Email, Email = model.Email, FullName = model.FullName, EmailConfirmed = true, PhoneNumberConfirmed = true };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.Customer.ToString());
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        [HttpGet]
        public IActionResult AccessDenied(string returnUrl = null)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogOut(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            returnUrl = returnUrl ?? Url.Content("~/");
            return LocalRedirect(returnUrl);
        }
    }
}