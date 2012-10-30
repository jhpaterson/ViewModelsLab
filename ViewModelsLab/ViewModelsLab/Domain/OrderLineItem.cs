using System.ComponentModel.DataAnnotations;

namespace ViewModelsLab.Domain
{
    public class OrderLineItem
    {
        [Key]
        public int id { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal GetTotal()
        {
            return Quantity * Product.Price;
        }
    }
}