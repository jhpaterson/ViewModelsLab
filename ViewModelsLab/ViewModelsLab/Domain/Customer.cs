using System.ComponentModel.DataAnnotations;

namespace ViewModelsLab.Domain
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
    }
}