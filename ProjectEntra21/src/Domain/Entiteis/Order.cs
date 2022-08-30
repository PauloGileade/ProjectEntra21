using ProjectEntra21.src.Domain.Common;

namespace ProjectEntra21.src.Domain.Entiteis
{
    public class Order : PatternEntity
    {
        public long Code { get; set; }
        public CellEmployeer CellEmployeer { get; set; }
        public Product Product { get; set; }
        public int AmountEnter { get; set; }
        public int? AmountFinished { get; set; }
    }
}
