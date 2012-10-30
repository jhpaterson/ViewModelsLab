using System;
using System.Linq;
using System.Data.Entity;
using ViewModelsLab.Domain;


namespace ViewModelsLab.Data.EF
{
    /// <summary>
    /// simulates a data context
    /// </summary>
    public class EFContext : DbContext, IUnitOfWork
    {
        private int _identifier;   // just to demonstrate per request instantiation

        public EFContext()
            : base("name = efcontext")
        { 
            this.Configuration.LazyLoadingEnabled = true;
            _identifier = new Random().Next(1000);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}