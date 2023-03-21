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


        public User AddUser(User user)
        {
             _context.Users.Add(user);
           
            _context.SaveChanges();
            return user;
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

       

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            { 
                _context.Users.Remove(user);    
                _context.SaveChanges();
            }

            

        }

        public User? UpdateUser(int id, User user)
        {
            var userUpdated = _context.Users.Find(id);
            if (userUpdated != null)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return user;
            }

            return null;
        }
    }
}
