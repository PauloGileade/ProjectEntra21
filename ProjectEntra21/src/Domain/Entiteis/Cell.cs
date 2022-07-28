using ProjectEntra21.Domain.Common;
using ProjectEntra21.Domain.Enums;
using System.Collections.Generic;

namespace ProjectEntra21.Domain.Entiteis
{
    public class Cell : PatternEntity
    {
        public int CodeCell { get; set; }
        public StatusCell StatusCell { get; set; }
        public CellEmployeer CellEmployeer { get; set; }
    }
}
