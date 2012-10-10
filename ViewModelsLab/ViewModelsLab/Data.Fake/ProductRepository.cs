using System.Collections.Generic;
using System.Linq;
using ViewModelsLab.Domain;

namespace ViewModelsLab.Data.Fake
{
    public class ProductRepository : IProductRepository
    {
        private FakeDataContext db = new FakeDataContext();

        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList(); ;
        }

        public Product Get(string name)
        {
            return db.Products.Where(p => p.Name == name).FirstOrDefault();
        }
    }
}