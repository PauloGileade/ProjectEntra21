using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Domain.Enums;

namespace ProjectEntra21.src.Application.ViewModels
{
    public class CellEmployeerViewModel
    {
        public long Code { get; set; }
        public long Cell { get; set; }
        public long RegisterEmployeer { get; set; }
        public string NameEmployeer { get; set; }
        public string Office { get; set; }
        public string LevelEmployeer { get; set; }
        public string Phase { get; set; }
    }
}
