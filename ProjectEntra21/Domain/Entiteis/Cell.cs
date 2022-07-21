using ProjectEntra21.Domain.Enums;
using System.Collections.Generic;

namespace ProjectEntra21.Domain.Entiteis
{
    public class Cell
    {
        public int CodeCell { get; set; }
        public List<Employeer> Employeer { get; set; }
        public StatusCell StatusCell { get; set; }
    }
}
