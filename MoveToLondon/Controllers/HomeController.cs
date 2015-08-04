using MoveToLondon.Logic;
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
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (Session["IsEnglishVersion"] == null)
            {
                Session["IsEnglishVersion"] = true;
            }
            return View();
        }

        public ActionResult Main(string version)
        {
            if (version.ToLower().Equals("english"))
            {
                Session["IsEnglishVersion"] = true;    
            }
            else if (version.ToLower().Equals("french"))
            {
                Session["IsEnglishVersion"] = false;
            }

            return RedirectToAction("Index");
        }
        
        public ActionResult OnlineBooking()
        {
            RoomContext rc = new RoomContext();
            OnlineBooking ob = new Models.OnlineBooking();

            //ob.Rooms = rc.Rooms.ToList();
            ob.Rooms = GetListOfRooms();
            return View(ob);
        }

        private List<Room> GetListOfRooms()
        {
            string serverMapPath = Server.MapPath(@"/");
            string filepath = Convert.ToBoolean(Session["IsEnglishVersion"]) ? serverMapPath + ConfigurationManager.AppSettings["EnglishRoomDataFilePath"].ToString()
                : serverMapPath + ConfigurationManager.AppSettings["FrenchRoomDataFilePath"].ToString();
            string line = string.Empty;
            List<Room> roomsList = new List<Room>();
            int roomsCounter = -1;
            bool isDescriptionStarted = false;
            string description = string.Empty;
            bool isPathsStarted = false;

            using (StreamReader sr = new StreamReader(filepath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    
                    if (line.StartsWith("***"))
                    {
                        Room room = new Room();
                        roomsList.Add(room);
                        roomsCounter++;
                        isPathsStarted = false;
                        continue;
                    }
                    if (line.Trim().ToLower().StartsWith("title:"))
                    {
                        roomsList[roomsCounter].Title = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        continue;
                    }
                    if (line.Trim().ToLower().StartsWith("address:"))
                    {
                        roomsList[roomsCounter].Address = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        continue;
                    }
                    if (line.Trim().ToLower().StartsWith("rentpermonth:"))
                    {
                        int rent = 0;
                        int.TryParse(line.Trim().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1], out rent);
                        roomsList[roomsCounter].RentPerMonth = rent;
                        continue;
                    }
                    if (line.Trim().ToLower().StartsWith("description:"))
                    {
                        
                        isDescriptionStarted = true;
                        description += line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        continue;
                    }
                    if (line.Trim().ToLower().StartsWith("photospaths:"))
                    {
                        isDescriptionStarted = false;
                        roomsList[roomsCounter].Description = description;
                        description = string.Empty;
                        isPathsStarted = true;
                        continue;
                    }
                    if (isDescriptionStarted)
                    {
                        
                        description += "\n" + line;
                    }
                    if (isPathsStarted)
                    {
                        RoomPhoto rf = new RoomPhoto();
                        rf.Path = line.Trim();
                        if (roomsList[roomsCounter].ListRoomPhoto == null)
                            roomsList[roomsCounter].ListRoomPhoto = new List<RoomPhoto>();
                        roomsList[roomsCounter].ListRoomPhoto.Add(rf);
                    }

                } 
            }

            return roomsList;
        }
        //public ActionResult BookRoom_ButtonClick()
        //{
        //    NVPAPICaller payPalCaller = new NVPAPICaller();
        //    string retMsg = "";
        //    string token = "";
        //    Session["payment_amt"] = 150;
        //    if (Session["payment_amt"] != null)
        //    {
        //        string amt = Session["payment_amt"].ToString();

        //        bool ret = payPalCaller.ShortcutExpressCheckout(amt, ref token, ref retMsg);
        //        if (ret)
        //        {
        //            Session["token"] = token;
        //            Response.Redirect(retMsg);
        //            RedirectToAction("TransactionError", "Home");
        //        }
        //        else
        //        {
        //            RedirectToAction("TransactionError","Home");
        //        }
        //    }
        //    else
        //    {
        //        RedirectToAction("TransactionError", "Home");
        //    }
        //}

        //public ActionResult TransactionReview()
        //{
        //    NVPAPICaller payPalCaller = new NVPAPICaller();

        //    string retMsg = "";
        //    string token = "";
        //    string PayerID = "";
        //    NVPCodec decoder = new NVPCodec();
        //    token = Session["token"].ToString();

        //    bool ret = payPalCaller.GetCheckoutDetails(token, ref PayerID, ref decoder, ref retMsg);
        //    if (ret)
        //    {
        //        Session["payerId"] = PayerID;

        //        var myOrder = new Order();
        //        myOrder.OrderDate = Convert.ToDateTime(decoder["TIMESTAMP"].ToString());
        //        myOrder.Username = User.Identity.Name;
        //        myOrder.FirstName = decoder["FIRSTNAME"].ToString();
        //        myOrder.LastName = decoder["LASTNAME"].ToString();
        //        myOrder.Address = decoder["SHIPTOSTREET"].ToString();
        //        myOrder.City = decoder["SHIPTOCITY"].ToString();
        //        myOrder.State = decoder["SHIPTOSTATE"].ToString();
        //        myOrder.PostalCode = decoder["SHIPTOZIP"].ToString();
        //        myOrder.Country = decoder["SHIPTOCOUNTRYCODE"].ToString();
        //        myOrder.Email = decoder["EMAIL"].ToString();
        //        myOrder.Total = Convert.ToDecimal(decoder["AMT"].ToString());

        //        // Verify total payment amount as set on CheckoutStart.aspx.
        //        try
        //        {
        //            decimal paymentAmountOnCheckout = Convert.ToDecimal(Session["payment_amt"].ToString());
        //            decimal paymentAmoutFromPayPal = Convert.ToDecimal(decoder["AMT"].ToString());
        //            if (paymentAmountOnCheckout != paymentAmoutFromPayPal)
        //            {
        //                return View("TransactionError");
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            return View("TransactionError");
        //        }

        //        // Get DB context.
        //        RoomContext _db = new RoomContext();

        //        // Add order to DB.
        //        _db.Orders.Add(myOrder);
        //        _db.SaveChanges();

        //        // Get the shopping cart items and process them.
        //        //using (WingtipToys.Logic.ShoppingCartActions usersShoppingCart = new WingtipToys.Logic.ShoppingCartActions())
        //        //{
        //        //  List<CartItem> myOrderList = usersShoppingCart.GetCartItems();

        //        //  // Add OrderDetail information to the DB for each product purchased.
        //        //  for (int i = 0; i < myOrderList.Count; i++)
        //        //  {
        //        // Create a new OrderDetail object.
        //        var myOrderDetail = new OrderDetail();
        //        myOrderDetail.OrderId = myOrder.OrderId;
        //        myOrderDetail.Username = User.Identity.Name;
        //        myOrderDetail.ProductId = 1;//myOrderList[i].ProductId;
        //        myOrderDetail.Quantity = 1;//myOrderList[i].Quantity;
        //        myOrderDetail.UnitPrice = 50;//myOrderList[i].Product.UnitPrice;

        //        // Add OrderDetail to DB.
        //        _db.OrderDetails.Add(myOrderDetail);
        //        _db.SaveChanges();
        //        //}

        //        // Set OrderId.
        //        Session["currentOrderId"] = myOrder.OrderId;

        //        // Display Order information.
        //        //List<Order> orderList = new List<Order>();
        //        //orderList.Add(myOrder);
        //        //ShipInfo.DataSource = orderList;
        //        //ShipInfo.DataBind();

        //        //// Display OrderDetails.
        //        //OrderItemList.DataSource = myOrderList;
        //        //OrderItemList.DataBind();
        //        //}
        //    }
        //    else
        //    {
        //        return View("TransactionError");
        //    }

        //    return View();
        //}

        //public ActionResult TransactionError()
        //{
        //    return View();
        //}
    }
}
