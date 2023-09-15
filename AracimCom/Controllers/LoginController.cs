using AracimCom.Models;
using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AracimCom.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            var result = await _signInManager.PasswordSignInAsync(p.username, p.password, true, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Widget", "Admin");
            }
            else
            {
                return View(p);
            }
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(User p)
        //{            
        //    Context c=new Context();
        //    var datavalue=c.Users.FirstOrDefault(x=>x.UserMail ==p.UserMail && x.UserPassword ==p.UserPassword);
        //    if(datavalue != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,p.UserMail)
        //        };
        //        var useridentity = new ClaimsIdentity(claims,"A");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //        await HttpContext.SignInAsync(principal);                
        //        return RedirectToAction("Widget", "Admin");
        //    }
        //    return View();
        //}
    }
}
