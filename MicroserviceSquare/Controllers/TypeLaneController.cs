using AutoMapper;
using MicroserviceSquare.Context;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Lane;
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
    public class TypeLaneController : ControllerBase
    {
        private readonly IRepository<TypeLane> _repository;
        private readonly IMapper _mapper;
        public TypeLaneController(IRepository<TypeLane> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTypeLanes()
        {
            var res = _repository.GetAll();
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> PostTypeLane(TypeLaneInsert typeLaneInsert)
        {
            if (ModelState.IsValid)
            {             
                var typeLaneMapper = _mapper.Map<TypeLane>(typeLaneInsert);
                var res = await _repository.AddAsync(typeLaneMapper);
                return Ok();
            }
            return BadRequest();
        }
    }
}
