using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    
    public class adminController : Controller
    {
        //
        // GET: /admin/
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();

            var users = db.Users.ToList();

            ViewBag.usr = users;

            return View();
        }
	}
}