using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;
using hampadco.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ViewModelLayer.Entities.Users;

namespace hampadco.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize]
    public class ProfileController : BaseController
    {
        public ProfileController (HampadcoContext _db, IWebHostEnvironment env) : base (_db, env)
        {

        }
        public IActionResult Index ()
        {
            menu.resiver = db.Tbl_Messages.Where (a => a.StateMess == false && a.SenderMess != "admin").Count ();
            menu.sender = db.Tbl_Messages.Where (a => a.StateMess == false && a.SenderMess == "admin").Count ();
            var user = db.Tbl_Users.Where (a => a.UserName == "admin").SingleOrDefault ();
            if (user != null)
            {
                menu.img = user.ProfileImage;
            }
            if (eror != null)
            {
                ViewBag.err = eror;
                eror = null;
            }
            var quser = db.Tbl_Users.Where (a => a.UserName == "admin").SingleOrDefault ();
            Vm_User us = new Vm_User ()
            {
                UserName = quser.UserName,
                Phone = quser.Phone,
                ProfileImage = quser.ProfileImage,
                Password = quser.Password,
                Address = quser.Address,
            };
            return View (us);
        }

        public async Task<IActionResult> add (Vm_User us)
        {
            if (us.img != null)
            {
                string FileExtension1 = Path.GetExtension (us.img.FileName);
                NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream (path, FileMode.Create))
                {
                    await us.img.CopyToAsync (stream);
                }
                var quser = db.Tbl_Users.Where (a => a.UserName == "admin").SingleOrDefault ();
                quser.Phone = us.Phone;
                quser.Password = us.Password;
                quser.Address = us.Address;
                quser.ProfileImage = NewFileName;
                quser.Language = "fa";
                db.Tbl_Users.Update (quser);
                db.SaveChanges ();

                eror = "اطلاعات با موفقیت بروز رسانی شد.";

                return RedirectToAction ("index", "profile", new { Areas = "admin" });
            }
            else 
            {
                var quser = db.Tbl_Users.Where (a => a.UserName == "admin").SingleOrDefault ();
                quser.Phone = us.Phone;
                quser.Password = us.Password;
                quser.Language = "fa";
                quser.Address = us.Address;
                db.Tbl_Users.Update (quser);
                db.SaveChanges ();

                eror = "اطلاعات با موفقیت بروز رسانی شد.";
                
                return RedirectToAction ("index", "profile", new { Areas = "admin" });
            }
        }

    }
}