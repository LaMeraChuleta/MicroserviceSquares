﻿using MicroserviceSquare.Context;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Delegacion;
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

        public Task<List<DelegationSelectBasic>> GetDelegationListBasic()
        {
            return GetAll().Select(x => new DelegationSelectBasic
            {
                DelegationId = x.DelegationId,
                Name = x.Name
            }).ToListAsync();
        }
    }           
}
