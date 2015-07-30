using MoveToLondon.Logic;
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
            Session["IsEnglishVersion"] = false;
            return View();
        }

        public ActionResult OnlineBooking()
        {
            RoomContext rc = new RoomContext();
            OnlineBooking ob = new Models.OnlineBooking();

            ob.Rooms = rc.Rooms.ToList();
            return View(ob);
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
