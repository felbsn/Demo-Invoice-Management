using Demo.Business.Abstract;
using Demo.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Demo.WebMVC.Controllers
{
    [Authorize]
    public class PayController : Controller
    {

        IPayService _payService;

        public PayController(IPayService payService)
        {
            _payService = payService;
        }

        public IActionResult Index(int invoiceId)
        {
            return View();
        }


        [HttpPost]
        public IActionResult Pay(int invoiceId)
        {
            var managerId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (managerId != null)
            {
                if (int.TryParse(managerId, out var id))
                {
                    _payService.Pay(invoiceId, PaymentMethod.ByManager, id);
                    ViewBag.Success = true;
                }
            }

            return Ok();
        }
    }
}
