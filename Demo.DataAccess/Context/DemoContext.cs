using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataAccess
{
    public class DemoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var str = @"Server=192.168.1.101\SQLEXPRESS,1433;Database=demo;User ID=test;Password=1A3p_iG";

            optionsBuilder
                .UseSqlServer(str);
        }

        public DbSet<Payment> Payments{ get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<IndividualClient> IndividualClients { get; set; }
        public DbSet<CorporateClient> CorporateClients { get; set; }
    }
}
