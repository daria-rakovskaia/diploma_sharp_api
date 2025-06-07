using diploma_sharp_api.Models;

namespace diploma_sharp_api.Services.TeacherService
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetTeachersAsync();
    }
}
