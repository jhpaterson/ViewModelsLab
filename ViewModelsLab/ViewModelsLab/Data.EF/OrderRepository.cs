using System.Collections.Generic;
using System.Linq;
using ViewModelsLab.Domain;

namespace ViewModelsLab.Data.EF
{
    public class OrderRepository : IOrderRepository
    {
        private EFContext _unitOfWork;

        public OrderRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as EFContext;
        }

        public IEnumerable<Order> GetAll()
        {
            return _unitOfWork.Orders.ToList();
        }

        public Order Get(int id)
        {
            return _unitOfWork.Orders
                    .Where(o => o.id == id).FirstOrDefault();

            // use this version for eager loading of associated entities (need to include System.Data.Entity)
            // return _unitOfWork.Orders
            //        .Include(o => o.OrderLineItems)
            //        .Include(o => o.OrderLineItems.Select(ol => ol.Product))
            //        .Include(o => o.Customer)
            //        .Where(o => o.id == id).FirstOrDefault();
        }

        public void Add(Order order)
        {
            _unitOfWork.Orders.Add(order);
            _unitOfWork.SaveChanges();
        }

        public void Update(Order order)
        {
            _unitOfWork.SaveChanges();
        }

    }
}