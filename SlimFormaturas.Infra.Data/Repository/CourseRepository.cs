using Microsoft.AspNetCore.Identity;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.CrossCutting.Identity.Models;
using SlimFormaturas.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SlimFormaturas.Infra.Data.Repository
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public CourseRepository(MssqlContext context,
            UserManager<ApplicationUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<Course> GetAllById(string id)
        {
            var course = await Context.Course
                .Include(c => c.ContractCourse)
                .Include(c => c.GraduateCeremonial)
                .FirstOrDefaultAsync(c => c.CourseId == id);

            return course;
        }


        public new async Task<IList<Course>> GetAll()
        {
            var course = await Context.Course
                .Include(c => c.ContractCourse)
                .Include(c => c.GraduateCeremonial)
                .ToListAsync();

            return course;
        }
    }      
}
