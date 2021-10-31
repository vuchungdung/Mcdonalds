using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(256)]
        public string CustomerName { set; get; }
        [Required]
        [MaxLength(256)]
        public string CustomerAddress { set; get; }
        [Required]
        [MaxLength(256)]
        public string CustomerEmail { set; get; }
        [Required]
        [MaxLength(50)]
        public string CustomerMobile { set; get; }
        public DateTime CreatedDate { set; get; }
        public int CreatedBy { set; get; }
        public int Status { set; get; }
        public float Total { get; set; }
    }
}
