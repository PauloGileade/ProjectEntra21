using ProjectEntra21.src.Domain.Enums;

namespace ProjectEntra21.src.Application.ViewModels
{
    public class GetProductViewModel
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public TypeBag Type { get; set; }
    }
}
