using MicroserviceSquare.Context;
using MicroserviceSquare.Models;
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
    public class SectionController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSections()
        {
            SquareCatalogContext context = new SquareCatalogContext();
            var res = context.Sections.Select(x => x);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult PostSection(SectionInsert section)
        {
            if (ModelState.IsValid)
            {
                SquareCatalogContext context = new SquareCatalogContext();
                Square square = context.Squares.Find(section.SquareId);
                context.Sections.Add(new Section
                {
                    SectionId = section.SectionId,
                    Name = section.Name,
                    Square = square
                });
                var res = context.SaveChanges();
                return Ok(res);
            }
            return BadRequest();
        }            
    }
}

