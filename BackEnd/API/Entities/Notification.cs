using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace API.Entities
{
    [Table("Notifications")]
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
