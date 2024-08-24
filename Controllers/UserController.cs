using crud_dotnet_api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace crud_dotnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]  //uncomment it to protect thr routes actions
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        
        public async Task<ActionResult> GetUserList()
        {
            var userList =await  _userRepository.GetAllUsersAsync();
            return Ok(userList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById([FromRoute] int id)
        {
            var user= await _userRepository.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser([FromRoute] int id, [FromBody] User model)
        {
            await _userRepository.UpdateUserAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {
            await _userRepository.DeleteUserAsnyc(id);
            return Ok();
        }
    }
}
