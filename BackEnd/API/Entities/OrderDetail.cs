using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int OrderId { set; get; }
        [Required]
        public int ProductId { set; get; }
        [Required]
        public int Quantity { set; get; }
        [Required]
        public float Price { get; set; }
    }
}
