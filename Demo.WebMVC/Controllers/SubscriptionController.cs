using Demo.Business.Abstract;
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
    public class SubscriptionController : Controller
    {
        ISubscriptionService _subscriptionService;
        IClientService _clients;

        public SubscriptionController(ISubscriptionService subscriptions, IClientService clients)
        {
            _subscriptionService = subscriptions;
            _clients = clients;
        }

        public IActionResult Index(int? id)
        {
            if(User.HasClaim("type" , "client"))
            {
                var clientIdStr = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                id = int.Parse(clientIdStr);
            } 

            var list = id.HasValue ? _subscriptionService.Get(_clients.Find(id.Value)) : _subscriptionService.Get();

            //var found = list.FirstOrDefault(l => l.Invoices.Any());
            return View(list);
        }

        public IActionResult Add(int clientId)
        {
            return View();
        }

        public IActionResult Close(int subscriptionId)
        {
            var subscription = _subscriptionService.Find(subscriptionId);
            var result = _subscriptionService.Close(subscription);

            if(result == SubscriptionCloseResult.Success)
            {
                ViewData["message"] = "Subscription Closed";
            }else
            {
                ViewData["error"] = true;
                ViewData["message"] = "Subscription Close Error " + result;
            }

            return View(subscription);
        }

        public IActionResult Open(int subscriptionId)
        {
            var subscription = _subscriptionService.Find(subscriptionId);
            var result = _subscriptionService.Open(subscription);
 
            return Redirect("Index");
        }
    }
}
