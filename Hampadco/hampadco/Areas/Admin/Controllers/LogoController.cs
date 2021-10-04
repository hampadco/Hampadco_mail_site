using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using DataLayer.Context;
using Microsoft.AspNetCore.Authorization;
using DataLayer.Entities.Logo;
using ViewModelLayer.Entities.Logo;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class LogoController : BaseController
    {
        public LogoController(HampadcoContext _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////index logo
        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
            var list = db.Tbl_Logos.ToList();

            if (list != null)
            {
                ViewBag.list = list;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> add(Vm_Logo vmlogo)
        {
            if (db.Tbl_Logos.Any(a => a.Language == vmlogo.Language))
            {
                err = "قبلا برای این زبان ثبت شده لطفا آن را حذف دوباره امتحان کنید.";
            }
            else
            {
                string FileExtension1 = Path.GetExtension(vmlogo.ImageLogo.FileName);
                NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await vmlogo.ImageLogo.CopyToAsync(stream);
                }

                string FileExtension2 = Path.GetExtension(vmlogo.fav.FileName);
                NewFileName1 = String.Concat(Guid.NewGuid().ToString(), FileExtension2);
                var path1 = $"{_env.WebRootPath}\\fileupload\\{NewFileName1}";
                using (var stream = new FileStream(path1, FileMode.Create))
                {
                    await vmlogo.fav.CopyToAsync(stream);
                }
                
                var logo = new Tbl_Logo()
                {
                    TitleLogo = vmlogo.TitleLogo,
                    ImageLogo = NewFileName,
                    Language = vmlogo.Language,
                    FavIcon=NewFileName1
                };
                db.Tbl_Logos.Add(logo);
                db.SaveChanges();

                err = "اطلاعات با موفقیت ثبت شد";
            }

            return RedirectToAction("index");
        }
        
        public IActionResult del(int id)
        {
            var selectdel = db.Tbl_Logos.Where(a => a.Id == id).SingleOrDefault();
            db.Tbl_Logos.Remove(selectdel);
            db.SaveChanges();
            
            err = "حذف با موفقیت انجام شد";

            return RedirectToAction("index");
        }

    }
}