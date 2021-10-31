using System;

namespace API.Models
{
    public class ProductViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int CategoryId { set; get; }
        public string Image { set; get; }
        public float OriginalPrice { get; set; }
        public float Price { set; get; }
        public string Description { set; get; }
        public string Content { set; get; }
        public int Range { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
