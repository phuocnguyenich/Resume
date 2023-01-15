using Microsoft.EntityFrameworkCore;
using ResumeMindX.Contexts;
using ResumeMindX.Domain;
using ResumeMindX.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Services
{
    public class Service : IService
    {
        private readonly ResumeDbContext _context;

        public Service(ResumeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResumeMindX.Domain.Resume>> GetResumes()
        {
            return await _context.Resumes.ToListAsync();
        }

        public async Task<IEnumerable<ResumeMindX.Domain.Resume>> GetResumesByUserId(int userId)
        {
            return await _context.Users
                .Where(x => x.Id == userId)
                .Select(x => x.Resumes)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.Include(x => x.Resumes).ToListAsync();
        }

        public async Task Signup(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task CreateResume(ResumeMindX.Domain.Resume resume)
        {
            _context.Resumes.Add(resume);
            await _context.SaveChangesAsync();
        }

        public async Task CreateResumes(IEnumerable<ResumeMindX.Domain.Resume> resumes)
        {
            _context.Resumes.AddRange(resumes);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Login(User request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Username == request.Username && x.Password == request.Password);
            if (user != null)
                return true;
            return false;
        }

        public async Task<bool> UpdateResume(ResumeMindX.Domain.Resume request)
        {
            var resume = await _context.Resumes.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (resume == null)
                return false;
            resume.Name = request.Name;
            resume.Email = request.Email;
            resume.Mobile = request.Mobile;
            resume.Github = request.Github;
            resume.Linkedin = request.Linkedin;
            resume.ShortDescription = request.ShortDescription;
            resume.JobTitle = request.JobTitle;
            resume.Company = request.Company;
            resume.Period = request.Period;
            resume.JobDescription = request.JobDescription;
            resume.University = request.University;
            resume.Faculty = request.Faculty;
            resume.GPA = request.GPA;

            _context.Resumes.Update(request);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteResume(int resumeId)
        {
            var resume = await _context.Resumes.FirstOrDefaultAsync(x => x.Id == resumeId);

            if (resume == null)
                return false;

            _context.Resumes.Remove(resume);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);
        }
    }
}
