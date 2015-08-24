using MoveToLondon.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoveToLondon.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [HttpGet]
        public ActionResult Index()
        {
            Session["IsEnglishVersion"] = true;
            if (Session["UserData"] == null)
            {
                Session["UserData"] = new UserData();
                return RedirectToAction("Login");
            }
            else
            {
                UserData ud = Session["UserData"] as UserData;
                if (ud.IsLoggedIn)
                {
                    RoomData rd = new RoomData();
                    rd.Rooms.Add(new Room());
                    rd.Rooms.Add(new Room());
                    return View("Index", rd);
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
        }

        [HttpPost]
        public ActionResult Index(RoomData _roomdata)
        {
            Session["IsEnglishVersion"] = true;
            _roomdata.Rooms[0].IsFrench = false;
            _roomdata.Rooms[1].IsFrench = true;

            Session["RoomsData"] = _roomdata;
            return View("uploadimages");
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["UserData"] == null)
            {
                Session["UserData"] = new UserData();
            }
            UserData ud = new UserData();
            return View(ud);
        }

        [HttpPost]
        public ActionResult Login(UserData input)
        {
            Models.MoveToLondon mtl = new Models.MoveToLondon();
            UserProfile uf = mtl.UserProfiles.FirstOrDefault();
            UserData ud = Session["UserData"] as UserData;
            string pass = uf.Password;
            if (input.UserName == uf.UserName && input.Password == pass)
            {
                ud.IsLoggedIn = true;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public bool AddImagesToRoom()
        {
            if (IsUserLoggedIn())
            {
                bool isSavedSuccessfully = true;
                try
                {

                    string Name = "";
                    RoomData rd = null;
                    if (Session["RoomsData"] != null)
                    {
                        rd = Session["RoomsData"] as RoomData;
                    }
                    else
                    {
                        return false;
                    }
                    foreach (string fileName in Request.Files)
                    {
                        HttpPostedFileBase file = Request.Files[fileName];
                        Name = file.FileName;

                        if (file != null && file.ContentLength > 0)
                        {
                            string serverMapPath = Server.MapPath(@"/");
                            var originalDirectory = new DirectoryInfo(string.Format("{0}Images", serverMapPath));

                            string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "");
                            string fileName1 = "image_" + DateTime.Now.ToString("dd_MM_hh_mm_ss") + Name;
                            bool doessExists = System.IO.Directory.Exists(pathString);
                            if (!doessExists)
                                System.IO.Directory.CreateDirectory(pathString);
                            var path = string.Format("{0}\\{1}", pathString, fileName1);
                            file.SaveAs(path);
                            string PathForDb = path.Remove(0, serverMapPath.Length);
                            PathForDb = PathForDb.Replace(@"\", "/");
                            RoomPhoto rf = new RoomPhoto();
                            rf.Path = PathForDb;
                            rd.RoomPhotos.Add(rf);

                        }

                    }

                }
                catch (Exception ex)
                {
                    isSavedSuccessfully = false;
                }
                return isSavedSuccessfully;
            }
            else
            {
                return false;
            }
            
        }

        public ActionResult SaveAd()
        {
            if (IsUserLoggedIn())
            {
                try
                {
                    RoomData rd = Session["RoomsData"] as RoomData;
                    if (rd == null)
                    {
                        return RedirectToAction("index", "admin");
                    }

                    Models.MoveToLondon mtl = new Models.MoveToLondon();

                    for (int i = 0; i < rd.Rooms.Count; i++)
                    {
                        for (int j = 0; j < rd.RoomPhotos.Count; j++)
                        {
                            RoomsPhotosBridge rpb = new RoomsPhotosBridge();
                            rpb.Room = rd.Rooms[i];
                            rpb.RoomPhoto = rd.RoomPhotos[j];

                            mtl.Set<RoomsPhotosBridge>().Add(rpb);

                            //rd.Rooms[i].RoomsPhotosBridges.Clear();
                            //rd.RoomPhotos[j].RoomsPhotosBridges.Clear();

                            rd.Rooms[i].RoomsPhotosBridges.Add(rpb);
                            rd.RoomPhotos[j].RoomsPhotosBridges.Add(rpb);
                        }
                    }
                    Room r = mtl.Rooms.ToList().Last();
                    if (r != null)
                    {
                        rd.Rooms[0].RoomSequence = r.ID + 1;
                        rd.Rooms[1].RoomSequence = r.ID + 1;
                    }
                    else
                    {
                        rd.Rooms[0].RoomSequence = 0;
                        rd.Rooms[1].RoomSequence = 0;
                    }


                    foreach (Room room in rd.Rooms)
                    {
                        mtl.Set<Room>().Add(room);
                    }
                    foreach (RoomPhoto photo in rd.RoomPhotos)
                    {
                        mtl.Set<RoomPhoto>().Add(photo);
                    }
                    mtl.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }

                return RedirectToAction("roomslist");
            }
            else
            {
                return RedirectToAction("index");
            }
            
        }

        public ActionResult roomslist()
        {
            if (IsUserLoggedIn())
            {
                RoomData rd = new RoomData();
                Models.MoveToLondon mtl = new Models.MoveToLondon();
                rd.Rooms = mtl.Rooms.Where(o => !o.IsFrench).ToList();
                return View(rd); 
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult DeleteRoom(int roomId, int sequencenumber)
        {

            if (IsUserLoggedIn())
            {
                Models.MoveToLondon mtl = new Models.MoveToLondon();
                List<Room> rooms = mtl.Rooms.Where(o => o.RoomSequence == sequencenumber).ToList();
                List<int> roomids = new List<int>();
                List<int> photoids = new List<int>();
                List<string> photopaths = new List<string>();
                foreach (Room room in rooms)
                {
                    if (!roomids.Contains(room.ID))
                        roomids.Add(room.ID);
                    List<RoomsPhotosBridge> bridges = room.RoomsPhotosBridges.ToList();

                    foreach (RoomsPhotosBridge bridge in bridges)
                    {
                        if (!photoids.Contains(bridge.PhotoId))
                        {
                            photoids.Add(bridge.PhotoId);
                            photopaths.Add(bridge.RoomPhoto.Path);
                        }
                        mtl.Entry(bridge).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                mtl.SaveChanges();
                mtl = null;
                mtl = new Models.MoveToLondon();
                foreach (int id in roomids)
                {
                    Room r = new Room();
                    r.ID = id;
                    mtl.Entry(r).State = System.Data.Entity.EntityState.Deleted;
                }

                foreach (int id in photoids)
                {
                    RoomPhoto rf = new RoomPhoto();
                    rf.ID = id;
                    mtl.Entry(rf).State = System.Data.Entity.EntityState.Deleted;
                }
                //string serverpath = Server.MapPath(@"/");
                //foreach (string path in photopaths)
                //{

                //}
                mtl.SaveChanges();
                return RedirectToAction("roomslist");    
            }
            else
            {
                return RedirectToAction("index");
            }
            
        }

        private bool IsUserLoggedIn()
        {
            bool returnVal = false;

            if (Session["UserData"] == null)
            {
                returnVal = false;
            }
            else
            {
                UserData ud = Session["UserData"] as UserData;
                if (ud.IsLoggedIn)
                {
                    returnVal = true;
                }
                else
                {
                    returnVal = false;
                }
            }

            return returnVal;
        }
    }

    public class UserData
    {
        public bool IsLoggedIn { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserData()
        {
            IsLoggedIn = false;
        }
    }
}
