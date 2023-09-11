using System.Text.RegularExpressions;

namespace RubiksWord.Core.DataTypes;

public struct Quaternion
{
    private readonly System.Numerics.Quaternion _value;

    private const string _regexPattern = """^\((-?\d+(?:\.\d+)?),(-?\d+(?:\.\d+)?),(-?\d+(?:\.\d+)?),(-?\d+(?:\.\d+)?)\)$""";
    private const string _parseExceptionMessage =
        "The parsed value had an invalid format. Correct format: (D,D,D,D), where D is decimal number.";

    public Quaternion(float w, float x, float y, float z)
    {
        _value = new System.Numerics.Quaternion(x, y, z, w);
    }

    public override string ToString()
    {
        return $"({_value.W},{_value.X},{_value.Y},{_value.Z})";
    }

    public static Quaternion Parse(string quaternionString)
    {
        Match result = Regex.Match(quaternionString, _regexPattern);
        if (result.Success)
        {
            return new Quaternion(
                float.Parse(result.Groups[1].Value),
                float.Parse(result.Groups[2].Value),
                float.Parse(result.Groups[3].Value),
                float.Parse(result.Groups[4].Value)
            );
        }
        else
        {
            throw new FormatException(_parseExceptionMessage);
        }
    }
}

