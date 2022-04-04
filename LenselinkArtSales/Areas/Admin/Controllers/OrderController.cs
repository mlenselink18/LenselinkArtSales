using LenselinkArtSales.Models;
using Microsoft.AspNetCore.Mvc;

namespace LenselinkArtSales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private ArtSalesContext context;

        public OrderController(ArtSalesContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            List<Order> orders = context.Orders
                    .OrderBy(p => p.Id).ToList();

            List<OrderListViewModel> modelList = new List<OrderListViewModel>();

            foreach (var order in orders)
            {
                var OrderItems = context.OrderItems.Where(r => order.Id.Equals(r.OrderId));
                var customer = new User();
                var user = context.Users.FirstOrDefault(p => p.Id == order.CustomerId);
                if (user != null)
                    customer = user;
                var orderItemCount = OrderItems.Count();
                var ListViewItem = new OrderListViewModel
                {
                    order = order,
                    customer = customer,
                    orderItems = OrderItems.ToList(),
                    orderItemCount = orderItemCount
                };
                modelList.Add(ListViewItem);
            }

            return View(modelList);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Order order = context.Orders.FirstOrDefault(p => p.Id == id);

            var model = new OrderItemListViewModel();
            var OrderItems = context.OrderItems.Where(r => order.Id.Equals(r.OrderId));
            //var product = context.Products.FirstOrDefault(r => r.Id == item.ItemId);
            List<OrderItemProduct> itemProductList = new List<OrderItemProduct>();
            foreach(var item in OrderItems)
            {
                var newListItem = new OrderItemListViewModel();
                newListItem.order = order;
                var product = context.Products.FirstOrDefault(p => p.Id == item.ItemId);
                var newItemProduct = new OrderItemProduct();
                newItemProduct.orderItem = item;
                newItemProduct.product = product;
                itemProductList.Add(newItemProduct);
            }
            model.ItemsProducts = itemProductList;
            //OrderItemsListView.order = order;
            //OrderItemsListView.orderItems = OrderItems.ToList();

            ViewBag.sizes = context.PrintSizes.ToList();
            ViewBag.Order = order;
            //ViewBag.OrderItemsList = OrderItemsListView;
            ViewBag.Action = "Update";
            //ViewBag.Categories = categories;

            return View("AddUpdate", model);
        }

        [HttpGet]
        public IActionResult AddOrder()
        {
            Order order = new Order();
            var customers = context.Users;

            ViewBag.Action = "Add";
            ViewBag.Customers = customers;

            return View("AddOrder", order);
        }

        [HttpGet]
        public IActionResult AddOrderItem()
        {
            OrderItem orderItem = new OrderItem();
            var products = context.Products;

            ViewBag.Action = "Add";
            ViewBag.Products = products;

            return View("AddOrderItem", orderItem);
        }
    }
}
