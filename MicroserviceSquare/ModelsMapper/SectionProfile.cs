using AutoMapper;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Section;

namespace MicroserviceSquare.ModelsMapper
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<SectionInsert, Section>();
        }
    }
}
