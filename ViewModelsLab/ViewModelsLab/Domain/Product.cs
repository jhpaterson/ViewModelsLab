using System.ComponentModel.DataAnnotations;

namespace ViewModelsLab.Domain
{
    public class Product
    {
        [Key]
        public int id{get; set;}
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}