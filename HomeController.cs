using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SchoolProject.Models;
namespace SchoolProject.Controllers
{
    public class HomeController : Controller
    {
        TestDBEntities db = new TestDBEntities();
        
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }
      
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(People person)
        {
            People p = new People()
            {
                UserName=person.UserName,
                Password=person.Password
            };
            db.People.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(People person)
        {
            var n = db.People.FirstOrDefault(l => l.UserName == person.UserName && l.Password == person.Password);
         
            if (n != null)
            {
                return View("Login2",n);
            }
            else
            {
                return HttpNotFound();
            }
         
        }
    }
}