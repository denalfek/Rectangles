namespace Triangles;

public class TypeDetector
{
    public static Type DetectTypeAsync(double a, double b, double c)
    {
        // Implementation to determine triangle type
        // Return "Acute", "Obtuse", or "Right" based on side lengths
        // You can use trigonometric properties to determine the angle relationships
        // For simplicity, we'll use the Pythagorean theorem for this example

        if (IsRightTriangle(a, b, c))
        {
            return Type.Right;
        }
        else if (IsObtuseTriangle(a, b, c))
        {
            return Type.Obtuse;
        }
        else
        {
            return Type.Acute;
        }
    }

    private static bool IsRightTriangle(double sideA, double sideB, double sideC)
    {
        // Check if the triangle satisfies the Pythagorean theorem
        return Math.Pow(sideA, 2) + Math.Pow(sideB, 2) == Math.Pow(sideC, 2) ||
               Math.Pow(sideA, 2) + Math.Pow(sideC, 2) == Math.Pow(sideB, 2) ||
               Math.Pow(sideB, 2) + Math.Pow(sideC, 2) == Math.Pow(sideA, 2);
    }

    private static bool IsObtuseTriangle(double sideA, double sideB, double sideC)
    {
        // Check if the triangle is obtuse (sum of squares of two sides less than square of the third side)
        return Math.Pow(sideA, 2) + Math.Pow(sideB, 2) < Math.Pow(sideC, 2) ||
               Math.Pow(sideA, 2) + Math.Pow(sideC, 2) < Math.Pow(sideB, 2) ||
               Math.Pow(sideB, 2) + Math.Pow(sideC, 2) < Math.Pow(sideA, 2);
    }
}
