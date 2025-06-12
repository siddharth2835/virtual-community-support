using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Entities.Models;
using Mission.Services.IServices;

namespace Mission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController(IMissionService missionService) : ControllerBase
    {
        private readonly IMissionService _missionService = missionService;

        [HttpPost]
        [Route("AddMission")]
        public IActionResult AddMission(MissionRequestViewModel model)
        {
            var response = _missionService.AddMission(model);
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }

        [HttpGet]
        [Route("MissionList")]
        public async Task<IActionResult> GetAllMissionAsync()
        {
            var response = await _missionService.GetAllMissionAsync();
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }

        // Mission\Controllers\MissionController.cs
        [HttpPost]
        [Route("UpdateMission")]
        public async Task<IActionResult> UpdateMission(MissionRequestViewModel model)
        {
            var success = await _missionService.UpdateMission(model);
            if (success)
            {
                return Ok(new ResponseResult() { Data = null, Result = ResponseStatus.Success, Message = "Mission updated successfully." });
            }
            return NotFound(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Mission not found." });
        }

        [HttpDelete]
        [Route("DeleteMission/{id:int}")]
        public async Task<IActionResult> DeleteMission(int id)
        {
            var success = await _missionService.DeleteMission(id);
            if (success)
            {
                return Ok(new ResponseResult() { Data = null, Result = ResponseStatus.Success, Message = "Mission deleted successfully." });
            }
            return NotFound(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Mission not found." });
        }

        [HttpGet]
        [Route("MissionDetailById/{id:int}")]
        public async Task<IActionResult> GetMissionById(int id)
        {
            var response = await _missionService.GetMissionById(id);
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }
    }
}
