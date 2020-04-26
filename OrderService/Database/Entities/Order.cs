using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Database.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        
    }
}
