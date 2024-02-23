using System.Globalization;
using System.Text.RegularExpressions;

namespace RubiksWord.Domain.DataTypes;

public struct Quaternion
{
    private readonly System.Numerics.Quaternion _value;

    private const string _regexPattern = """^\((-?\d+(?:\.[\dE-]+)?),(-?\d+(?:\.[\dE-]+)?),(-?\d+(?:\.[\dE-]+)?),(-?\d+(?:\.[\dE-]+)?)\)$""";
    private const string _parseExceptionMessage =
        "The parsed value had an invalid format. Correct format: (D,D,D,D), where D is decimal number.";

    public Quaternion(float w, float x, float y, float z)
    {
        _value = new System.Numerics.Quaternion(x, y, z, w);
    }

    public override string ToString()
    {
        return string.Format(
            CultureInfo.InvariantCulture, 
            "({0},{1},{2},{3})", 
            _value.W, _value.X, _value.Y, _value.Z);
    }

    public static Quaternion Parse(string quaternionString)
    {
        Match result = Regex.Match(quaternionString, _regexPattern);
        if (result.Success)
        {
            return new Quaternion(
                float.Parse(result.Groups[1].Value, CultureInfo.InvariantCulture),
                float.Parse(result.Groups[2].Value, CultureInfo.InvariantCulture),
                float.Parse(result.Groups[3].Value, CultureInfo.InvariantCulture),
                float.Parse(result.Groups[4].Value, CultureInfo.InvariantCulture)
            );
        }
        else
        {
            throw new FormatException(_parseExceptionMessage);
        }
    }
}

