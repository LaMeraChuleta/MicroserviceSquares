using AutoMapper;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Delegacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceSquare.ModelsMapper
{
    public class DelegationProfile: Profile
    {
        public DelegationProfile()
        {
            CreateMap<DelegationInsert, Delegation>();
        }
    }
}
