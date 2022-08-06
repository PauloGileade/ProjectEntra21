using ProjectEntra21.src.Domain.Common;
using System.Collections.Generic;

namespace ProjectEntra21.src.Domain.Entiteis
{
    public class CellEmployeer : PatternEntity
    {
        public long Code { get; set; }
        public int CodeCell { get; set; }
        public long RegisterEmployeer { get; set; }
    }
}

