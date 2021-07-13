using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName ="NVARCHAR(100)")]
        [Required]
        public string FullName { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        [Required]
        public string UserName { get; set; }
        [Column(TypeName = "NVARCHAR(100)")]
        [Required]
        public string Password { get; set; }
        [Column(TypeName = "VARCHAR(250)")]
        [Required]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR(20)")]
        [Required]
        public string Phone { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Column(TypeName = "NVARCHAR(500)")]
        [Required]
        public string Image { get; set; }
    }
}
