using DevCollab.Data;
using DevCollab.Interfaces;
using DevCollab.Models;

namespace DevCollab.Services
{

    public class UserService : IUserService
    {
      
        // Donju crtu _ stavljamo kod svih propertija koji su private (naming convention)
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;

        public UserService(DataContext context, IUserRepository userRepository)
        {
            _context = context;
            this._userRepository = userRepository;
        }
        public async Task<List<User>> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>?> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }

        public ICollection<User> GetAllUsers()
        {
            // var users = await _context.Users.ToListAsync();
            var users = _userRepository.GetAllUsers();
            return users;

        }

        public async Task<User?> GetSingleUser(int id)
        {
            var user = await _context.Users.FindAsync(id); 
           if (user == null) {
                return null;
            }
            
            return user;
        }

        public async Task<List<User>?> UpdateUser(int id, User request)
            
        {
             var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            user.firstName = request.firstName;
            user.lastName = request.lastName;
            user.email = request.email;
            user.phoneNumber = request.phoneNumber;
            user.address = request.address;
            //user.userSkills = request.userSkills;


            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }
    }
}
