using ResumeMindX.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResumeMindX.Services
{
    public interface IService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<Domain.Resume>> GetResumes();
        Task<IEnumerable<Domain.Resume>> GetResumesByUserId(int userId);

        Task Signup(User user);
        Task<bool> Login(User user);

        Task CreateResume(Domain.Resume resume);
        Task CreateResumes(IEnumerable<Domain.Resume> resumes);
        Task<bool> UpdateResume(Domain.Resume resume);
        Task<bool> DeleteResume(int resumeId);

        Task<User> Authenticate(string username, string password);
    }
}
