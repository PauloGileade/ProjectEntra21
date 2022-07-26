using System;
using System.Collections.Generic;

namespace ProjectEntra21.Domain.Entiteis
{
    public class Order
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public Employeer Employeer { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public Cell Cell { get; set; }
        public int AmountEnter { get; set; }
        public int AmountFinished { get; set; }
    }
}
