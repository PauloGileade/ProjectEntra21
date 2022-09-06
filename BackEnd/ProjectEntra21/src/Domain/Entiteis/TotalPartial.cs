using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Enums;

namespace ProjectEntra21.src.Domain.Entiteis
{
    public class TotalPartial : PatternEntity
    {
        public int Total { get; set; }
        public PhaseCell Phase { get; set; }
        public Cell Cell { get; set; }
        public Product Product { get; set; }
    }
}
