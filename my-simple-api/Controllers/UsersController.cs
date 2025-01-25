using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace my_simple_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IUserRepository _userRepository;
        private IUserService _userService;

        public UsersController(ApplicationDbContext context, IUserRepository userRepository, IUserService userService)
        {
            _context = context;
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var result = _userRepository.GetUsers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var result = _userRepository.GetUserById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult InsertUser(UserModel user)
        {
            var result = _userRepository.InsertUser(user);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserModel user)
        {
            var result = _userRepository.UpdateUser(id, user);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveUserById(int id)
        {
            var result = _userRepository.RemoveUserById(id);
            return Ok(result);
        }

        [HttpGet("getToken/{id}")]
        [AllowAnonymous]
        public IActionResult GetToken(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                var resultWithAnonymous = _userService.GenerateToken(0);
                return Ok(resultWithAnonymous);
            }

            var result = _userService.GenerateToken(user.Id);
            return Ok(result);
        }

        [HttpGet("getUserByToken")]
        public IActionResult GetUserByToken()
        {
            if (HttpContext.Items["userId"] is int userId)
            {
                var result = _userRepository.GetUserById(userId);
                return Ok(result);
            }
            else
            {
                return BadRequest("User ID not found in context.");
            }
        }
    }
}
