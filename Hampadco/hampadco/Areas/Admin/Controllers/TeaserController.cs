using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using DataLayer.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using DataLayer.Entities.Teaser;
using ViewModelLayer.Entities.Teaser;

namespace hampadco.Areas.Admin.Controllers
{

    [Area("Admin")]
    // [Authorize]
    public class TeaserController : BaseController 
    {
        public TeaserController(HampadcoContext _db,IWebHostEnvironment  env) :base(_db,env)
        {

        }
        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
            var qlist=db.Tbl_Products.ToList();
            ViewBag.list=new SelectList(qlist,"Id","TitleProductPro");
            return View();
        }
        public IActionResult list()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
            ViewBag.list=db.Tbl_Teasers.OrderByDescending(a=>a.Id).ToList();

            return View();
        }

        public async Task<IActionResult> add(Vm_Teaser ex)
        {
            string FileExtension1 = Path.GetExtension(ex.img.FileName);
            NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
            var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await ex.img.CopyToAsync(stream);
            }
            Tbl_Teaser tb=new Tbl_Teaser()
            {
               TitleTeaser=ex.TitleTeaser,
               LinkVideoTeaser=NewFileName,
               Language=ex.Language
            };
           db.Tbl_Teasers.Add(tb);
           db.SaveChanges();

           err="اطلاعات با موفقیت ثبت شد";

           return RedirectToAction("index");
        }

        public IActionResult del(int id)
        {
            var qdel=db.Tbl_Teasers.Where(add=>add.Id==id).SingleOrDefault();
            db.Tbl_Teasers.Remove(qdel);
            db.SaveChanges();

            err="حذف رکورد مورد نظر با موفقیت انجام شد";

            return RedirectToAction("list");
        }

    }
}