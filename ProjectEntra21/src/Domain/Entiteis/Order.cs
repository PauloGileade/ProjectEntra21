using System;
using System.Collections.Generic;

namespace ProjectEntra21.Domain.Entiteis
{
    public class Order
    {
        public DateTime Data { get; set; }
        public Employeer Employeer { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
        public Cell Cell { get; set; }
        public int AmountEnter { get; set; }
        public int AmountFinished { get; set; }
    }
}
