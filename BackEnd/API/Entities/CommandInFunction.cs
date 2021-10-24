using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("CommandInFunctions")]
    public class CommandInFunction
    {
        [Key]
        [Column(Order =1)]
        public int CommandId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int FunctionId { get; set; }
    }
}
