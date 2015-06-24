using MoveToLondon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoveToLondon.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OnlineBooking()
        {
            RoomContext rc = new RoomContext();
            OnlineBooking ob = new Models.OnlineBooking();

            ob.Rooms = rc.Rooms.ToList();
            return View(ob);
        }
    }
}
