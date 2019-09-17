using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellevueEnglish.Models;

namespace BellevueEnglish.Services
{
    public interface ICourseService
    {
        Task<CourseResults> GetCourses(string department = "ENGL");
    }
}
