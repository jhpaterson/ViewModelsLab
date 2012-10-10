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

        //
        // GET: /Orders/

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

            // TODO: complete and return View with view model
        }

        [HttpGet]
        public ActionResult AddItem(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }

            // TODO: create view model for form and return View with view model
        }

        [HttpPost]
        public ActionResult AddItem()    // TODO: insert view model parameter for binding
        {
            if (ModelState.IsValid)
            {
                // TODO: Get product and order from repositories using view model properties, and add product to order, then redirect to order detail
               
            }
            else
            {
                // TODO: update view model with products data and return View with view model
            }
        }

    }
}
