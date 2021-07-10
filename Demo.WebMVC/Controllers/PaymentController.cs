using Demo.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.WebMVC.Controllers
{

    [Authorize]
    public class PaymentController : Controller
    {

        IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public IActionResult Index()
        {
            var payments = _paymentService.GetList();
            return View(payments);
        }
    }
}
