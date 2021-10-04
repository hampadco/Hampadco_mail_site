using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities.Blog;
using DataLayer.Entities.Category;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using ViewModelLayer.Entities.Blog;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]  
    public class BlogController : BaseController 
    {
        public BlogController(HampadcoContext _db,IWebHostEnvironment  env) :base(_db,env)
        {

        }

        public IActionResult Index ()
        {
            var qlist = db.Tbl_Categorys.Where (a => a.FatherIdCat == -2 || a.FatherIdCat==-3).ToList ();
            var listtb = new List<Tbl_Category>();
            if (qlist != null)
            {
                foreach (var item in qlist)
                {
                    var qselect = db.Tbl_Categorys.Where (a => a.FatherIdCat == item.Id).ToList ();
                    if (qselect.Count() != 0)
                    {
                        foreach (var item1 in qselect)
                        {
                            var b = new Tbl_Category ()
                            {
                                Id = item1.Id,
                                NameCat = item1.NameCat + "  " + "-->" + "  " + item.NameCat,
                                FatherIdCat = item1.FatherIdCat
                            };
                            listtb.Add (b);
                        }
                    }
                    else 
                    {
                        listtb.Add (item);
                    }
                }
                ViewBag.list = new SelectList (listtb, "Id", "NameCat");
            } 
            else 
            {
                ViewBag.list = null;
            }
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }

            return View ();
        }

        public IActionResult updateblog (int id)
        {
            var qlist = db.Tbl_Categorys.Where (a => a.FatherIdCat == -2 || a.FatherIdCat == -3).ToList ();
            var listtb = new List<Tbl_Category> ();

            if (qlist != null) 
            {
                foreach (var item in qlist)
                {
                    var qselect = db.Tbl_Categorys.Where (a => a.FatherIdCat == item.Id).ToList ();
                    if (qselect.Count() != 0)
                    {
                        foreach (var item1 in qselect) 
                        {
                            var b = new Tbl_Category () 
                            {
                                Id = item1.Id,
                                NameCat = item1.NameCat + "  " + "-->" + "  " + item.NameCat,
                                FatherIdCat = item1.FatherIdCat
                            };
                            listtb.Add (b);
                        }
                    }
                    else 
                    {
                        listtb.Add (item);
                    }
                }
                ViewBag.list = new SelectList (listtb, "Id", "NameCat");
            }
            else
            {
               ViewBag.list = null;
            }

            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }

            if (id != null)
            {
                Tbl_Blog qblog = new Tbl_Blog ();

                var list = db.Tbl_Blogs.Where (a => a.Id == id).SingleOrDefault ();

                qblog.Id = list.Id;
                qblog.TitleBlog = list.TitleBlog;
                qblog.Language = list.Language;
                qblog.IdCtegoryBlog = list.IdCtegoryBlog;
                qblog.SummaryBlog = list.SummaryBlog;
                qblog.ImageMainBlog = list.ImageMainBlog;
                qblog.FullTextBlog = list.FullTextBlog;
                qblog.KeywordsBlog = list.KeywordsBlog;

                return View (qblog);
            }

            return View ();
        }

        public IActionResult list ()
        {
            if (err != null) {
                ViewBag.er = err;
                err = null;
            }

            List<Vm_Blog> qlist = new List<Vm_Blog> ();
            var qblog = db.Tbl_Blogs.OrderByDescending (a => a.Id).ToList ();
            foreach (var item in qblog)
            {
                var qcat = db.Tbl_Categorys.Where (a => a.Id == item.IdCtegoryBlog).SingleOrDefault ();
                if (qcat != null)
                {
                    var n = new Vm_Blog () 
                    {
                        Id = item.Id,
                        TitleBlog = item.TitleBlog,
                        Language = item.Language,
                        ImageMainBlog = item.ImageMainBlog,
                        CatName = qcat.NameCat
                    };
                qlist.Add (n);
                }
            }

            ViewBag.list = qlist.OrderByDescending (a => a.Id).ToList ();
            
            return View ();
        }

        public async Task<IActionResult> add (Vm_Blog blog)
        {
            string FileExtension1 = Path.GetExtension (blog.file.FileName);
            NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
            var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
            using (var stream = new FileStream (path, FileMode.Create)) 
            {
                await blog.file.CopyToAsync (stream);
            }

            var b = new Tbl_Blog ()
            {
                Language = blog.Language,
                TitleBlog = blog.TitleBlog,
                IdCtegoryBlog = blog.IdCtegoryBlog,
                SummaryBlog = blog.SummaryBlog,
                ImageMainBlog = NewFileName,
                KeywordsBlog = blog.KeywordsBlog,
                FullTextBlog = blog.FullTextBlog,

            };
            db.Tbl_Blogs.Add (b);
            db.SaveChanges ();

            err = "اطلاعات با موفقیت ثبت شد";

            return RedirectToAction ("index");
        }

        public async Task<IActionResult> update (Vm_Blog blog)
        {
            var qselect = db.Tbl_Blogs.Where (a => a.Id == blog.Id).SingleOrDefault ();

            if (blog.file != null)
            {
                string FileExtension1 = Path.GetExtension (blog.file.FileName);
                NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream (path, FileMode.Create))
                {
                    await blog.file.CopyToAsync (stream);
                }
                
                if (qselect != null)
                {
                    qselect.TitleBlog = blog.TitleBlog;
                    qselect.IdCtegoryBlog = blog.IdCtegoryBlog;
                    qselect.Language = blog.Language;
                    qselect.SummaryBlog = blog.SummaryBlog;
                    qselect.ImageMainBlog = NewFileName;
                    qselect.FullTextBlog = blog.FullTextBlog;
                    qselect.KeywordsBlog = blog.KeywordsBlog;
                };
                db.Tbl_Blogs.Update (qselect);
                db.SaveChanges ();

                err = "اطلاعات با موفقیت بروز رسانی شد";

                return RedirectToAction ("list");
            }
            else 
            {
                if (qselect != null)
                {
                    qselect.TitleBlog = blog.TitleBlog;
                    qselect.IdCtegoryBlog = blog.IdCtegoryBlog;
                    qselect.Language = blog.Language;
                    qselect.SummaryBlog = blog.SummaryBlog;
                    qselect.FullTextBlog = blog.FullTextBlog;
                    qselect.KeywordsBlog = blog.KeywordsBlog;
                };
                db.Tbl_Blogs.Update (qselect);
                db.SaveChanges ();

                err = "اطلاعات با موفقیت بروز رسانی شد";

                return RedirectToAction ("list");
            }
        }

        public IActionResult del (int id)
        {
            if (id != null) 
            {
                var qselect = db.Tbl_Blogs.Where (a => a.Id == id).SingleOrDefault ();
                db.Tbl_Blogs.Remove (qselect);
                db.SaveChanges ();

                err = "رکورد مورد نظر با موفقیت حذف شد";

                return RedirectToAction ("list");

            }
            return RedirectToAction ("list");
        }

    }
}