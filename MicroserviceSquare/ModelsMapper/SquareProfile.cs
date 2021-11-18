using AutoMapper;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Square;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
