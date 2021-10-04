using System.Linq;
using DataLayer.Entities.Richat;
using DataLayer.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ViewModelLayer.Entities.Richat;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class RayChatController : BaseController
    {
        public RayChatController(HampadcoContext _db, IWebHostEnvironment env) :base(_db, env)
        {

        }
        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
            var list = db.Tbl_Richats.SingleOrDefault();
            if (list != null)
            {
                var qlist = new Vm_Richat()
                {
                    ScriptChat = list.ScriptChat,
                    Zarinpal = list.Zarinpal,
                    Website = list.Website,
                    Enemad = list.Enemad,
                    Sms = list.Sms,
                    Phone = list.Phone,
                    Paternsms = list.Paternsms
                };
                return View(qlist);
            }

            return View();
        }

        public IActionResult add(Vm_Richat soc)
        {
            var listp = db.Tbl_Richats.SingleOrDefault();
            if (listp != null)
            {
                listp.ScriptChat = soc.ScriptChat;
                listp.Zarinpal = soc.Zarinpal;
                listp.Website = soc.Website;
                listp.Enemad = soc.Enemad;
                listp.Sms = soc.Sms;
                listp.Phone = soc.Phone;
                listp.Paternsms = soc.Paternsms;
                db.Tbl_Richats.Update (listp);
                db.SaveChanges();

                err = "اطلاعات با موفقیت بروز رسانی شد";
            }
            else
            {
                var social =new Tbl_Richat()
                {
                    ScriptChat = soc.ScriptChat,
                    Zarinpal = soc.Zarinpal,
                    Website = soc.Website,
                    Enemad = soc.Enemad,
                    Sms = soc.Sms,
                    Paternsms = soc.Paternsms
                };

                db.Tbl_Richats.Add (social);
                db.SaveChanges();
                err = "اطلاعات با موفقیت ثبت شد";
            }
            return RedirectToAction("index");
        }
        
    }
}
