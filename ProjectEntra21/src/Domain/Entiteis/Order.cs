using ProjectEntra21.src.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectEntra21.src.Domain.Entiteis
{
    public class Order : PatternEntity
    {
        public long Code { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public Employeer Employeer { get; set; }
        public Product Product { get; set; }
        public Cell Cell { get; set; }
        public int AmountEnter { get; set; }
        public int AmountFinished { get; set; }
    }
}
