using ProjectEntra21.Domain.Enums;

namespace ProjectEntra21.Domain.Entiteis
{
    public class Product
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public TypeBag TypeBag { get; set; }
    }
}
