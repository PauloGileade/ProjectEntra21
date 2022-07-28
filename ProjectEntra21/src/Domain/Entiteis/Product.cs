using ProjectEntra21.src.Domain.Enums;

namespace ProjectEntra21.src.Domain.Entiteis
{
    public class Product
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public TypeBag TypeBag { get; set; }
    }
}
