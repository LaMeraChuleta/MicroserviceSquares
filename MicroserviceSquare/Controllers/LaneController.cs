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
        [HttpGet]
        public IActionResult GetLanes()
        {
            SquareCatalogContext context = new SquareCatalogContext();
            var res = context.Lanes.Select(x => x);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult PostLane(LaneInsert lane)
        {
            if (ModelState.IsValid)
            {
                SquareCatalogContext context = new SquareCatalogContext();
                Square square = context.Squares.Find(lane.SquareId);
                Section section = context.Sections.Find(lane.SectionId);
                TypeLane typelane = context.TypeLanes.Find(lane.TypeLaneId);

                context.Lanes.Add(new Lane
                {
                    NumberProvider = lane.NumberProvider,
                    NumberGea = lane.NumberGea,
                    TypeLane = typelane,
                    Section = section,
                    Square = square
                });
                var res = context.SaveChanges();
                return Ok(res);
            }
            return BadRequest();
        }
    }
}
