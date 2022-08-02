using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Enums;

namespace ProjectEntra21.src.Domain.Entiteis
{
    public class Product : PatternEntity
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public TypeBag Type { get; set; }
        public Employeer Employeer { get; set; }
    }
}
