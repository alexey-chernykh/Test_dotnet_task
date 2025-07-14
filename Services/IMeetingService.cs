using Microsoft.AspNetCore.Mvc;

namespace Test_dotnet_task.Services
{
    public interface IMeetingService
    {
        IEnumerable<Meeting> GetAllMeetings();
        IEnumerable<Meeting> GetMeetingsByUserId(int userId);
        DateTime ReturnEarliestTimeSlot(MeetingRequest request);
    }
}
