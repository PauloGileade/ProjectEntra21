using ProjectEntra21.src.Domain.Entiteis;
using System.Collections.Generic;

namespace ProjectEntra21.src.Application.ViewModels
{
    public class GetCellEmployeerViewModel
    {
        public int Code { get; set; }
        public IList<Employeer> Employeers { get; set; }
        public Cell Cell { get; set; }
    }
}
