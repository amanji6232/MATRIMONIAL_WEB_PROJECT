using Bussiness_Access_Layer.Service;
using Data_Access_Layer.Database_Connection;
using MATRIMONIAL_WEB_PROJECT.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace MATRIMONIAL_WEB_PROJECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly Queries queries;
        private readonly AppDbContext _dbContext;
        public HomeController(Queries _queries,AppDbContext dbContext)
        {
            queries = _queries;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User_Login model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await queries.GetLogin(model.Username, model.Password);                
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("FullName", user.Username),
                    new Claim(ClaimTypes.Role, user.Type)
                };
                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    var principal = new ClaimsPrincipal(identity);

                  
                    await HttpContext.SignInAsync("MyCookieAuth", principal, new AuthenticationProperties
                    {
                        //IsPersistent = model.RememberMe
                    });

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Login", "Account");
        }



    }
}
