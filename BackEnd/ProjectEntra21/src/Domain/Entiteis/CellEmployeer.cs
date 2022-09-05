﻿using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Enums;

namespace ProjectEntra21.src.Domain.Entiteis
{
    public class CellEmployeer : PatternEntity
    {
        public long Code { get; set; }
        public Cell Cell { get; set; }
        public Employeer Employeer { get; set; }
        public PhaseCell Phase { get; set; }

    }
}
