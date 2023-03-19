using DevCollab.Data;
using DevCollab.Interfaces;
using DevCollab.Models;
using System.Reflection.Metadata.Ecma335;

namespace DevCollab.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        } 

        public ICollection<User> GetAllUsers()
        {
            // Tacku gledaj kao rec ("nad")
            var users = _context.Users.ToList();
            return users;
        }


        public Task<List<User>> AddUser(User oneUser)
        {
            throw new NotImplementedException();
        }

      

        public User? GetSingleUser(int id)
        {
            var user =  _context.Users.Where(u => u.Id == id).FirstOrDefault();
            if (user == null)
            {
                return null;
            }

            return user;

        }

        public Task<List<User>?> UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            { 
                _context.Users.Remove(user);    
                _context.SaveChanges();
            }

            

        }        
    }
}
