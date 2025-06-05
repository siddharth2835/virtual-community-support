using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Entities.Models;
using Mission.Services.IServices;

namespace Mission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            try
            {
                var res = await _userService.DeleteUser(id);
                return Ok(new ResponseResult() { Data = "User deleted successfully.", Result = ResponseStatus.Success, Message = "" });
            }
            catch
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to delete user." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById([FromQuery] int id)
        {
            try
            {
                var res = await _userService.GetUserById(id);
                return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
            }
            catch
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to find user." });
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserResponseModel user)
        {
            try
            {
                var updatedUser = await _userService.UpdateUser(user);
                return Ok(new ResponseResult() { Data = updatedUser, Result = ResponseStatus.Success, Message = "User updated successfully." });
            }
            catch
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to update user." });
            }
        }
    }
}
