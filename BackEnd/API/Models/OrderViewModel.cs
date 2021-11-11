using System;
using System.Collections.Generic;

namespace API.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            this.Details = new List<OrderDetailViewModel>();
        }
        public int Id {  get; set; }
        public string CustomerName { set; get; }
        public string CustomerAddress { set; get; }
        public string CustomerEmail { set; get; }
        public string CustomerMobile { set; get; }
        public DateTime CreatedDate { set; get; }
        public int CreatedBy { set; get; }
        public int Status { set; get; }
        public float Total { get; set; }
        public List<OrderDetailViewModel> Details { get; set; }

    }
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public float Price { get; set; }
    }
}
