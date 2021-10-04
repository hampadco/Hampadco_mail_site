using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using DataLayer.Entities.Address;
using ViewModelLayer.Entities.Address;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class  AddressController: BaseController
    {

        public AddressController(HampadcoContext _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }

        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er=err;
                err=null;
            }

            ViewBag.list=db.Tbl_Addresses.ToList();
            return View();
        }

        public IActionResult add(Vm_Address address)
        {
            var qaddress=db.Tbl_Addresses.Where(a=>a.Language==address.Language).SingleOrDefault();
            if (qaddress != null)
            {
                err="قبلا برای این زبان آدرس ثبت شده است شما باید آن را حذف و دباره اضافه کنید";
            }
            else
            {
                Tbl_Address add=new Tbl_Address()
                {
                    Language=address.Language,
                    Address1=address.Address1,
                    Address2=address.Address2,
                    Tel1=address.Tel1,
                    Tel2=address.Tel2,
                    Location=address.Location,
                    Officetel1=address.Officetel1,
                    Officetel2=address.Officetel2,

                };
                db.Tbl_Addresses.Add(add);
                db.SaveChanges();
                err="اطلاعات با موفقیت ثبت شد";
            }
            return RedirectToAction("index");
        }

        public IActionResult del(int id)
        {
          var selectadd=db.Tbl_Addresses.Where(a=>a.Id==id).SingleOrDefault();
          db.Tbl_Addresses.Remove(selectadd);
          db.SaveChanges();
          err="حذف با موفقیت انجام شد";
          
          return RedirectToAction("index");
        }

    }
}