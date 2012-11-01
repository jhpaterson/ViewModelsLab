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
        public EFContext()
            : base("name = efcontext")
        { 
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}