using diploma_sharp_api.Models;
using Microsoft.EntityFrameworkCore;

namespace diploma_sharp_api.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly HseExamProgContext context;

        public GroupService(HseExamProgContext _context)
        {
            context = _context;
        }

        public async Task<List<Group>> GetGroupsAsync()
        {
            return await context.Groups.ToListAsync();
        }
    }
}
