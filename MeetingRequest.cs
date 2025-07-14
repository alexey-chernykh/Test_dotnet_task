namespace Test_dotnet_task
{
    public class MeetingRequest
    {
        public required List<int> ParticipantIds { get; set; }
        public int DurationMinutes { get; set; }
        public DateTime EarliestStart { get; set; }
        public DateTime LatestEnd { get; set; }
    }
}
