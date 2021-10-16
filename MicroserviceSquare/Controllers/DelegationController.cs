using MicroserviceSquare.Context;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Delegacion;
using MicroserviceSquare.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceSquare.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DelegationController : ControllerBase
    {               
        private readonly SquareCatalogContext _dbcontext;        
        private readonly IDelegationRepository _repository;        

        public DelegationController(SquareCatalogContext squareCatalogContext, IDelegationRepository delegationrepository)
        {
            _dbcontext = squareCatalogContext;
            _repository = delegationrepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDelegations()
        {
            //var res = _dbcontext.Delegations.Select(x => x);
            var res = await _repository.GetDelegation();
            return Ok(res);                      
        }
        [HttpPost]
        public IActionResult PostDelegation(DelegationInsert delegation)
        {            
            if (ModelState.IsValid)
            {

                _dbcontext.Delegations.Add(new Delegation 
                {    
                    DelegationId = delegation.DelegationId,
                    Name = delegation.Name,
                });
                var res = _dbcontext.SaveChanges();
                return Ok(res);                
            }
            return BadRequest();
        }       
    }
}
