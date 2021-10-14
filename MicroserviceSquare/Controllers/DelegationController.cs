using MicroserviceSquare.Context;
using MicroserviceSquare.Models;
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
        [HttpGet]
        public IActionResult GetDelegations()
        {
            SquareCatalogContext context = new SquareCatalogContext();            
            var res = context.Delegations.Select(x => x);
            return Ok(res);                      
        }
        [HttpPost]
        public IActionResult PostDelegation(Delegation delegation)
        {            
            if (ModelState.IsValid)
            {
                SquareCatalogContext context = new SquareCatalogContext();                
                context.Delegations.Add(delegation);
                var res = context.SaveChanges();
                return Ok(res);                
            }
            return BadRequest();
        }       
    }
}
