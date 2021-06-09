using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMegaDesk
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public string DeliveryType { get; set; }
        public decimal LessThan1000 { get; set; }
        public decimal Between1000And2000 { get; set; }
        public decimal GreaterThan2000 { get; set; }
    }
}
