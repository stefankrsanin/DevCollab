using DevCollab.Models;

namespace DevCollab.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetAllUsers();
        User? GetSingleUser(int id);
        Task<List<User>> AddUser(User oneUser);
        Task<List<User>?> UpdateUser(int id, User user);
        void DeleteUser(int id);
    }
}
