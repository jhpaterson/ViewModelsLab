using System.Web.Mvc;
using ViewModelsLab.Domain;
using ViewModelsLab.Models;
using AutoMapper;

namespace ViewModelsLab.Controllers
{
    public class OrdersController : Controller
    {
        private IOrderRepository orderRepository;
        private IProductRepository productRepository;

        public OrdersController(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }


        public ActionResult Index()
        {
            var orders = orderRepository.GetAll();

            return View(orders);
        }

        public ActionResult OrderDetail(int? id)
        {
            var order = id != null ? orderRepository.Get(id.Value) : null;

            if (order == null)
            {
                return View("Index");
            }

            // with AutoMapper - see configuration class in Mappings folder
            OrderViewModel orvm = Mapper.Map<Order, OrderViewModel>(order);

            // without AutoMapper
            //OrderViewModel orvm = new OrderViewModel();
            //orvm.id = order.id;
            //orvm.CustomerName = order.Customer.Name;
            //foreach (OrderLineItem oli in order.GetOrderLineItems())
            //{
            //    orvm.AddOrderLineItem(string.Format("{0}: Quantity - {1}", oli.Product.Name, oli.Quantity));
            //}
            //orvm.Total = order.GetTotal();

            return View(orvm);
        }

        [HttpGet]
        public ActionResult AddItem(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }

            AddOrderLineItemViewModel aolivm =
               new AddOrderLineItemViewModel
               {
                   OrderId = id.Value,
                   ProductList = new SelectList(
                       productRepository.GetAll(),
                       "Name",
                       "Name")
               };
            return View(aolivm);
        }

        [HttpPost]
        public ActionResult AddItem(AddOrderLineItemViewModel aolivm)
        {
            if (ModelState.IsValid)
            {
                var product = productRepository.Get(aolivm.ProductName);
                var order = orderRepository.Get(aolivm.OrderId);

                order.AddOrderLineItem(product, aolivm.Quantity.Value);

                orderRepository.Save(order);

                return RedirectToAction("OrderDetail", new { id = aolivm.OrderId });
            }
            else
            {
                aolivm.ProductList = new SelectList(
                       productRepository.GetAll(),
                       "Name",
                       "Name");
                return View(aolivm);
            }
        }
    }
}
