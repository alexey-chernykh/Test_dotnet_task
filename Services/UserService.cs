namespace Test_dotnet_task.Services
{
    public class UserService : IUserService
    {
        public static List<User> Users = new List<User> {
            new User { Id = 0, Name = "John" },
            new User { Id = 1, Name = "Adam" },
            new User { Id = 2, Name = "Kevin" },
            new User { Id = 3, Name = "Jane" },
        };

        public IEnumerable<User> GetAllUsers()
        {
            return Users;
        }

        public User CreateUser(string name)
        {
            Users.Add(new User { Id = Users.Last().Id + 1, Name = name });
            return Users.Last();
        }
    }
}
