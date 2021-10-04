using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataLayer.Context;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer.Entities.Message;
using ViewModelLayer.Entities.Message;

namespace hampadco.Areas.Admin.Controllers
{

    [Area("Admin")]
    // [Authorize]
    public class MsgController : BaseController
    {
        public MsgController(HampadcoContext _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }

        public IActionResult Index()
        {
            var logo=db.Tbl_Logos.Where(a=>a.Language==ln).SingleOrDefault();
            if (logo != null)
            {
                ViewBag.logo=logo.ImageLogo;
                ViewBag.Title=logo.TitleLogo;
                 
            }
            else
            {
                ViewBag.logo=null;
                ViewBag.Title=null;
            }
            
           var social=db.Tbl_SocialNetworks.ToList();

            if (social != null)
            {
                ViewBag.social=social;
                 
            }
            else
            {
                ViewBag.social=null;
            }
            
            var qmenu=db.Tbl_Categorys.ToList();
            if (qmenu != null)
            {
                ViewBag.menu=qmenu;
            }

            if (eror != null)
            {
                ViewBag.err=eror;
                eror=null;
            }
            
            ViewBag.resiver=db.Tbl_Messages.Where(a=>a.StateMess==false && a.SenderMess !="admin").Count();
            ViewBag.sender=db.Tbl_Messages.Where(a=>a.StateMess==false && a.SenderMess=="admin").Count();
            
            var userlist=db.Tbl_Users.OrderByDescending(a=>a.Id).ToList();
            ViewBag.list=new SelectList(userlist,"Id","UserNameUs");

            var quser=db.Tbl_Messages.Where(a=>a.ResiverMess== "admin" ).ToList();
            List<Vm_Message> qlist=new List<Vm_Message>();
            foreach (var item in quser)
            {
                var q=db.Tbl_Users.Where(a =>a.Id==Convert.ToInt32(item.SenderMess)  ).SingleOrDefault();
                Vm_Message us =new Vm_Message()
                {
                    Id=item.Id,
                    SubjectMess=item.SubjectMess,
                    TextMess=item.TextMess,
                    Pathfile=item.Pathfile,
                    datemess=item.DateMess.ToPersianDateString(), 
                    StateMess=item.StateMess,  
                    namesender=q.UserName
                };
                qlist.Add(us);
            }
        
            ViewBag.msg=qlist.OrderByDescending(a=>a.Id).ToList();

            return View();
        }

        public async Task<IActionResult> add_msg(Vm_Message msg)
        {
            ViewBag.resiver=db.Tbl_Messages.Where(a=>a.StateMess==false && a.SenderMess !="admin").Count();
            ViewBag.sender=db.Tbl_Messages.Where(a=>a.StateMess==false && a.SenderMess=="admin").Count();
              
            if (msg.file != null)
            {
                string FileExtension1 = Path.GetExtension(msg.file.FileName);
                NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await msg.file.CopyToAsync(stream);
                }

                Tbl_Message message=new Tbl_Message()
                {
                    SenderMess="admin",
                    ResiverMess=msg.ResiverMess,
                    DateMess=DateTime.Today,
                    SubjectMess=msg.SubjectMess,
                    TextMess=msg.TextMess,
                    StateMess=false,
                    Language="fa",
                    Pathfile=NewFileName
                };
                db.Tbl_Messages.Add(message);
                db.SaveChanges();

                eror="پیام با موفقیت ارسال شد";
            }
            else
            {
                Tbl_Message message=new Tbl_Message()
                {
                    SenderMess="admin",
                    ResiverMess=msg.ResiverMess,
                    DateMess=DateTime.Today,
                    SubjectMess=msg.SubjectMess,
                    TextMess=msg.TextMess,
                    StateMess=false,
                    Language="fa",
                };
                db.Tbl_Messages.Add(message);
                db.SaveChanges();

                eror="پیام با موفقیت ارسال شد";
            }

            return RedirectToAction("index");
        }
    
        public IActionResult Details(int id)
        {
            ViewBag.resiver=db.Tbl_Messages.Where(a=>a.StateMess==false && a.SenderMess !="admin").Count();
            ViewBag.sender=db.Tbl_Messages.Where(a=>a.StateMess==false && a.SenderMess=="admin").Count();

            var userlist=db.Tbl_Users.OrderByDescending(a=>a.Id).ToList();
            ViewBag.list=new SelectList(userlist,"Id","UserNameUs");
            
            var logo=db.Tbl_Logos.Where(a=>a.Language==ln).SingleOrDefault();
            if (logo != null)
            {
                ViewBag.logo=logo.ImageLogo;
                ViewBag.Title=logo.TitleLogo;
            }else
            {
                ViewBag.logo=null;
                ViewBag.Title=null;
            }
            
            var social=db.Tbl_SocialNetworks.ToList();
            if (social != null)
            {
                ViewBag.social=social;
                 
            }
            else
            {
                ViewBag.social=null;
            }

            var qmenu=db.Tbl_Categorys.ToList();
            if (qmenu != null)
            {
                ViewBag.menu=qmenu;
            }

            if (eror != null)
            {
                ViewBag.err=eror;
                eror=null;
            }

            var quser=db.Tbl_Messages.Where(a=>a.Id==id ).ToList();
            List<Vm_Message> qlist=new List<Vm_Message>();
            foreach (var item in quser)
            {
                Vm_Message us =new Vm_Message()
                {
                    Id=item.Id,
                    SubjectMess=item.SubjectMess,
                    TextMess=item.TextMess,
                    Pathfile=item.Pathfile,
                    datemess=item.DateMess.ToPersianDateString(), 
                    StateMess=item.StateMess,
                };
                qlist.Add(us);
            }

            ViewBag.msg=qlist.OrderByDescending(a=>a.Id).ToList();
            var q=db.Tbl_Messages.Where(a=>a.Id==id ).SingleOrDefault();
            q.StateMess=true;
            db.Tbl_Messages.Update(q);
            db.SaveChanges();

            return View();
        }
         
        public IActionResult Detailssnd(int id)
        {
            ViewBag.resiver=db.Tbl_Messages.Where(a=>a.StateMess==false && a.SenderMess !="admin").Count();
            ViewBag.sender=db.Tbl_Messages.Where(a=>a.StateMess==false && a.SenderMess=="admin").Count();
            var userlist=db.Tbl_Users.OrderByDescending(a=>a.Id).ToList();
            ViewBag.list=new SelectList(userlist,"Id","UserNameUs");

            var logo=db.Tbl_Logos.Where(a=>a.Language==ln).SingleOrDefault();
            if (logo != null)
            {
                ViewBag.logo=logo.ImageLogo;
                ViewBag.Title=logo.TitleLogo;
                 
            }
            else
            {
                ViewBag.logo=null;
                ViewBag.Title=null;
            }
            
            var social=db.Tbl_SocialNetworks.ToList();
            if (social != null)
            {
                ViewBag.social=social;
                 
            }
            else
            {
                ViewBag.social=null;
            }

            var qmenu=db.Tbl_Categorys.ToList();
            if (qmenu != null)
            {
                ViewBag.menu=qmenu;
            }

            if (eror != null)
            {
                ViewBag.err=eror;
                eror=null;
            }

            var quser=db.Tbl_Messages.Where(a=>a.Id==id ).ToList();
            List<Vm_Message> qlist=new List<Vm_Message>();
            foreach (var item in quser)
            {
                Vm_Message us =new Vm_Message()
                {
                    Id=item.Id,
                    SubjectMess=item.SubjectMess,
                    TextMess=item.TextMess,
                    Pathfile=item.Pathfile,
                    datemess=item.DateMess.ToPersianDateString(), 
                    StateMess=item.StateMess,               
                
                };
                qlist.Add(us);
            }
            
            ViewBag.msg=qlist.OrderByDescending(a=>a.Id).ToList();
            
            return View();
        }
         
        public IActionResult del(int id)
        {

            var qselect=db.Tbl_Messages.Where(a=>a.Id==id).SingleOrDefault();
            db.Tbl_Messages.Remove(qselect);
            db.SaveChanges();
            eror="پیام با موفقیت حذف شد";

            return RedirectToAction("index");
        }

   public IActionResult send()
        {
            ViewBag.resiver=db.Tbl_Messages.Where(a=>a.StateMess==false && a.SenderMess !="admin").Count();
            ViewBag.sender=db.Tbl_Messages.Where(a=>a.StateMess==false && a.SenderMess=="admin").Count();
            var userlist=db.Tbl_Users.OrderByDescending(a=>a.Id).ToList();
            ViewBag.list=new SelectList(userlist,"Id","UserNameUs");

            var logo=db.Tbl_Logos.Where(a=>a.Language==ln).SingleOrDefault();
            if (logo != null)
            {
                ViewBag.logo=logo.ImageLogo;
                ViewBag.Title=logo.TitleLogo;
                 
            }
            else
            {
                ViewBag.logo=null;
                ViewBag.Title=null;
            }
            
            var social=db.Tbl_SocialNetworks.ToList();
            if (social != null)
            {
                ViewBag.social=social;
                 
            }
            else
            {
                ViewBag.social=null;
            }
            
            var qmenu=db.Tbl_Categorys.ToList();
            if (qmenu != null)
            {
                ViewBag.menu=qmenu;
            }
            
            if (eror != null)
            {
                ViewBag.err=eror;
                eror=null;
            }

            var quser=db.Tbl_Messages.Where(a=>a.SenderMess== "admin").ToList();
            
            List<Vm_Message> qlist=new List<Vm_Message>();
            foreach (var item in quser)
            {
                var q=db.Tbl_Users.Where(a=>a.Id== Convert.ToInt32(item.ResiverMess)).SingleOrDefault();
                Vm_Message us =new Vm_Message()
                {
                    Id=item.Id,
                    SubjectMess=item.SubjectMess,
                    TextMess=item.TextMess,
                    Pathfile=item.Pathfile,
                    datemess=item.DateMess.ToPersianDateString(), 
                    StateMess=item.StateMess, 
                    namesender=q.UserName
                };
                qlist.Add(us);
            }
            ViewBag.msg=qlist.OrderByDescending(a=>a.Id).ToList();

            return View();
        }

    }
}
