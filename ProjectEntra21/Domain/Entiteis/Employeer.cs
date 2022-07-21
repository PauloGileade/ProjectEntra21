﻿using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.Domain.Common;
using ProjectEntra21.Domain.Enums;
using System;

namespace ProjectEntra21.Domain.Entiteis
{
    public class Employeer : PatternEntity
    {
        public long Id { get; set; }
        public long Register { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string Office { get; set; }
        public LevelEmployeer LevelEmployeer { get; set; }
    }
}