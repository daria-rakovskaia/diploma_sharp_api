using diploma_sharp_api.Models;
using diploma_sharp_api.Services.GroupService;
using Microsoft.AspNetCore.Mvc;

namespace diploma_sharp_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService _groupService)
        {
            groupService = _groupService;
        }

        [HttpGet]
        public async Task<List<Group>> GetGroupsAsync()
        {
            return await groupService.GetGroupsAsync();
        }
    }
}
