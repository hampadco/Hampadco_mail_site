using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using DataLayer.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using ViewModelLayer.Entities.Originality;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class  OriginalityController: BaseController
    {
        public OriginalityController(HampadcoContext _db,IWebHostEnvironment  env) :base(_db,env)
        {

        }
        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
            //////////////////////////////////////////////////selector
            var qlist=db.Tbl_Products.ToList();
            ViewBag.list=new SelectList(qlist,"Id","TitleProductPro");
            ///////////////////////////////////////////////////////////list
            var orgin =db.Tbl_Originalitys.ToList();
            if (orgin.Count() != 0)
            {
                List<Vm_Originality>  originality=new  List<Vm_Originality>();
                foreach (var item in orgin)
                {
                    var product=db.Tbl_Products.Where(a=>a.Id==item.IdProductOri).SingleOrDefault();
                    if (product != null)
                    {
                        Vm_Originality origin1=new Vm_Originality()
                        {
                            Id=item.Id,
                            NameProduct=product.TitleProductPro,
                            HologramCodeOri=item.HologramCodeOri,
                            NumberProductOri=item.NumberProductOri,
                            Language=item.Language,
                            DateCreateOri=item.DateCreateOri
                        };
                     originality.Add(origin1);
                    }
                }
                ViewBag.listp=originality.OrderByDescending(a=>a.Id).ToList();
            }
            else
            {
                ViewBag.listp=null;
            }

            return View();
        }

        public IActionResult del(int id)
        {
            var qselect=db.Tbl_Originalitys.Where(a=>a.Id==id).SingleOrDefault();
            db.Tbl_Originalitys.Remove(qselect);
            db.SaveChanges();
            err="اطلاعات با موفقیت حذف شد";
            
            return RedirectToAction("index");
        }
        
    }
}