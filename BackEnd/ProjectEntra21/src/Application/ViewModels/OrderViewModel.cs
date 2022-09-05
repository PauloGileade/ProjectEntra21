using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Domain.Enums;
using System;

namespace ProjectEntra21.src.Application.ViewModels
{
    public class OrderViewModel
    {
        public long CodeCell { get; set; }
        public long CodeProduct { get; set; }
        public string NameProduct { get; set; }
        public long RegisterEmployeer { get; set; }
        public string NameEmployeer { get; set; }
        public int AmountEnter { get; set; }
        public int? AmountFinished { get; set; }
        public string CreatAt { get; set; }
        public string Phase { get; set; }
    }
}
