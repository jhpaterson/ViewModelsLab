using System.Collections.Generic;
using System.Linq;
using ViewModelsLab.Domain;

namespace ViewModelsLab.Data.Fake
{
    public class OrderRepository : IOrderRepository
    {
        private FakeDataContext db = new FakeDataContext();

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public Order Get(int id)
        {
            return db.Orders.Where(o => o.id == id).FirstOrDefault();
        }

        public void Save(Order order)
        {
            var result = db.Orders.Where(o => o.id == order.id).ToList().Count;
            if (result <= 0) db.Add(order);
        }
    }
}