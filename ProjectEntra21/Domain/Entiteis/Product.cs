using ProjectEntra21.Domain.Enums;

namespace ProjectEntra21.Domain.Entiteis
{
    public class Product
    {
        public long Id { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public int MyProperty { get; set; }
        public TypeBag TypeBag { get; set; }
    }
}
