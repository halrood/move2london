using MoveToLondon.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoveToLondon.Controllers
{
    public class PayPalController : Controller
    {
        //[Authorize(Roles="Customers")]
        public ActionResult ValidateCommand(string product)
        {
            string totalPrice = "150";
            bool useSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSandbox"]);
            var paypal = new PayPalModel(useSandbox);

            paypal.item_name = product;
            paypal.amount = totalPrice;
            return View("TransactionReview", paypal);
        }

        public ActionResult TransactionComplete()
        {
            return View("");
        }

        public ActionResult TransactionCancel()
        {
            return View();
        }

        public ActionResult TransactionNotify()
        {
            return View();
        }

        //<add key="business" value="asrce2_1311074442_biz@gmail.com" />
    }
}
