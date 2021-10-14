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
        private readonly SquareCatalogContext _dbcontext;

        public SectionController(SquareCatalogContext squareCatalogContext)
        {
            _dbcontext = squareCatalogContext;
        }

        [HttpGet]
        public IActionResult GetSections()
        {            
            var res = _dbcontext.Sections.Select(x => x);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult PostSection(SectionInsert section)
        {
            if (ModelState.IsValid)
            {                
                Square square = _dbcontext.Squares.Find(section.SquareId);
                _dbcontext.Sections.Add(new Section
                {
                    SectionId = section.SectionId,
                    Name = section.Name,
                    Square = square
                });
                var res = _dbcontext.SaveChanges();
                return Ok(res);
            }
            return BadRequest();
        }            
    }
}

