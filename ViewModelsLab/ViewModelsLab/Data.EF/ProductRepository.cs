using System.Collections.Generic;
using System.Linq;
using ViewModelsLab.Domain;

namespace ViewModelsLab.Data.EF
{
    public class ProductRepository : IProductRepository
    {
        private EFContext _unitOfWork;

        public ProductRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as EFContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _unitOfWork.Products.ToList(); ;
        }

        public Product Get(string name)
        {
            return _unitOfWork.Products.Where(p => p.Name == name).FirstOrDefault();
        }
    }
}