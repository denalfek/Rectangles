using OneOf.Types;
using Triangles;

namespace TrianglesTests;

using Result = OneOf.OneOf<TriangleType, Error<string>>;
using Err = Error<string>;

public class TriangleTypeDetectorTests
{
    [Theory]
    [InlineData(9.04, 9.89, 4.0938, TriangleType.Acute)]
    [InlineData(3.33, 4.44, 5.55, TriangleType.Acute)]
    [InlineData(5, 6, 7, TriangleType.Acute)]
    [InlineData(4.02, 2.589, 6.19, TriangleType.Obtuse)]
    [InlineData(1, 2, 3, TriangleType.Obtuse)]
    [InlineData(0.3, 0.4, 0.5, TriangleType.Right)]
    [InlineData(3.3, 4.4, 5.5, TriangleType.Right)]
    [InlineData(3, 4, 5, TriangleType.Right)]
    public void DetectTypeReturnsCorrectType(decimal a, decimal b, decimal c, TriangleType expected)
    {
        // Arrange

        // Act
        var result = TypeDetector.DetectTypeAsync(a, b, c);

        // Assert
        Assert.Equal(expected, result.AsT0);
    }
    
    [Theory]
    [InlineData(-1, 2, 4, ErrorText)]
    [InlineData(0, 1, 1, ErrorText)]
    public void DetectTypeTriangleDoesntExists(decimal a, decimal b, decimal c, string error)
    {
        // Arrange

        // Act
        var result = TypeDetector.DetectTypeAsync(a, b, c);

        // Assert
        Assert.Equal(error, result.AsT1.Value);
    }
    
    private const string ErrorText = "Triangle doesn't exists";
}