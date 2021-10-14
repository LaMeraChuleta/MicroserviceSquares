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
        [HttpGet]
        public IActionResult GetSquares()
        {
            SquareCatalogContext context = new SquareCatalogContext();            
            var res = context.Squares.Select(x => x);
            return Ok(res);                                    
        }
        [HttpPost]
        public IActionResult PostSquare(SquareInsert square)
        {
            if (ModelState.IsValid)
            {
                SquareCatalogContext context = new SquareCatalogContext();                
                Delegation delegation = context.Delegations.Find(square.DelegationId);
                context.Squares.Add(new Square
                {
                   SquareId = square.SquareId,
                   Name = square.Name,
                   Delegation = delegation
                });
                var res = context.SaveChanges();
                return Ok(res);                
            }
            return BadRequest();
        }
    }
}
