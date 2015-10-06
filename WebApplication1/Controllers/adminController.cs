using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize (Roles= "canEdit")]
    
    public class adminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /admin/
        public ActionResult Index()
        {
            //var users = db.Users.ToList();

            var users = from db1 in db.Users where (db1.UserName != User.Identity.Name) select db1 ; 
            
            return View(users.ToList());
        }

        public ActionResult Delete(string id)
        {
            var user = db.Users.Find(id);

            return View(user);
          }

	}
}