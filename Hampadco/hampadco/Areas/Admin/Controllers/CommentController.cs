using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using ViewModelLayer.Entities.Questions;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class  CommentController: BaseController
    {
        public CommentController(HampadcoContext _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }

        public IActionResult index()
        {
            ViewBag.nazarat=db.Tbl_Comments.OrderByDescending(a=>a.Id).ToList();
            return View();
        }
        public IActionResult Detail(int Id)
        {
            ViewBag.nazarat=db.Tbl_Comments.Where(a=>a.Id == Id).ToList();
            return View();
        }
        public IActionResult Answer(Vm_Questions Q)
        {
            var nazar=db.Tbl_Comments.Where(a=>a.Id.ToString()==Q.Id).SingleOrDefault();
            nazar.Answer=Q.Answer;
            nazar.State=true;
            db.Tbl_Comments.Update(nazar);
            db.SaveChanges();

            return RedirectToAction("index");
        }
        
    }
}