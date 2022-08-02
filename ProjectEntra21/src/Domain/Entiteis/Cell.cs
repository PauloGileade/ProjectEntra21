using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Enums;
using System.Collections.Generic;

namespace ProjectEntra21.src.Domain.Entiteis
{
    public class Cell : PatternEntity
    {
        public int CodeCell { get; set; }
        public StatusCell StatusCell { get; set; }
    }
}
