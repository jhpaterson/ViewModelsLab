
using System.Collections.Generic;
using System.Linq;


namespace ViewModelsLab.Domain
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product Get(string name);
    }
}