using DevCollab.Models;

namespace DevCollab.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetAllUsers();
        User? GetSingleUser(int id);
        User AddUser(User user);
        User? UpdateUser(int id, User user);
        void DeleteUser(int id);
    }
}
