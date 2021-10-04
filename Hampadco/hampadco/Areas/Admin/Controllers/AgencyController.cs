using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities.Agency;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ViewModelLayer.Entities.Agency;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class AgencyController : BaseController
    {
        public AgencyController (HampadcoContext _db, IWebHostEnvironment env) : base (_db, env) 
        {

        }
        public IActionResult Index ()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
            return View ();
        }
        public IActionResult List ()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
            ViewBag.list = db.Tbl_Agencys.ToList ();

            return View ();
        }

        public IActionResult del (int id)
        {
            var qdel = db.Tbl_Agencys.Where (add => add.Id == id).SingleOrDefault ();
            db.Tbl_Agencys.Remove (qdel);
            db.SaveChanges ();
            err = "حذف رکورد مورد نظر با موفقیت انجام شد";

            return RedirectToAction ("list");
        }

        public async Task<IActionResult> add (Vm_Agency ex)
        {
            string FileExtension1 = Path.GetExtension (ex.img.FileName);
            NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
            var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
            using (var stream = new FileStream (path, FileMode.Create))
            {
                await ex.img.CopyToAsync (stream);
            }

            Tbl_Agency tb = new Tbl_Agency () 
            {
                Image = NewFileName,
                Name = ex.Name,
                NamePerson = ex.NamePerson,
                Tel = ex.Tel,
                Officetel = ex.Officetel,
                Location = ex.Location,
                Descreption = ex.Descreption,
                Address = ex.Address,
                Language = ex.Language
            };
            db.Tbl_Agencys.Add (tb);
            db.SaveChanges ();
            err = "اطلاعات با موفقیت ثبت شد";

            return RedirectToAction ("index");
        }
        
    }
}