using MicroserviceSquare.Context;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Square;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceSquare.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SquareController : ControllerBase
    {
        private readonly SquareCatalogContext _dbcontext;

        public SquareController(SquareCatalogContext squareCatalogContext)
        {
            _dbcontext = squareCatalogContext;
        }

        [HttpGet]
        public IActionResult GetSquares()
        {            
            var res = _dbcontext.Squares.Select(x => x);
            return Ok(res);                                    
        }
        [HttpPost]
        public IActionResult PostSquare(SquareInsert square)
        {
            if (ModelState.IsValid)
            {                               
                Delegation delegation = _dbcontext.Delegations.Find(square.DelegationId);
                _dbcontext.Squares.Add(new Square
                {
                   SquareId = square.SquareId,
                   Name = square.Name,
                   Delegation = delegation
                });
                var res = _dbcontext.SaveChanges();
                return Ok(res);                
            }
            return BadRequest();
        }
    }
}
