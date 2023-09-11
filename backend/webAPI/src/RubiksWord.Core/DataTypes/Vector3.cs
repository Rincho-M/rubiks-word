using System.Text.RegularExpressions;

namespace RubiksWord.Core.DataTypes;

public struct Vector3
{
    private readonly System.Numerics.Vector3 _value;

    private const string _regexPattern = """^\((-?\d+(?:\.\d+)?),(-?\d+(?:\.\d+)?),(-?\d+(?:\.\d+)?)\)$""";
    private const string _parseExceptionMessage =
        "The parsed value had an invalid format. Correct format: (D,D,D), where D is decimal number.";

    public Vector3(float x, float y, float z)
    {
        _value = new System.Numerics.Vector3(x, y, z);
    }

    public override string ToString()
    {
        return $"({_value.X},{_value.Y},{_value.Z})";
    }

    public static Vector3 Parse(string vector3String)
    {
        Match result = Regex.Match(vector3String, _regexPattern);
        if (result.Success)
        {
            return new Vector3(
                float.Parse(result.Groups[1].Value),
                float.Parse(result.Groups[2].Value),
                float.Parse(result.Groups[3].Value)
            );
        }
        else
        {
            throw new FormatException(_parseExceptionMessage);
        }
    }
}
