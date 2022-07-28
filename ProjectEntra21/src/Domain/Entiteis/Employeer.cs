﻿using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ProjectEntra21.src.Domain.Entiteis
{
    public class Employeer : PatternEntity
    {
        public long Register { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string Office { get; set; }
        public LevelEmployeer LevelEmployeer { get; set; }
    }
}
