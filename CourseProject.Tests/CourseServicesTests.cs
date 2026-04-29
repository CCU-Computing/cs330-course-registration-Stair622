using System;
using Xunit;
using cs330_proj1;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace courseproject.tests;

public class CourseServicesTests
{
    // 2. As a student, I want to see all available courses so that I know what my options are.
    [Fact]
    public void GetCourses_CoursesExist_ReturnsAllCourses() {
        // Arrange
        var mockRepository = new Mock<ICourseRepository>();
        mockRepository.Setup(m => m.Courses).Returns(GetTestCourses());

        var courseServices = new CourseServices(mockRepository.Object);

        // Act
        var result = courseServices.getCourses();

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Equal("ARTD 201", result[0].Name);
        Assert.Equal("ARTS 101", result[1].Name);
    }

    [Fact]
    public void GetCourses_NoCoursesExist_ReturnsEmptyList() {
        // Arrange
        var mockRepository = new Mock<ICourseRepository>();
        mockRepository.Setup(m => m.Courses).Returns(new List<Course>());

        var courseServices = new CourseServices(mockRepository.Object);

        // Act
        var result = courseServices.getCourses();

        // Assert
        Assert.Empty(result);
    }


    // 3. As a student, I want to see all course offerings by semester, so that I can choose from what's available to register for next semester.
    [Fact]
    public void GetCourseOfferingsBySemester_OneOfferingInSemester_ReturnsOneOffering() {
        // Arrange
        var mockRepository = new Mock<ICourseRepository>();
        mockRepository.Setup(m => m.Offerings).Returns(new List<CourseOffering>() {
            new CourseOffering() {
                Section = "1",
                Semester = "Spring 2021",
                TheCourse = GetTestCourses().First()
            }
        });

        var courseServices = new CourseServices(mockRepository.Object);

        // Act
        var result = courseServices.getCourseOfferingsBySemester("Spring 2021");

        // Assert
        var itemInList = Assert.Single(result);
        Assert.Equal("Spring 2021", itemInList.Semester);
    }

    [Fact]
    public void GetCourseOfferingsBySemester_NoOfferingsInSemester_ReturnsEmptyList() {
        // Arrange
        var mockRepository = new Mock<ICourseRepository>();
        mockRepository.Setup(m => m.Offerings).Returns(new List<CourseOffering>() {
            new CourseOffering() {
                Section = "1",
                Semester = "Fall 2020",
                TheCourse = GetTestCourses().First()
            }
        });

        var courseServices = new CourseServices(mockRepository.Object);

        // Act
        var result = courseServices.getCourseOfferingsBySemester("Spring 2021");

        // Assert
        Assert.Empty(result);
    }


    // 4. As a student I want to see all course offerings by semester and department so that I can choose major courses to register for. 


    private List<Course> GetTestCourses()
        {
            return new List<Course>(){
            new Course() {
                Name="ARTD 201",
                Title="graphic design",
                Credits=3.0,
                Description="graphic design descr"

            },
            new Course() {
                Name="ARTS 101",
                Title="art studio",
                Credits=3.0,
                Description="studio descr"

            }
            };
        }

    }



 
