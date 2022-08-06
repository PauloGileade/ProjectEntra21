using AutoMapper;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Entiteis;

namespace ProjectEntra21.src.Application.Mapper
{
    public class CellMapper : Profile
    {
        public CellMapper()
        {
            CreateMap<Cell, CellViewModel>();
        }
    }
}
