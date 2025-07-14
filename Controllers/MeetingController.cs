using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using Test_dotnet_task.Services;


namespace Test_dotnet_task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetingController : Controller
    {
        IMeetingService _meetingService;

        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet("/meetings")]
        public IEnumerable<Meeting> GetMeetings()
        {
            return _meetingService.GetAllMeetings();
        }

        [HttpGet("/users/{userId}/meetings")]
        public IEnumerable<Meeting> GetMeetingsByUserId(int userId)
        {
            return _meetingService.GetMeetingsByUserId(userId);
        }

        [HttpPost("/meetings")]
        public String ReturnEarliestTimeSlot([FromBody] MeetingRequest req) 
        {
            DateTime result = _meetingService.ReturnEarliestTimeSlot(req);
            if (result == DateTime.MinValue)
            {
                HttpContext.Response.StatusCode = 500;
                return "No scheduling for this possible.";
            }
            return result.ToString();
        }
    }
}
