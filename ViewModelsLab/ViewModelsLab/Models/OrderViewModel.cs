using System.Collections.Generic;
using System.ComponentModel;

namespace ViewModelsLab.Models
{
    public class OrderViewModel
    {   
        private List<string> _orderLineItems;

        public OrderViewModel()
        {
            _orderLineItems = new List<string>();
        }

        [DisplayName("Order Number:")]
        public int id { get; set; }

        [DisplayName("Customer Name:")]
        public string CustomerName{get; set;}

        public List<string> OrderLineItems { get { return _orderLineItems; } }

        public void AddOrderLineItem(string item)
        {
            _orderLineItems.Add(item);
        }

        [DisplayName("Total Cost:")]
        public decimal Total { get; set; }
    }
}