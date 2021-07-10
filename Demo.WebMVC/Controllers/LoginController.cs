using Demo.Business.Abstract;
using Demo.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Demo.WebMVC.Controllers
{
    public class LoginController : Controller
    {
        IClientService _clients;
        IManagerService _managers;

        public LoginController(IClientService clients, IManagerService managers)
        {
            _clients = clients;
            _managers = managers;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manager()
        {
            return View();
        }


        [HttpPost]
        async public Task<IActionResult> Login(string clientnumber, string password)
        {

            var found = _clients.Find(clientnumber, password);

            if (found != null)
            {
                var claims = new List<Claim>();
                // add manager user name in auth name
                claims.Add(new Claim(ClaimTypes.Name, clientnumber));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, found.Id.ToString()));
                claims.Add(new Claim("type", "client"));


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await this.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
            }else
            {
                ModelState.AddModelError("ClientNumber", "error this thing");
                return Index();
            }

            return Redirect("/");
        }

        [HttpPost]
        async public Task<IActionResult> Manager(string username, string password)
        {
            var manager = _managers.Find(username, password);

            if (manager != null)
            {
                var claims = new List<Claim>();
                // add manager user name in auth name
                claims.Add(new Claim(ClaimTypes.Name, manager.Username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, manager.Id.ToString()));
                claims.Add(new Claim("type", "manager"));


                // get corresponding roles per authorized manager account
                claims.AddRange(
                    Enum.GetValues(typeof(AccessLevel)).
                    Cast<AccessLevel>().
                    Where(level => manager.Level.HasFlag(level)).
                    Select(level => new Claim(ClaimTypes.Role, level.ToString())));

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await this.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity) );

                return Redirect("/");
            }else
            {
                ModelState.AddModelError("Error" , "Incorrect username or password!");
                return View();
            }

        }

        [HttpGet]
        async public Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }

    }
}
