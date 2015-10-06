using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class userController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /user/
        public ActionResult Index()
        {            
            //var users = db.Users.ToList();
            //ViewBag.usr = users;

            ViewBag.name = User.Identity.Name.ToString();

            return View(db.Users.ToList());
        }
	}
}