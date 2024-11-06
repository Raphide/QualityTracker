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
    }
}