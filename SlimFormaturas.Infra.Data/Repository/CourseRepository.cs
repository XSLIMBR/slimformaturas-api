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
    }      
}
