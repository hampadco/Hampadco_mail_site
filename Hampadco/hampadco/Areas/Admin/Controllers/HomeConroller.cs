using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using DataLayer.Context;
using hampadco.Models;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using hampadco.Models;
using ViewModelLayer.Entities.Users;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class HomeController : BaseController
    {
        public static string msg ;
        public HomeController(HampadcoContext _db,IWebHostEnvironment  env) :base(_db,env)
        {

        }
        public IActionResult Index()
        {
            var user = db.Tbl_Users.Where(a => a.UserName=="admin").SingleOrDefault();
            if (user != null)
            {
                menu.img=user.ProfileImage;
            }
        
            menu.resiver=db.Tbl_Messages.Where(a=>a.StateMess==false && a.SenderMess!="admin").Count();
            menu.sender=db.Tbl_Messages.Where(a=>a.StateMess==false && a.SenderMess=="admin").Count();
          
            return View();
        }
        public IActionResult exit()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index","home");
        }

        public IActionResult RayChat()
        {
            return View();
        }

        public IActionResult login()
        {
            if ( msg != null )
            {
                ViewBag.msg = msg ;
                msg = null ;   
            }

            return View();
        }

        public IActionResult checklogin(Vm_User vu)
        {
            var user = db.Tbl_Users.Where(a => a.UserName=="admin").SingleOrDefault();

            if ( vu.UserName == user.UserName && vu.Password == user.Password )
            {
                var claims = new List<Claim> () {
                new Claim (ClaimTypes.NameIdentifier,user.Phone),
                new Claim (ClaimTypes.Name, user.NameFamily)
                };
                HttpContext.Session.SetString("mobile",user.Phone);
                var identity = new ClaimsIdentity (claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal (identity);
                var properties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddYears(1),
                    IsPersistent = true
                };
                HttpContext.SignInAsync (principal, properties);
                return RedirectToAction( "index" , "home" );
            }
            else
            {
                msg = "نام کاربری یا رمز اشتباه است" ;
                return RedirectToAction( "login" , "home" ); 
            }
        }

    }
}