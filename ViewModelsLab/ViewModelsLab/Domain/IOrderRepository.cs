using System.Collections.Generic;
using System.Linq;

namespace ViewModelsLab.Domain
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();

        Order Get(int id);

        void Save(Order order);

    }
}