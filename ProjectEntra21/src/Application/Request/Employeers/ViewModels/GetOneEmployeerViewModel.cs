using ProjectEntra21.src.Domain.Enums;
using System;

namespace ProjectEntra21.src.Application.Request.Employeers.ViewModels
{
    public class GetOneEmployeerViewModel
    {
        public long Register { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string Office { get; set; }
        public LevelEmployeer LevelEmployeer { get; set; }
    }
}
