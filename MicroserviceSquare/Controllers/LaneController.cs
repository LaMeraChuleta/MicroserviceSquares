using AutoMapper;
using MicroserviceSquare.Context;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Lane;
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
    public class LaneController : ControllerBase
    {
        private readonly IRepository<Lane> _repository;
        private readonly IMapper _mapper;

        public LaneController(IRepository<Lane> repository, IMapper mapper)
        {            
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetLanes()
        {
            var res = _repository.GetAll();
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> PostLane(LaneInsert laneInsert)
        {
            if (ModelState.IsValid)
            {
                var laneMapper = _mapper.Map<Lane>(laneInsert);
                var res = await _repository.AddAsync(laneMapper);
                return Ok();
            }
            return BadRequest();
        }
    }
}
