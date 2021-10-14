using MicroserviceSquare.Context;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Lane;
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
    public class TypeLaneController : ControllerBase
    {
        private readonly SquareCatalogContext _dbcontext;

        public TypeLaneController(SquareCatalogContext squareCatalogContext)
        {
            _dbcontext = squareCatalogContext;
        }

        [HttpGet]
        public IActionResult GetTypeLanes()
        {            
            var res = _dbcontext.TypeLanes.Select(x => x);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult PostTypeLane(TypeLaneInsert typeLane)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.TypeLanes.Add(new TypeLane
                {
                    Name = typeLane.Name,
                });
                var res = _dbcontext.SaveChanges();
                return Ok(res);
            }
            return BadRequest();
        }
    }
}
