using Business.BLL;
using Business.Interfaces;
using DTO.Request;
using DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentBLL _studentBLL;
        public StudentsController(IStudentBLL studentBLL)
        {
            _studentBLL = studentBLL;
        }

        [HttpGet("GetStudent")]
        public async Task<IActionResult> Get(string? document)
        {
            if (document is not null)
            {
                var consumptionResponses = await _studentBLL.Get(document);
                if (consumptionResponses.Codigo == 200)
                {
                    return Ok(consumptionResponses.Datos);
                }
                return BadRequest(consumptionResponses);
            }
            else
            {
                var consumptionResponse = await _studentBLL.GetAll();
                if (consumptionResponse.Codigo == 200)
                {
                    return Ok(consumptionResponse.Datos);
                }
                return BadRequest(consumptionResponse);
            }
        }

        [HttpPost("InsertStudent")]
        public async Task<IActionResult> Insert([FromBody] StudentRequest studentRequest)
        {
            var consumptionResponse = await _studentBLL.Insert(studentRequest);
            if (consumptionResponse.Codigo == 200)
            {
                return Ok(consumptionResponse.Datos);
            }
            return BadRequest(consumptionResponse);
        }

        [HttpPut("ModifyStudent")]
        public async Task<IActionResult> Modify([FromBody] StudentResponse studentResponse)
        {
            var consumptionResponse = await _studentBLL.Modify(studentResponse);
            if (consumptionResponse.Codigo == 200)
            {
                return Ok(consumptionResponse.Datos);
            }
            return BadRequest(consumptionResponse);
        }

        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> Delete(string document)
        {
            var consumptionResponse = await _studentBLL.Delete(document);
            if (consumptionResponse.Codigo == 200)
            {
                return Ok(consumptionResponse);
            }
            return BadRequest(consumptionResponse);
        }
    }
}
