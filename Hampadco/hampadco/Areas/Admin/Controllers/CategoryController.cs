using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DataLayer.Context;
using DataLayer.Entities.Category;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using ViewModelLayer.Entities.Category;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class  CategoryController: BaseController
    {
        public CategoryController(HampadcoContext _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }
        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er=err;
                err=null;
            }
            //////////////////////////////////////////////////////////////////////////////////select list
            var qlist=db.Tbl_Categorys.ToList();
            ViewBag.lselect= new SelectList(qlist, "Id", "NameCat");
           ////////////////////////////////////////////////////////////////////////////list view bag complete
            var qlistt=db.Tbl_Categorys.ToList();
            var tq=new List<Vm_Category>();
            foreach (var item in qlistt)
            {
                if (item.FatherIdCat==0)
                {
                    NewFileName="دسته اصلی ";
                }
                else
                {
                    var namefather=qlistt.Where(a=>a.Id== item.FatherIdCat).SingleOrDefault();
                    NewFileName=namefather.NameCat;
                }

                var d=new Vm_Category()
                {
                    Id=item.Id,
                    NameCat=item.NameCat,
                    FatherIdCat=item.FatherIdCat,
                    FatherName=NewFileName
                };
                tq.Add(d);
            }

            ViewBag.list=tq.OrderByDescending(a=>a.Id).ToList();

            return View();
        }

        public IActionResult add(Vm_Category cat)
        {
            var qcat=db.Tbl_Categorys.Where(a=>a.NameCat==cat.NameCat && a.FatherIdCat==cat.FatherIdCat).SingleOrDefault();

            if (qcat != null)
            {
                err="این نام قبلا ثبت شده است";
            }
            else
            {
                var tbcat=new Tbl_Category()
                {
                    Language=cat.Language,
                    NameCat=cat.NameCat,
                    FatherIdCat=cat.FatherIdCat
                };
                db.Tbl_Categorys.Add(tbcat);
                db.SaveChanges();
                suc="اطلاعات با موفقیت ثبت شد";
            }
            return RedirectToAction("index");
        }

        public IActionResult del(int id)
        {
            if (db.Tbl_Categorys.Any(a=>a.FatherIdCat==id) )
            {
                err="این رکورد شامل زیر مجموعه است ابتدا باید زیر مجموعه های آن را حذف کنید";
                return RedirectToAction("index");
            }
            if (db.Tbl_Products.Any(a =>a.CategoryIdPro==id.ToString()))
            {
                err="برای این دسته محصول ثبت شده ابتدا باید محصول رو حذف کنید";
                return RedirectToAction("index");
            }
            if (db.Tbl_Blogs.Any(a =>a.IdCtegoryBlog==id))
            {
                err="برای این دسته خبر ثبت شده ابتدا باید خبر رو حذف کنید";
                return RedirectToAction("index");
            }
            else
            {
                var qcat=db.Tbl_Categorys.Where(a=>a.Id==id).SingleOrDefault();
                db.Tbl_Categorys.Remove(qcat);
                db.SaveChanges();
                suc="رکورد با موفقیت حذف شد";
            }

            return RedirectToAction("index");
        }

    }
}