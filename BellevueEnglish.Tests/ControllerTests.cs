using System;
using Xunit;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BellevueEnglish.Models;
using BellevueEnglish.Services;
using Moq;
using BellevueEnglish.Controllers;

namespace BellevueEnglish.Tests
{
    public class ControllerTests
    {

        [Fact]
        public async Task Index_ReturnsAViewResultWithCourses()
        {
            // Arrange
            var mockedCourseService = new Mock<ICourseService>();
            mockedCourseService.Setup(service => service.GetCourses("ENGL")).ReturnsAsync(GetSampleCourses());
            var hc = new HomeController(mockedCourseService.Object);

            // Act
            var result = await hc.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CourseResults>(viewResult.ViewData.Model);
            Assert.Equal(3, model.courses.Length);
        }

        public CourseResults GetSampleCourses()
        {
            CourseResults cr = new CourseResults();
            cr.RequestHadErrors = false;
            cr.courses = new Course[] {
                new Course() {Title = "19th Century English Lit", Credits="3", Description="Very exciting 19th Century Dickinson Poems."},
                new Course() {Title = "20th Century English Lit", Credits="3", Description="Cyberpunk as foreshadowing of the Modern Internet"},
                new Course() {Title = "21th Century English Lit", Credits="3", Description="LitRPG, is it literature or a video game or both?"},
            };

            return cr;
        }
    }           
}
