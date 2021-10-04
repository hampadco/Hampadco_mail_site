using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities.Baner;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using ViewModelLayer.Entities.Baner;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
   
    public class BanerController : BaseController
    {
        public BanerController(HampadcoContext _db,IWebHostEnvironment  env) :base(_db,env)
        {

        }
        public IActionResult Index ()
        {
            if (err != null) {
                ViewBag.er = err;
                err = null;
            }
            //////////////////////////////////////////////////selector
            var qlist = db.Tbl_Products.ToList ();
            ViewBag.list = new SelectList (qlist, "Id", "TitleProductPro");
            ///////////////////////////////////////////////////////////list
            /// 
            return View ();
        }
        public IActionResult list ()
        {
            if (err != null) {
                ViewBag.er = err;
                err = null;
            }
            ////////////////////////////////list
            var d = db.Tbl_Baners.ToList ();
            if (d != null)
            {
                List<Vm_Baner> s = new List<Vm_Baner> ();
                foreach (var item in d)
                {
                    var q = db.Tbl_Products.Where (a => a.Id == item.CategoryProductIdSlid).SingleOrDefault ();
                    if (q ==null)
                    {
                        prname="محصولی ثبت نشده";
                    }
                    else
                    {
                        prname=q.TitleProductPro;
                    }

                    Vm_Baner f = new Vm_Baner () {
                        Id = item.Id,
                        ImageMainSlid = item.ImageMainSlid,
                        Language = item.Language,
                        NameProduct = prname,
                        IdBaner=item.IdBaner
                    };
                    s.Add (f);
                }
                ViewBag.list = s.OrderByDescending (a => a.Id).ToList ();
            }
            else
            {
                ViewBag.list=null;
            }

            return View ();
        }

        public async Task<IActionResult> add (Vm_Baner ex)
        {
            var cc = db.Tbl_Baners.Where(a=>a.IdBaner==ex.IdBaner).SingleOrDefault();
            if (cc != null)
            {
                err = "بنر با این شماره موجود میباشد بنر را حذف نمایید";
                return RedirectToAction("index");
            }
            else
            {
                string FileExtension1 = Path.GetExtension(ex.img.FileName);
                NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ex.img.CopyToAsync(stream);
                }

                Tbl_Baner tb = new Tbl_Baner()
                {
                    ImageMainSlid = NewFileName,
                    CategoryProductIdSlid = ex.CategoryProductIdSlid,
                    Language = ex.Language,
                    IdBaner = ex.IdBaner
                };

                db.Tbl_Baners.Add(tb);
                db.SaveChanges();
                err = "اطلاعات با موفقیت ثبت شد";

                return RedirectToAction("index");
            }
        }

        public IActionResult del (int id)
        {
            var qdel = db.Tbl_Baners.Where (add => add.Id == id).SingleOrDefault ();
            db.Tbl_Baners.Remove (qdel);
            db.SaveChanges ();
            err = "حذف رکورد مورد نظر با موفقیت انجام شد";
            
            return RedirectToAction ("list");
        }

    }
}