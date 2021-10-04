using System;
using System.Linq;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class OrderController : BaseController
    {
        public static string masage;
        public OrderController (HampadcoContext _db, IWebHostEnvironment env) : base (_db, env)
        {

        }
        public IActionResult index()
        {
            ViewBag.order=db.Tbl_Orders.Where(a=>a.State=="OK").OrderByDescending(a=>a.Id).ToList();
            return View();
        }
        public IActionResult detailfactor(int id)
        {
            ViewBag.order=db.Tbl_Factors.Where(a=>a.RFactor==id).ToList();
            return View();
        }
        public IActionResult send(int id)
        {
            var order=db.Tbl_Orders.Where(a=>a.RFactor==id).SingleOrDefault();
            order.State="OKK";
            order.Date_Send=DateTime.UtcNow;
            db.Tbl_Orders.Update(order);
            db.SaveChanges();
            masage="ارسال باموفقیت انجام شد";
            
            return RedirectToAction("sender");
        }
        public IActionResult sender()
        {
            if (masage != null)
            {
               ViewBag.msg=masage;
               masage = null; 
            }

            ViewBag.order=db.Tbl_Orders.Where(a=>a.State=="OKK").OrderByDescending(a=>a.Id).ToList();

            return View();
        }

    }
}