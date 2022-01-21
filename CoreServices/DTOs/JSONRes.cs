using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.DTOs
{
    public class JSONRes <T>
    {
        public int Count { get; set; }
        public List<T> Results { get; set; }
    }
}
