using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ParentId { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "NVARCHAR(500)")]
        [Required]
        public string Description { get; set; }
    }
}
