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
        var result = courseServices.GetCourses();

        // Assert
        Assert.Equal(4, result.Count());
        Assert.Equal("ARTD 201", result[0].Name);
        Assert.Equal("ARTS 101", result[1].Name);
        Assert.Equal("STAT 201", result[2].Name);
        Assert.Equal("ENGL 302", result[3].Name);
    }

    // 3. As a student, I want to see all course offerings by semester, so that I can choose from what's available to register for next semester.

    // 4. As a student I want to see all course offerings by semester and department so that I can choose major courses to register for. 
}
