using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using DataLayer.Context;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using DataLayer.Entities.Experts;
using ViewModelLayer.Entities.Experts;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class  ExpertsController: BaseController
    {
        public ExpertsController(HampadcoContext _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }
        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
           
            return View();
        }

        public IActionResult List()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }

            ViewBag.list=db.Tbl_Expertses.ToList();

            return View();
        }
         
        public IActionResult del(int id)
        {
            var qdel=db.Tbl_Expertses.Where(add=>add.Id==id).SingleOrDefault();
            db.Tbl_Expertses.Remove(qdel);
            db.SaveChanges();

            err="حذف رکورد مورد نظر با موفقیت انجام شد";

            return RedirectToAction("list");
        }

        public async Task<IActionResult> add(Vm_Experts ex)
        {
                string FileExtension1 = Path.GetExtension(ex.img.FileName);
                NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ex.img.CopyToAsync(stream);
                }
                //////////////////////////end upload file 
            Tbl_Experts tb=new Tbl_Experts()
            {
               NameEx=ex.NameEx,
               ImageEx=NewFileName,
               TelEx=ex.TelEx,
               OfficeTelEx=ex.OfficeTelEx,
               LocationEx=ex.LocationEx,
               AboutEx=ex.AboutEx,
               Address=ex.Address,
               Language=ex.Language
            };
            db.Tbl_Expertses.Add(tb);
            db.SaveChanges();

            err="اطلاعات با موفقیت ثبت شد";

            return RedirectToAction("index");
        }

    }
}