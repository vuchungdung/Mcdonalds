using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("Functions")]
    public class Function
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "VARCHAR(50)")]
        [Required]
        public string Url { get; set; }
        public int ParentId { get; set; }
        [Required]
        public int Sort { get; set; }  
    }
}
