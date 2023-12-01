using OneOf.Types;

namespace Triangles;

using Result = OneOf.OneOf<TriangleType, Error<string>>;

public static class TypeDetector
{
    private const string ErrorText = "Triangle doesn't exists";
    
    // Implementation to determine triangle type
    // Return "Acute", "Obtuse", "Right", or an Error with the message based on side lengths
    // Pythagorean theorem.
    public static Result DetectType(decimal a, decimal b, decimal c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
        {
            return new Error<string>(ErrorText);
        }
        
        var pA = GetPower(a);
        var pB = GetPower(b);
        var pC = GetPower(c);
        var sides = new[] {pA, pB, pC}.OrderByDescending(x => x).ToArray();
        
        if (IsRightTriangle(sides))
        {
            return TriangleType.Right;
        }
        
        if (IsObtuseTriangle(sides))
        {
            return TriangleType.Obtuse;
        }
        if (IsAcuteTriangle(sides))
        {
            return TriangleType.Acute;
        }
        
        return new Error<string>(ErrorText);
    }
    
    private static decimal GetPower(decimal side) => side * side;

    private static bool IsRightTriangle(IReadOnlyList<decimal> sides)
    {
        // Check if the triangle satisfies the Pythagorean theorem
        return Math.Abs(sides[0] - sides[1] - sides[2]) == 0;
    }
    
    private static bool IsObtuseTriangle(IReadOnlyList<decimal> sides)
    {
        // Check if the triangle is obtuse (sum of squares of two sides less than square of the third side)
        return sides[0] > sides[1] + sides[2];
    }
    
    private static bool IsAcuteTriangle(IReadOnlyList<decimal> sides)
    {
        // Check if the triangle is acute (sum of squares of two sides greater than square of the third side)
        return sides[0] < sides[1] + sides[2];
    }
}
