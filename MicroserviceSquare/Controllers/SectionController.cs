using AutoMapper;
using MicroserviceSquare.Context;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Section;
using MicroserviceSquare.Repository;
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
        private readonly IRepository<Section> _repository;
        private readonly IMapper _mapper;

        public SectionController(IRepository<Section> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSections()
        {
            var res = _repository.GetAll();
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> PostSection(SectionInsert sectionInsert)
        {
            if (ModelState.IsValid)
            {
                var sectionMapper = _mapper.Map<Section>(sectionInsert);
                var res = await _repository.AddAsync(sectionMapper);
                return Ok(res);
            }
            return BadRequest();
        }            
    }
}

