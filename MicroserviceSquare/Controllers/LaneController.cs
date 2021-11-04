using MicroserviceSquare.Context;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Lane;
using MicroserviceSquare.ModelsHelper.Section;
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
    public class LaneController : ControllerBase
    {
        private readonly SquareCatalogContext _dbcontext;

        public LaneController(SquareCatalogContext squareCatalogContext)
        {
            _dbcontext = squareCatalogContext;
        }
        [HttpGet]
        public IActionResult GetLanes()
        {            
            var res = _dbcontext.Lanes.Select(x => x);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult PostLane(LaneInsert lane)
        {
            if (ModelState.IsValid)
            {                                                
                TypeLane typelane = _dbcontext.TypeLanes.Find(lane.TypeLaneId);

                _dbcontext.Lanes.Add(new Lane
                {
                    NumberProvider = lane.NumberProvider,
                    NumberGea = lane.NumberGea,
                    TypeLaneId = lane.TypeLaneId,
                    SectionId = lane.SectionId,
                    SquareId = lane.SquareId
                });
                var res = _dbcontext.SaveChanges();
                return Ok(res);
            }
            return BadRequest();
        }
    }
}
