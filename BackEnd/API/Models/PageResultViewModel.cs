using System.Collections.Generic;

namespace API.Models
{
    public class PageResultViewModel<T>
    {
        public int Total { get; set; }
        public List<T> Records { get;set; }
    }
}
