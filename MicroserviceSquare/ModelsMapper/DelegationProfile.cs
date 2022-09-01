using AutoMapper;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Delegacion;

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
