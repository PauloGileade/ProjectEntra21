using ProjectEntra21.src.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectEntra21.src.Application.ViewModels
{
    public class GetEmployeerViewModel
    {
        public long Register { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        public string Office { get; set; }
        public LevelEmployeer LevelEmployeer { get; set; }
    }
}
