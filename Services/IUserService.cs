namespace Test_dotnet_task.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User CreateUser(string name);
    }
}
