using Microsoft.AspNetCore.Mvc;
using QualityApi.Cases.DTOs;

namespace QualityApi.Cases{
    [ApiController]
    [Route("/cases")]
    public class CaseController : ControllerBase{
        private readonly CaseService _caseService;

        public CaseController(CaseService caseService){
            _caseService = caseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCase([FromBody] CreateCaseDto data){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var newCase = await _caseService.CreateCaseAsync(data);
            return StatusCode(201, newCase);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCases(){
            var cases = await _caseService.FindAllAsync();
            return Ok(cases);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCaseById([FromRoute] long id){
            var foundCase = await _caseService.FindByIdAsync(id);
            if (foundCase == null){
                return NotFound($"Could not find case with id {id}");
            }
            return Ok(foundCase);
        }

        // [HttpPatch("{id}")]
        // public async Task<IActionResult> UpdateCase([FromRoute] long id, [FromBody] UpdateCaseDto data){
        //     if (!ModelState.IsValid){
        //         return BadRequest(ModelState);
        //     }
        //     var updatedCase = await _caseService.UpdateCase(id, data);
        //     if (updatedCase == null){
        //         return NotFound("Case not found");
        //     }
        //     return Ok(updatedCase);
        // }
    }
}