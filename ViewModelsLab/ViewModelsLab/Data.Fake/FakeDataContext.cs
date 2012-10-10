using System.Collections.Generic;
using System.Linq;
using ViewModelsLab.Domain;


namespace ViewModelsLab.Data.Fake
{
    /// <summary>
    /// simulates a data context
    /// </summary>
    public class FakeDataContext
    {
        public static List<Customer> customers = new List<Customer>();
        public static List<Order> orders = new List<Order>();
        public static List<Product> products = new List<Product>();

        public static void SetupData()
        {
            customers.Add(new Customer
            {
                Name = "Fernando Alonso"
            });

            orders.Add(new Order
                {
                    id = 1,
                    Customer = customers[0]
                });
            orders.Add(new Order
            {
                id = 2,
                Customer = customers[0]
            });

            var widget = new Product
                {
                    Name = "Widget",
                    Price = 4.99m
                };
            var gadget = new Product
            {
                Name = "Gadget",
                Price = 6.99m
            };

            var gizmo = new Product
            {
                Name = "Gizmo",
                Price = 8.99m
            };

            products.Add(widget);
            products.Add(gadget);
            products.Add(gizmo);

            orders[0].AddOrderLineItem(widget, 15);
            orders[0].AddOrderLineItem(gizmo, 5);
        }

        public IQueryable<Order> Orders
        {
            get
            {
                return orders.AsQueryable();
            }
        }

        public IQueryable<Product> Products
        {
            get
            {
                return products.AsQueryable();
            }
        }

        public IQueryable<Customer> Customers
        {
            get
            {
                return customers.AsQueryable();
            }
        }

        public void Add(Order order)
        {
            orders.Add(order);
        }
       
    }
}