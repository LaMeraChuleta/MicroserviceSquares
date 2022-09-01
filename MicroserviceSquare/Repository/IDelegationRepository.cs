using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Delegacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroserviceSquare.Repository
{
    public interface IDelegationRepository: IRepository<Delegation>
    {
        Task<List<DelegationSelectBasic>> GetAllDelegationBasicAsync();
    }
}
