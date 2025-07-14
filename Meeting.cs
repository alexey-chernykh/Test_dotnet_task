namespace Test_dotnet_task
{
    public class Meeting
    {
        public int Id { get; set; }
        public required int[] ParticipantIds { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
