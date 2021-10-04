using System.Linq;
using DataLayer.Entities.SocialNetwork;
using DataLayer.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ViewModelLayer.Entities.SocialNetwork;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class SocialNetworkController : BaseController
    {
        public SocialNetworkController(HampadcoContext _db,IWebHostEnvironment env) : base(_db, env)
        {

        }
        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }

            var list = db.Tbl_SocialNetworks.SingleOrDefault();
            if (list != null)
            {
                var qlist = new Vm_SocialNetwork()
                {
                    Instagram = list.Instagram,
                    Telegram = list.Telegram,
                    Aparat = list.Aparat,
                    Facebook = list.Aparat,
                    Whatsapp = list.Whatsapp
                };
                return View(qlist);
            }

            return View();
        }

        public IActionResult add(Vm_SocialNetwork soc)
        {
            var listp = db.Tbl_SocialNetworks.SingleOrDefault();
            if (listp != null)
            {
                listp.Instagram = soc.Instagram;
                listp.Aparat = soc.Aparat;
                listp.Facebook = soc.Facebook;
                listp.Telegram = soc.Telegram;
                listp.Whatsapp = soc.Whatsapp;

                db.Tbl_SocialNetworks.Update (listp);
                db.SaveChanges();

                err = "اطلاعات با موفقیت بروز رسانی شد";
            }
            else
            {
                var social = new Tbl_SocialNetwork()
                {
                    Instagram = soc.Instagram,
                    Aparat = soc.Aparat,
                    Facebook = soc.Facebook,
                    Telegram = soc.Telegram,
                    Whatsapp = soc.Whatsapp
                };

                db.Tbl_SocialNetworks.Add (social);
                db.SaveChanges();

                err = "اطلاعات با موفقیت ثبت شد";
            }
            return RedirectToAction("index");
        }
        
    }
}
