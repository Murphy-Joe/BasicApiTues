using Microsoft.AspNetCore.Mvc;

namespace BasicApi.Controllers
{
    public class StatusController : ControllerBase
    {
        // GET /status -> 200 Ok
        [HttpGet("/status")]
        public ActionResult<StatusResponse>  GetStatus()
        {
            var response = new StatusResponse { Message = "Things are going fine" };
            return Ok(response);
        }
    }

    public class StatusResponse
    {
        public string Message { get; set; } = string.Empty;
    }
}
