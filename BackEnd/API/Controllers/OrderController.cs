using API.Entities;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MCDbContext _db;
        public OrderController(MCDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Add(OrderViewModel orderView)
        {
            try
            {
                Order order = new Order();
                order.CustomerName = orderView.CustomerName;
                order.CustomerMobile = orderView.CustomerMobile;
                order.CustomerEmail = orderView.CustomerEmail;
                order.CreatedDate = orderView.CreatedDate;
                order.Status = orderView.Status;
                order.Total = orderView.Total;
                order.CustomerAddress = orderView.CustomerAddress;
                order.CreatedBy = orderView.CreatedBy;

                await _db.Orders.AddAsync(order);
                await _db.SaveChangesAsync();
                foreach(var item in orderView.Details)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderId = order.ID;
                    orderDetail.ProductId = item.ProductId;
                    orderDetail.Price = item.Price;
                    orderDetail.Quantity = item.Quantity;
                    await _db.OrderDetails.AddAsync(orderDetail);
                }
                await _db.SaveChangesAsync();
                return Ok(order.CustomerName);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> Update(OrderViewModel orderView)
        {
            try
            {
                Order order = await _db.Orders.FindAsync(orderView.Id);
                var orderDetail = await _db.OrderDetails.Where(s => s.OrderId == orderView.Id).ToListAsync();
                if (order == null)
                {
                    return BadRequest();
                }
                if (orderDetail == null)
                {
                    return BadRequest();
                }
                order.CustomerMobile = orderView.CustomerMobile;
                order.CustomerEmail = orderView.CustomerEmail;
                order.CustomerAddress = orderView.CustomerAddress;
                order.Status = orderView.Status;
                order.CustomerName = orderView.CustomerName;
                order.Total = orderView.Total;
                _db.Orders.Update(order);
                foreach (var item in orderDetail)
                {
                    _db.OrderDetails.Remove(item);
                }
                foreach (var item in orderView.Details)
                {
                    OrderDetail itemDetail = new OrderDetail();
                    itemDetail.OrderId = item.OrderId;
                    itemDetail.Price = item.Price;
                    itemDetail.Quantity = item.Quantity;
                    itemDetail.ProductId = item.ProductId;
                    await _db.OrderDetails.AddAsync(itemDetail);
                }
                await _db.SaveChangesAsync();
                return Ok(orderView.CustomerName);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> Item(int id)
        {
            Order order = await _db.Orders.FindAsync(id);
            var orderDetail = await _db.OrderDetails.Where(s => s.OrderId == id).Select(s => new OrderDetailViewModel()
            {

            }).ToListAsync();
            OrderViewModel result = new OrderViewModel();
            result.Id = id;
            result.CustomerName = order.CustomerName;
            result.CustomerEmail = order.CustomerEmail;
            result.CustomerAddress = order.CustomerAddress;
            result.CustomerMobile = order.CustomerMobile;
            result.Status = order.Status;
            result.Total = order.Total;
            result.CreatedDate = result.CreatedDate;
            result.Details = orderDetail;
            return Ok(result);
        }
    }
}
