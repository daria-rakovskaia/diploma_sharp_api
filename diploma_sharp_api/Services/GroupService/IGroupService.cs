using diploma_sharp_api.Models;

namespace diploma_sharp_api.Services.GroupService
{
    public interface IGroupService
    {
        Task<List<Group>> GetGroupsAsync();
    }
}
