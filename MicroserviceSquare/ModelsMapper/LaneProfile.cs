using AutoMapper;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Lane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
