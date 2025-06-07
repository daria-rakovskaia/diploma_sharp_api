using diploma_sharp_api.Models;

namespace diploma_sharp_api.Services.StudentService
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsByGroupAsync(int groupId);
    }
}
