using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BellevueEnglish.Models
{
    public class Course
    {
        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty]
        public string Subject { get; set; }

        [JsonProperty]
        public string CourseNumber { get; set; }

        [JsonProperty]
        public string CourseId { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public string Note { get; set; }

        [JsonProperty]
        public string Credits { get; set; }

        [JsonProperty]
        public bool IsVariableCredits { get; set; }

        [JsonProperty]
        public bool IsCommonCourse { get; set; } 

        /*  Example course object
            "title": "Introductory College Reading and Writing I",
            "subject": "ENGL",
            "courseNumber": "072",
            "courseId": "ENGL 072",
            "description": "Students learn reading and writing strategies to prepare them for success in higher level composition classes. Students are also enrolled automatically in ENGL 080, Reading Lab, to work more intensively on reading skills, which are a key to improving writing and editing skills. Course is graded credit/no credit; may be repeated for a maximum of 30 credits. Prerequisite: Placement by assessment.",
            "note": "Prerequisite:  Placement by assessment Course requires two to four hours per week of independent work in Reading Lab in addition to regular class meetings. Class graded cr edit/no credit; may be repeated for a maximum of 30 credits. Fee: $44.00 computer use.",
            "credits": 10,
            "isVariableCredits": false,
            "isCommonCourse": false
        */
    }
}
