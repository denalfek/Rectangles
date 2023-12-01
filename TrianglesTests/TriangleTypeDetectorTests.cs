using Triangles;

namespace TrianglesTests;

public class TriangleTypeDetectorTests
{
    private const string ErrorText = "Triangle doesn't exists";
    
    [Theory]
    [InlineData(9.04, 9.89, 4.0938, TriangleType.Acute)]
    [InlineData(5, 6, 7, TriangleType.Acute)]
    [InlineData(4.02, 2.589, 6.19, TriangleType.Obtuse)]
    [InlineData(1, 2, 3, TriangleType.Obtuse)]
    [InlineData(3.33, 4.44, 5.55, TriangleType.Right)]
    [InlineData(0.3, 0.4, 0.5, TriangleType.Right)]
    [InlineData(3.3, 4.4, 5.5, TriangleType.Right)]
    [InlineData(3, 4, 5, TriangleType.Right)]
    public void Given_CorrectSizes_When_DetectType_Then_ReturnsCorrectType(decimal a, decimal b, decimal c, TriangleType expected)
    {
        // Arrange

        // Act
        var result = TypeDetector.DetectType(a, b, c);

        // Assert
        Assert.Equal(expected, result.AsT0);
    }
    
    [Theory]
    [InlineData(-1, 2, 4, ErrorText)]
    [InlineData(0, 1, 1, ErrorText)]
    public void Given_IncorrectSizes_When_DetectType_Then_ReturnsErrorResult(decimal a, decimal b, decimal c, string error)
    {
        // Arrange

        // Act
        var result = TypeDetector.DetectType(a, b, c);

        // Assert
        Assert.Equal(error, result.AsT1.Value);
    }
}
