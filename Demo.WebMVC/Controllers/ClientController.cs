using Demo.Business.Abstract;
using Demo.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.WebMVC.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }


        [Authorize(Roles = nameof(AccessLevel.Subscription))]
        public IActionResult Index(string taxNo = null, string identitiyNo = null)
        {
            if (taxNo != null || identitiyNo != null)
            {
                var found = taxNo != null ? clientService.FindByTaxNo(taxNo) : clientService.FindByIdentityNo(identitiyNo);
                if (found != null)
                {
                    return View(new[] { found });
                }
                else
                    return View(new Client[] { });
            }
            else
                return View(clientService.GetList());
        }


        public IActionResult Edit(int id)
        {
            return Redirect(nameof(AddCorparate));
        }

        public IActionResult Delete(int id)
        {
            var client = clientService.Find(id);
            if(client != null)
            {
                clientService.Delete(client);
            }

            return Redirect("/Client");
        }

        public IActionResult AddCorparate()
        {
            return View();
        }

        public IActionResult AddIndividual()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCorparate(CorporateClient client)
        {
            clientService.Create(client);
            return Redirect(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddIndividual(IndividualClient client)
        {
            clientService.Create(client);
            return Redirect(nameof(Index));
        }
        public int test { get; set; } = 123;
    }
}
