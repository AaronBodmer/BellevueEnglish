using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellevueEnglish.Models
{
    // this class holds responses from the CourseService to the Controller, and is directly to the view in this example.
    public class CourseResults
    {
        public bool RequestHadErrors { get; set; } = false;
        public Course[] courses { get; set; }
    }
}
