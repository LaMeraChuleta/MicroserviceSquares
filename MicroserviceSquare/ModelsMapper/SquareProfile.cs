using AutoMapper;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Square;

namespace MicroserviceSquare.ModelsMapper
{
    public class SquareProfile : Profile
    {
        public SquareProfile()
        {
            CreateMap<SquareInsert, Square>();
        }
    }
}
