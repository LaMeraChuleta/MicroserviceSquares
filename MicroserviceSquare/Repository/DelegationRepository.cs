using MicroserviceSquare.Context;
using MicroserviceSquare.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceSquare.Repository
{
    public class DelegationRepository : Repository<Delegation>, IDelegationRepository
    {
        public DelegationRepository(SquareCatalogContext squareCatalogContext) : base(squareCatalogContext)
        {

        }

        public Task<Delegation> GetDelegation()
        {
            return GetAll().FirstOrDefaultAsync(x => x.DelegationId == "01");
        }
    }           
}
