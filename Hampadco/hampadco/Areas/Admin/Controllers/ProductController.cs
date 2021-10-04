using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using DataLayer.Entities.Category;
using DataLayer.Entities.Product;
using ViewModelLayer.Entities.Product;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class ProductController : BaseController
    {
        public ProductController(HampadcoContext _db,IWebHostEnvironment  env) :base(_db,env)
        {

        }
        public IActionResult Index ()
        {
            return View ();
        }
        public IActionResult addproduct ()
        {
            var qlist = db.Tbl_Categorys.Where (a => a.FatherIdCat == 0).ToList ();
            var listtb = new List<Tbl_Category> ();

            if (qlist != null)
            {
                foreach (var item in qlist)
                {
                    var qselect = db.Tbl_Categorys.Where (a => a.FatherIdCat == item.Id).ToList ();
                    if (qselect.Count () != 0)
                    {
                        foreach (var item1 in qselect)
                        {
                            var qselect1 = db.Tbl_Categorys.Where (a => a.FatherIdCat == item1.Id).ToList ();
                            if (qselect1.Count () != 0)
                            {
                                foreach (var item2 in qselect1)
                                {
                                    var b = new Tbl_Category ()
                                    {
                                        Id = item2.Id,
                                        NameCat = item2.NameCat + "  " + "--" + "  " + item1.NameCat + "  " + "--" + "  " +item.NameCat,
                                        FatherIdCat = item1.FatherIdCat
                                    };
                                    listtb.Add (b);
                                }
                            }
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

        public IActionResult list ()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }

            var list = db.Tbl_Products.OrderByDescending (a => a.Id).ToList ();
            if (list.Count != 0 )
            {
                List<Vm_Product> p = new List<Vm_Product> ();
                foreach (var item in list)
                {
                    var qcat = db.Tbl_Categorys.Where (a => a.Id == Convert.ToInt32(item.CategoryChildIdPro)).SingleOrDefault ();
                    Vm_Product product = new Vm_Product () 
                    {
                        Id = item.Id,
                        TitleProductPro = item.TitleProductPro,
                        CatName = qcat.NameCat,
                        ImageMainPro = item.ImageMainPro,
                        PricePro = item.PricePro,
                        Language = item.Language,
                        OfferPro = item.OfferPro,
                        TypeCarPro=item.TypeCarPro,
                    };
                    p.Add (product);
                }
                ViewBag.listp = p.OrderByDescending (a => a.Id).ToList ();
            }
            return View ();
        }

        public async Task<IActionResult> add (Vm_Product pro)
        {
            if (pro.mainimg != null)
            {
                string FileExtension1 = Path.GetExtension (pro.mainimg.FileName);
                NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream (path, FileMode.Create))
                {
                    await pro.mainimg.CopyToAsync (stream);
                }
            }

            var fcat=db.Tbl_Categorys.Where(s=>s.Id.ToString()==pro.CategoryChildIdPro).SingleOrDefault().FatherIdCat;
            var cat=db.Tbl_Categorys.Where(d=>d.Id==fcat).SingleOrDefault().Id;
            var off=Convert.ToDouble(pro.OfferPro)/100;
            var offp=pro.PricePro*off;
            var op=pro.PricePro-offp;

            Tbl_Product p = new Tbl_Product() 
            {
                TitleProductPro = pro.TitleProductPro,
                CategoryIdPro =Convert.ToString(cat),
                CategoryChildIdPro=pro.CategoryChildIdPro,
                PricePro = pro.PricePro,
                Price_Pro=Convert.ToInt32(op),
                OfferPro = pro.OfferPro,
                SizePro = pro.SizePro,
                ColorPro = pro.ColorPro,
                BrandPro = pro.BrandPro,
                TypeCarPro = "1",
                MaterialPro = pro.MaterialPro,
                TotalPro = pro.TotalPro,
                DescreptionPro = pro.DescreptionPro,
                Language = pro.Language,
                ImageMainPro = NewFileName,
            };
            db.Tbl_Products.Add (p);
            db.SaveChanges ();

            var q = db.Tbl_Products.OrderByDescending (a => a.Id).Take (1).SingleOrDefault ();
            if (pro.upload_imgs != null)
            {
                foreach (var item in pro.upload_imgs)
                {
                    string FileExtension1 = Path.GetExtension (item.FileName);
                    NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
                    var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                    using (var stream = new FileStream (path, FileMode.Create)) 
                    {
                        await item.CopyToAsync (stream);
                    }

                    Tbl_GalleryProduct g = new Tbl_GalleryProduct ()
                    {
                        Language = pro.Language,
                        ImagePath = NewFileName,
                        IdProduct = q.Id
                    };
                    db.Tbl_GalleryProducts.Add (g);
                    db.SaveChanges ();
                }
            }
            err = "اطلاعات با موفقیت ثبت شد";
            
            return RedirectToAction ("addproduct");
        }

        public IActionResult del (int id)
        {
            var q = db.Tbl_Products.Where (a => a.Id == id).SingleOrDefault ();
            db.Tbl_Products.Remove (q);
            db.SaveChanges ();

            err = "اطلاعات با موفقیت حذف شد";
            
            return RedirectToAction ("list");
        }

        public IActionResult hiden (int id)
        {
            var qa = db.Tbl_Products.Where (a => a.Id == id).SingleOrDefault ();
            qa.TypeCarPro = "0";
            db.Tbl_Products.Update(qa);
            db.SaveChanges();

            err = "اطلاعات با موفقیت مخفی شد";

            return RedirectToAction ("list");
        }
        public IActionResult show (int id)
        {
            var q = db.Tbl_Products.Where (a => a.Id == id).SingleOrDefault ();
            q.TypeCarPro = "1";
            db.Tbl_Products.Update(q);
            db.SaveChanges();

            err = "اطلاعات با موفقیت نمایان شد";

            return RedirectToAction ("list");
        }

        public IActionResult update (int id)
        {
            var qlist = db.Tbl_Categorys.Where (a => a.FatherIdCat == 0).ToList ();
            var listtb = new List<Tbl_Category>();

            if (qlist != null)
            {
                foreach (var item in qlist)
                {
                    var qselect = db.Tbl_Categorys.Where (a => a.FatherIdCat == item.Id).ToList ();
                    if (qselect.Count () != 0)
                    {
                        foreach (var item1 in qselect)
                        {
                            var qselect1 = db.Tbl_Categorys.Where (a => a.FatherIdCat == item1.Id).ToList ();
                            if (qselect1.Count () != 0)
                            {
                                foreach (var item2 in qselect1)
                                {
                                    var b = new Tbl_Category ()
                                    {
                                        Id = item2.Id,
                                        NameCat = item2.NameCat + "  " + "--" + "  " + item1.NameCat + "  " + "--" + "  " +item.NameCat,
                                        FatherIdCat = item1.FatherIdCat
                                    };
                                    listtb.Add (b);
                                }
                            }
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
            var qproduct = db.Tbl_Products.Where (a => a.Id == id).SingleOrDefault ();
            var qgallery = db.Tbl_GalleryProducts.Where (a => a.IdProduct == id).ToList ();
            List<string> h=new List<string>();
            foreach (var item in qgallery)
            {
                h.Add(item.ImagePath);
            }
            Vm_Product qp = new Vm_Product ()
            {
                Id = qproduct.Id,
                TitleProductPro = qproduct.TitleProductPro,
                CategoryChildIdPro=qproduct.CategoryChildIdPro,
                ImageMainPro = qproduct.ImageMainPro,
                CategoryIdPro = qproduct.CategoryIdPro,
                PricePro = qproduct.PricePro,
                Price_Pro=qproduct.Price_Pro,
                OfferPro = qproduct.OfferPro,
                SizePro = qproduct.SizePro,
                ColorPro = qproduct.ColorPro,
                BrandPro = qproduct.BrandPro,
                MaterialPro = qproduct.MaterialPro,
                TotalPro = qproduct.TotalPro,
                DescreptionPro = qproduct.DescreptionPro,
                Language = qproduct.Language,
            };
            ViewBag.img=h;

            return View (qp);
        }

        public async Task<IActionResult> updatepro(Vm_Product pro)
        {
           var qlist=db.Tbl_Products.Where(a=>a.Id==pro.Id).SingleOrDefault();
           if (pro.upload_imgs != null)
            {
               var qgallery=db.Tbl_GalleryProducts.Where(a=>a.IdProduct==pro.Id).ToList();
               foreach (var item in qgallery)
                {
                   db.Tbl_GalleryProducts.Remove(item);
                   db.SaveChanges();
                }
                foreach (var item in pro.upload_imgs)
                {
                    string FileExtension1 = Path.GetExtension (item.FileName);
                    NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
                    var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                    using (var stream = new FileStream (path, FileMode.Create))
                    {
                        await item.CopyToAsync (stream);
                    }
                    Tbl_GalleryProduct g = new Tbl_GalleryProduct ()
                    {
                        Language = pro.Language,
                        ImagePath = NewFileName,
                        IdProduct = pro.Id
                    };
                    db.Tbl_GalleryProducts.Add (g);
                    db.SaveChanges ();
                }
            }
            var fcat=db.Tbl_Categorys.Where(s=>s.Id.ToString()==pro.CategoryChildIdPro).SingleOrDefault().FatherIdCat;
            var cat=db.Tbl_Categorys.Where(d=>d.Id== fcat).SingleOrDefault().Id;
            if (pro.mainimg != null)
            {
                string FileExtension1 = Path.GetExtension (pro.mainimg.FileName);
                NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream (path, FileMode.Create))
                {
                    await pro.mainimg.CopyToAsync (stream);
                }
                // /---------------محاسبه قیمت بعد تخفیف     
                var off=Convert.ToDouble(pro.OfferPro)/100;
                var offp=pro.PricePro*off;
                var op=pro.PricePro-offp;

                qlist.Id = pro.Id;
                qlist.TitleProductPro = pro.TitleProductPro;
                qlist.ImageMainPro = NewFileName;
                qlist.CategoryIdPro =Convert.ToString(cat);
                qlist.CategoryChildIdPro=pro.CategoryChildIdPro;
                qlist.PricePro = pro.PricePro;
                qlist.Price_Pro=Convert.ToInt32(op);
                qlist.OfferPro = pro.OfferPro;
                qlist.SizePro = pro.SizePro;
                qlist.ColorPro = pro.ColorPro;
                qlist.BrandPro = pro.BrandPro;
                qlist.TypeCarPro = pro.TypeCarPro;
                qlist.MaterialPro = pro.MaterialPro;
                qlist.TotalPro = pro.TotalPro;
                qlist.DescreptionPro = pro.DescreptionPro;
                qlist.Language = pro.Language;

                db.Tbl_Products.Update(qlist);
                db.SaveChanges();

                err="اطلاعات با موفقیت به روز رسانی شد.";

                return RedirectToAction("list");
            }
            else
            {
                var off=Convert.ToDouble(pro.OfferPro)/100;
                var offp=pro.PricePro*off;
                var op=pro.PricePro-offp;

                qlist.Id = pro.Id;
                qlist.TitleProductPro = pro.TitleProductPro;
                qlist.CategoryIdPro =Convert.ToString(cat);
                qlist.CategoryChildIdPro=pro.CategoryChildIdPro;
                qlist.PricePro = pro.PricePro;
                qlist.Price_Pro=Convert.ToInt32(op);
                qlist.OfferPro = pro.OfferPro;
                qlist.SizePro = pro.SizePro;
                qlist.ColorPro = pro.ColorPro;
                qlist.BrandPro = pro.BrandPro;
                qlist.TypeCarPro = pro.TypeCarPro;
                qlist.MaterialPro = pro.MaterialPro;
                qlist.TotalPro = pro.TotalPro;
                qlist.DescreptionPro = pro.DescreptionPro;
                qlist.Language = pro.Language;

                db.Tbl_Products.Update(qlist);
                db.SaveChanges();

                err="اطلاعات با موفقیت به روز رسانی شد.";

                return RedirectToAction("list");
            }
        }
        
    }
}