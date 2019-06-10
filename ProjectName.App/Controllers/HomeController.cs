using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Api.Client;
using ProjectName.App.Models;
using ProjectName.Dto;
using ProjectName.Localization;

namespace ProjectName.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogoutUser()
        {
            await AuthenticationHttpContextExtensions.SignOutAsync(HttpContext);

            return Redirect("~/Home/Logout");
        }

        public /*async Task<>*/ IActionResult Profile(/* int userId*/)
        {
            return View(/*result */);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Form()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Login()
        {
            return View(new LoginDto());
        }

        [HttpPost]
        [AllowAnonymous]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginDto data)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, data.Username), new Claim(ClaimTypes.Role, "role") };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await AuthenticationHttpContextExtensions.SignInAsync(HttpContext, CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            return Redirect("~/Home/Profile");
        }

        public IActionResult RecoverPass()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Terms()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Detail()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }


        public IActionResult Help()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
