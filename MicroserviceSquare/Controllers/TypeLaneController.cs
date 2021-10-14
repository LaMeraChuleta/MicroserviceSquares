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
        [HttpGet]
        public IActionResult GetTypeLanes()
        {
            SquareCatalogContext context = new SquareCatalogContext();
            var res = context.TypeLanes.Select(x => x);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult PostTypeLane(TypeLaneInsert typeLane)
        {
            if (ModelState.IsValid)
            {
                SquareCatalogContext context = new SquareCatalogContext();
                context.TypeLanes.Add(new TypeLane
                {
                    Name = typeLane.Name,
                });
                var res = context.SaveChanges();
                return Ok(res);
            }
            return BadRequest();
        }
    }
}
