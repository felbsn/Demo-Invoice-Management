using Demo.Business.Abstract;
using Demo.Business.Concrete;
using Demo.DataAccess.Abstract;
using Demo.DataAccess.Concrete.Ef;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.WebMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSingleton<IClientRepository, ClientRepository>();
            services.AddSingleton<IClientService, ClientManager>();

            services.AddSingleton<IInvoiceRepository, InvoiceRepository>();
            services.AddSingleton<IInvoiceService, InvoiceManager>();

            services.AddSingleton<ISubscriptionRepository, SubscriptionRepository>();
            services.AddSingleton<ISubscriptionService, SubscriptionManager>();

            services.AddSingleton<IPaymentRepository, PaymentRepository>();
            services.AddSingleton<IPaymentService, PaymentManager>();

            services.AddSingleton<IPayService, PayManager>();

            services.AddSingleton<IManagerRepository, ManagerRepository>();
            services.AddSingleton<IManagerService, ManagerManager>();

            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o => o.LoginPath = new PathString("/login"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
