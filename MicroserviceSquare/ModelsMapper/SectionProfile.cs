using AutoMapper;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Section;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
