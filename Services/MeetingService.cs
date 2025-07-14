
namespace Test_dotnet_task.Services
{
    public class MeetingService : IMeetingService
    {
        public static List<Meeting> Meetings = new List<Meeting> {
            new Meeting { Id = 0, ParticipantIds = [0, 1],
                StartTime = new DateTime(2025, 7, 14, 12, 0, 0, DateTimeKind.Utc),
                EndTime = new DateTime(2025, 7, 14, 13, 0, 0, DateTimeKind.Utc), },
            new Meeting { Id = 1, ParticipantIds = [2, 3],
                StartTime = new DateTime(2025, 7, 14, 10, 0, 0, DateTimeKind.Utc),
                EndTime = new DateTime(2025, 7, 14, 11, 0, 0, DateTimeKind.Utc), },
            };
        public IEnumerable<Meeting> GetAllMeetings()
        {
            return Meetings;
        }

        public IEnumerable<Meeting> GetMeetingsByUserId(int userId)
        {
            return Meetings.Where((x) => x.ParticipantIds.Contains(userId));
        }

        public DateTime ReturnEarliestTimeSlot(MeetingRequest request)
        {
            int workStartHour = 9;
            int workEndHour = 17;
            double step = request.DurationMinutes;
            DateTime start = request.EarliestStart;
            DateTime end = request.LatestEnd;
            List<DateTime> list = new List<DateTime>();
            DateTime tmp = start;

            while (DateTime.Compare(tmp.AddMinutes(step), end) <= 0 &&
                (tmp.Hour >= workStartHour && tmp.Hour < workEndHour))
            {
                list.Add(tmp);
                tmp = tmp.AddMinutes(step);
            }
            Console.WriteLine(list);
            List<Meeting> newMeetings = new List<Meeting>();

            foreach (Meeting m in Meetings)
            {
                foreach (int id in request.ParticipantIds)
                {
                    if (m.ParticipantIds.Contains(id) && !newMeetings.Contains(m))
                    {
                        newMeetings.Add(m);
                    }
                }
            }

            List<DateTime> newList = new List<DateTime>(list);

            foreach (DateTime i in list)
            {
                foreach (Meeting m in newMeetings)
                {
                    if ((DateTime.Compare(i, m.StartTime) >= 0 && DateTime.Compare(i, m.EndTime) < 0))
                    {
                        newList.Remove(i);
                    }else if ((DateTime.Compare(i, m.StartTime) < 0 && DateTime.Compare(i.AddMinutes(step), m.StartTime) >= 0))
                    {
                        newList.Remove(i);
                    }
                }
            }
            DateTime index = new DateTime();
            try
            {
                index = newList.Min();
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }

            return index;
        }
    }
}
