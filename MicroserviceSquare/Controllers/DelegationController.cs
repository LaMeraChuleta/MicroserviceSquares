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
        public IActionResult GetDelegations()
        {
            var res = _repository.GetAll();
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> PostDelegation(Delegation delegation)
        {
            var res = await _repository.AddAsync(delegation);
            return Ok(res);
        }
        //[HttpPost]
        //public async Task<IActionResult> PostDelegation2(DelegationInsert delegationinsert)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Delegation delegation = new Delegation
        //        {
        //            DelegationId = delegationinsert.DelegationId,
        //            Name = delegationinsert.Name,
        //        };
        //        var res = await _repository.AddAsync(delegation);
        //        return Ok();
        //    }
        //    return BadRequest();
        //}
    }
}
