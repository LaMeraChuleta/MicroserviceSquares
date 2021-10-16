using MicroserviceSquare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceSquare.Repository
{
    public interface IDelegationRepository: IRepository<Delegation>
    {
        Task<Delegation> GetDelegation();
    }
}
