using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("Products")]

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [Required]
        [MaxLength(256)]
        public string Name { set; get; }
        [Required]
        public int CategoryId { set; get; }
        [MaxLength(256)]
        public string Image { set; get; }
        public float OriginalPrice { get; set; }
        public float Price { set; get; }
        [MaxLength(500)]
        public string Description { set; get; }
        public string Content { set; get; }
        public int Range { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
