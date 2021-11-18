using AutoMapper;
using MicroserviceSquare.Context;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Square;
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
    public class SquareController : ControllerBase
    {
        private readonly IRepository<Square> _repository;
        private readonly IMapper _mapper;

        public SquareController(IRepository<Square> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSquares()
        {
            var res = _repository.GetAll();
            return Ok(res);                                    
        }
        [HttpPost]
        public async Task<IActionResult> PostSquare(SquareInsert squareInsert)
        {
            if (ModelState.IsValid)
            {       
                var squareMapper = _mapper.Map<Square>(squareInsert);
                var res = await _repository.AddAsync(squareMapper);
                return Ok();                
            }
            return BadRequest();
        }
    }
}
