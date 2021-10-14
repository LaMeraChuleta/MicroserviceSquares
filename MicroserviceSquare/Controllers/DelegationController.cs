﻿using MicroserviceSquare.Context;
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
        private readonly SquareCatalogContext _dbcontext;

        public DelegationController(SquareCatalogContext squareCatalogContext)
        {
            _dbcontext = squareCatalogContext;
        }

        [HttpGet]
        public IActionResult GetDelegations()
        {                   
            var res = _dbcontext.Delegations.Select(x => x);
            return Ok(res);                      
        }
        [HttpPost]
        public IActionResult PostDelegation(Delegation delegation)
        {            
            if (ModelState.IsValid)
            {

                _dbcontext.Delegations.Add(delegation);
                var res = _dbcontext.SaveChanges();
                return Ok(res);                
            }
            return BadRequest();
        }       
    }
}
