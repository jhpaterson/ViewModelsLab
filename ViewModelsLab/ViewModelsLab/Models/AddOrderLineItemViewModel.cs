using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewModelsLab.Models
{
    public class AddOrderLineItemViewModel
    {
        [DisplayName("Order Number")]
        [HiddenInput(DisplayValue = false)]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "HEY! How many do you want?")]
        [Range(1, 100,ErrorMessage = "Please enter a number between 1 and 100")]
        [DisplayName("How many")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "HEY! Which product")]
        [DisplayName("Product")]
        public string ProductName { get; set; }

        public SelectList ProductList { get; set; }
    }
}