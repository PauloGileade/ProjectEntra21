using ProjectEntra21.src.Domain.Common;
using System.Collections.Generic;

namespace ProjectEntra21.src.Domain.Entiteis
{
    public class CellEmployeer : PatternEntity
    {
        public int Code { get; set; }
        public Cell Cell { get; set; }
        public IList<Employeer> Employeers { get; set; } = new List<Employeer>();
    }
}

