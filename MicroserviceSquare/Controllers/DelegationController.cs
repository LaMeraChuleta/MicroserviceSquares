using AutoMapper;
using MicroserviceSquare.Models;
using MicroserviceSquare.ModelsHelper.Delegacion;
using MicroserviceSquare.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroserviceSquare.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DelegationController : ControllerBase
    {        
        private readonly IDelegationRepository _repository;
        private readonly IMapper _mapper;

        public DelegationController(IDelegationRepository delegationrepository, IMapper mapper)
        {            
            _repository = delegationrepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDelegations()
        {
            var res = await _repository.GetAllDelegationBasicAsync();
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> PostDelegation(DelegationInsert delegationinsert)
        {
            if (ModelState.IsValid)
            {
                var delegationMap = _mapper.Map<Delegation>(delegationinsert);
                var res = await _repository.AddAsync(delegationMap);
                return Ok();
            }
            return BadRequest();
        }    
    }
}
