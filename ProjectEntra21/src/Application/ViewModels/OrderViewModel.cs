using ProjectEntra21.src.Domain.Entiteis;
using System;

namespace ProjectEntra21.src.Application.ViewModels
{
    public class OrderViewModel
    {
        public long Code { get; set; }
        public DateTime Data { get; set; }
        public Employeer Employeer { get; set; }
        public Product Products { get; set; }
        public Cell Cell { get; set; }
        public int AmountEnter { get; set; }
        public int AmountFinished { get; set; }
    }
}
