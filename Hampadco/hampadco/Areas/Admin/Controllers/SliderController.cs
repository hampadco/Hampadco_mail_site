using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities.Slider;
using DataLayer.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModelLayer.Entities.Slider;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class SliderController : BaseController
    {
        public SliderController(HampadcoContext _db, IWebHostEnvironment env) :
            base(_db, env)
        {
        }

        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
            var qlist = db.Tbl_Products.ToList();
            ViewBag.list = new SelectList(qlist, "Id", "TitleProductPro");
            return View();
        }

        public IActionResult list()
        {
            var d = db.Tbl_Sliders.ToList();
            if (d != null)
            {
                List<Vm_Slider> s = new List<Vm_Slider>();
                foreach (var item in d)
                {
                    var q = db.Tbl_Products.Where(a => a.Id == item.CategoryProductIdSlid).SingleOrDefault();
                    if (q == null)
                    {
                        prname = "محصولی ثبت نشده";
                    }
                    else
                    {
                        prname = q.TitleProductPro;
                    }
                    Vm_Slider f = new Vm_Slider()
                    {
                        Id = item.Id,
                        ImageMainSlid = item.ImageMainSlid,
                        Language = item.Language,
                        nameproduct = prname
                    };
                    s.Add (f);
                }
                ViewBag.list = s.OrderByDescending(a => a.Id).ToList();
            }
            else
            {
                ViewBag.list = null;
            }

            return View();
        }

        //     //////////////////////////////list
        public async Task<IActionResult> add(Vm_Slider ex)
        {
            string FileExtension1 = Path.GetExtension(ex.img.FileName);
            NewFileName =
                String.Concat(Guid.NewGuid().ToString(), FileExtension1);
            var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await ex.img.CopyToAsync(stream);
            }

            Tbl_Slider tb = new Tbl_Slider()
            {
                ImageMainSlid = NewFileName,
                CategoryProductIdSlid = ex.CategoryProductIdSlid,
                Language = ex.Language
            };
            db.Tbl_Sliders.Add (tb);
            db.SaveChanges();

            err = "اطلاعات با موفقیت ثبت شد";

            return RedirectToAction("index");
        }

        public IActionResult del(int id)
        {
            var qdel = db.Tbl_Sliders.Where(add => add.Id == id).SingleOrDefault();
            db.Tbl_Sliders.Remove (qdel);
            db.SaveChanges();

            err = "حذف رکورد مورد نظر با موفقیت انجام شد";

            return RedirectToAction("list");
        }
        
    }
}
