using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using DataLayer.Context;
using DataLayer.Entities.Gallery;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using ViewModelLayer.Entities.Gallery;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class  GalleryController: BaseController
    {
       public GalleryController(HampadcoContext _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }
        public IActionResult Index()
        {
            if (err != null) {
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

            ViewBag.list=db.Tbl_Gallerys.OrderByDescending(a=>a.Id).ToList();

            return View();
        }

        public async Task<IActionResult> add(Vm_Gallery gallery)
        {
            string FileExtension1 = Path.GetExtension (gallery.img.FileName);
            NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
            var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
            using (var stream = new FileStream (path, FileMode.Create))
            {
                await gallery.img.CopyToAsync (stream);
            }

            Tbl_Gallery g=new Tbl_Gallery()
            {
               Language=gallery.Language,
               TitleGal=gallery.TitleGal,
               PathImage=NewFileName,
            };
            db.Tbl_Gallerys.Add(g);
            db.SaveChanges();

            var finallist=db.Tbl_Gallerys.OrderByDescending(a=>a.Id).Take(1).SingleOrDefault();
            if (gallery.upload_imgs != null)
            {
                foreach (var item in gallery.upload_imgs)
                {
                    string FileExtension = Path.GetExtension (item.FileName);
                    NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension);
                    var path1 = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                    using (var stream = new FileStream (path1, FileMode.Create))
                    {
                        await item.CopyToAsync (stream);
                    }

                    Tbl_ImageGallery imageGallery=new Tbl_ImageGallery()
                    {
                        IdGallery=finallist.Id,
                        ImagePath=NewFileName,
                        Language=finallist.Language
                    };
                    db.Tbl_ImageGallerys.Add(imageGallery);
                    db.SaveChanges();
                }
                err="اطلاعات با موفقیت ثبت شد";
            }

            return RedirectToAction("index");
        }

        public IActionResult del(int id)
        {
            var qselect=db.Tbl_Gallerys.Where(a=>a.Id==id).SingleOrDefault();
            db.Tbl_Gallerys.Remove(qselect);
            db.SaveChanges();

            var qgallery=db.Tbl_ImageGallerys.Where(a =>a.IdGallery==id).ToList();
            foreach (var item in qgallery)
            {
                db.Tbl_ImageGallerys.Remove(item);
                db.SaveChanges();
            }

            err="رکورد با موفقیت حذف شد";

            return RedirectToAction("list");
        }

    }
}