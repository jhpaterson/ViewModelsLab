using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ViewModelsLab.Domain
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<OrderLineItem> OrderLineItems { get; set; }

        public void AddOrderLineItem(Product product, int quantity)
        {
            OrderLineItems.Add(new OrderLineItem { Product = product, Quantity = quantity });
        }

        public decimal GetTotal()
        {
            return OrderLineItems.Sum(li => li.GetTotal());
        }
    }
}