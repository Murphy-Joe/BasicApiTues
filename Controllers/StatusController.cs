using Microsoft.AspNetCore.Mvc;

namespace BasicApi.Controllers
{
    public class StatusController : ControllerBase
    {
        private readonly ILookupOnCallDevelopers _onCallLookupService;

        public StatusController(ILookupOnCallDevelopers onCallLookupService)
        {
            _onCallLookupService = onCallLookupService;
        }

        // GET /status -> 200 Ok
        [HttpGet("/status")]
        public async Task<ActionResult<StatusResponse>>  GetStatus()
        {
            var response = new StatusResponse { Message = "Things are going fine" };
            response.OnCall = await _onCallLookupService.GetOnCallDeveloperAsync();
            return Ok(response);
        }
    }

    public class StatusResponse
    {
        public string Message { get; set; } = string.Empty;
        public OnCallDeveloperInformation OnCall { get; set; } = new OnCallDeveloperInformation();
    }

    public class OnCallDeveloperInformation
    {
        public string OnCallDeveloperName { get; set; } = string.Empty;
        public string OnCallDeveloperEmail { get; set; } = string.Empty;
    }
}
