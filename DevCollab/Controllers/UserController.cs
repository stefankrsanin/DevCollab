using DevCollab.Models;
using DevCollab.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DevCollab.Controllers
{
    // Ovde definisem za koji url ce mi biti odgovoran ovaj kontroler (localhost:7000/api/User)
    // Zasto /User ? -> ovo [controller] je ustvari naziv klase dakle /api/imeKlase -> User
    [Route("api/[controller]")] // Base url mu je /api/User
    // Ova sintaksa [ ] predstavlja "atribute" - "kićenje" metoda ili klase - nadogradjivanje
    [ApiController]
    // Da bi User klasa bila kontroler, mora da nasledi ControllerBase klasu
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService; //dipendecy injection
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        // atribut da oznaci da je ovo get metoda (http get)
        [HttpGet] //-> odgovoran za ovo /api/User
        public ICollection<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("{id}")] // -> odgovoran za /api/User/{id} (id hvata iz parametra)
        public async Task<ActionResult<User?>> GetSingleUser(int id)
        {
            var user = await _userService.GetSingleUser(id); // -> Vraca ceo User 
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            var result = await  _userService.AddUser(user);

            if (result == null)
                return NotFound("User not found.");

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(int id, User request)
        {
            var result = await _userService.UpdateUser(id, request);

            if (result == null)
                return NotFound("Company not found.");

            return Ok(result);
        }
       [HttpDelete("{id}")]

        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);

            if (result == null)
                return NotFound("Company not found.");

            return Ok(result);
        }
      
    }
}
