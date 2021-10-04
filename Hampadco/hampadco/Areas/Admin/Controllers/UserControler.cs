using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using hampadco.Models;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class  UserController: BaseController
    {
        public UserController(HampadcoContext _db,IWebHostEnvironment  env) :base(_db,env)
        {

        }
        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
            ViewBag.list=db.Tbl_Users.OrderByDescending(a=>a.Id).ToList();
            return View();
        }

         public IActionResult del(int id)
        {
            var selectdel = db.Tbl_Users.Where(a => a.Id == id).SingleOrDefault();
            db.Tbl_Users.Remove(selectdel);
            db.SaveChanges();
            
            err = "حذف با موفقیت انجام شد";

            return RedirectToAction("index");
        }

    }
}