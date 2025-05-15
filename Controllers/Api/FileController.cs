using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ExamBackend.Services;

namespace ExamBackend.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost]
        [Route("copy")]
        public IActionResult Copy([FromBody] JObject data)
        {
            if (String.IsNullOrEmpty(data["source"].ToString())|| String.IsNullOrEmpty(data["target"].ToString()))
            {
                return BadRequest("RequisitionID不可為空");
            }

            FileService.InsertTableF(data["source"].ToString(), data["target"].ToString());
            return Ok();
        }
    }
}