using Demo.Business.Abstract;
using Demo.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Demo.WebMVC.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        IInvoiceService _invoiceService;
        IPayService _payService;

        public InvoiceController(IInvoiceService invoiceService, IPayService payService)
        {
            this._invoiceService = invoiceService;
            this._payService = payService;
        }

        public ActionResult Index(int? subscriptionId, int? clientId, int? invoiceId)
        {
            if (User.HasClaim("type", "client"))
            {
                var clientIdStr = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
                clientId = int.Parse(clientIdStr);

                subscriptionId = invoiceId = null;
            }

            IList<Invoice> invoices = null;

            if (invoiceId.HasValue)
            {
                var found = _invoiceService.Find(invoiceId.Value);
                if (found != null)
                    invoices = new[] { found };
            }
            else
            if (subscriptionId.HasValue)
            {
                invoices = _invoiceService.GetListBySubscriptionId(subscriptionId.Value);
            }
            else
            if (clientId.HasValue)
            {
                invoices = _invoiceService.GetListByClientId(clientId.Value);
            }
            else
            {
                invoices = _invoiceService.GetList();
            }

            return View(invoices);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="paymentPredentials">credentials actually not implemented </param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Pay(int? invoiceId  , PaymentPredentials paymentPredentials)
        {
            if (invoiceId.HasValue)
            {
                var managerId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

                PaymentResult result = null;
                if (managerId != null && int.TryParse(managerId, out var id))
                {
                    result = _payService.Pay(invoiceId.Value, paymentPredentials, PaymentMethod.ByManager, id);
                }
                else
                {
                    result = _payService.Pay(invoiceId.Value, paymentPredentials, PaymentMethod.ByClient, 0);
                }

                if (result.Status != PaymentStatus.Success)
                {
                    ViewData["error"] = "Error during payment, status:" + result.Status;
                }

                return View(result.Payment);
            }
            else
            {
                ViewData["error"] = "Invoice id is empty";
                return View("Invoice id is empty");
            }
        }


    }

}
