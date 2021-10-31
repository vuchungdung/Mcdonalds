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
        public List<OrderDetailViewModel> Details { get; set; }

    }
    public class OrderDetailViewModel
    {

    }
}
