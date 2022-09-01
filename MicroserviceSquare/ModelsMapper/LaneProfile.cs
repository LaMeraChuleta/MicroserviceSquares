using AutoMapper;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Lane;

namespace MicroserviceSquare.ModelsMapper
{
    public class LaneProfile : Profile
    {
        public LaneProfile()
        {
            CreateMap<LaneInsert, Lane>();
        }
    }
}
