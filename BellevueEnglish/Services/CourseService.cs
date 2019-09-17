using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellevueEnglish.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BellevueEnglish.Services
{
    public class CourseService : ICourseService
    {

        // We could also provide this as a named API client with the endpoint and headers but that seems like overkill.
        private readonly IHttpClientFactory _clientFactory;

        private CourseResults _courseResult { get; set; }

        // Endpoint for the provided API
        private readonly string BellvueRestApiURL = "https://www2.bellevuecollege.edu/data/api/v1/courses/";


        public CourseService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _courseResult = new CourseResults();
        }

        // We use a default department per the assignment instructions, but the API will accept any valid department code.
        public async Task<CourseResults> GetCourses(string department = "ENGL")
        {
            string requestURL = string.Concat(BellvueRestApiURL, department);
            var request = new HttpRequestMessage(HttpMethod.Get, requestURL);
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            // Check our status codes
            if (response.IsSuccessStatusCode)
            {
                _courseResult = JsonConvert.DeserializeObject<CourseResults>(await response.Content.ReadAsStringAsync());                
            }
            else
            {
                // Set the error check to true so it can be handled in the controller
                // Also set the course list to an empty array just to reduce the potential for null handling errors.
                _courseResult.RequestHadErrors = true;
                _courseResult.courses = Array.Empty<Course>();
            }

            return _courseResult;
        }
    }    
}
