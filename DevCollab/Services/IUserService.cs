using DevCollab.Models;

namespace DevCollab.Services
{
    public interface IUserService
    {
        ICollection<User> GetAllUsers();
        Task<User?> GetSingleUser(int id);
        Task<List<User>> AddUser(User oneUser);
        Task<List<User>?> UpdateUser(int id, User user);
        Task<List<User>?> DeleteUser(int id);
    }
}
