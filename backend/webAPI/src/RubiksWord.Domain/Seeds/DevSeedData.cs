using RubiksWord.Domain.DataTypes;
using RubiksWord.Domain.Entities;

namespace RubiksWord.Domain.Seeds;

/// <summary>
/// Seed data for development.
/// </summary>
public static class DevSeedData
{
    private static Dictionary<string, string> _coordsMap = new()
    {
        { "1,1", "1" },
        { "1,2", "2" },
        { "1,3", "3" },
        { "2,1", "4" },
        { "2,2", "5" },
        { "2,3", "6" },
        { "3,1", "7" },
        { "3,2", "8" },
        { "3,3", "9" },
    };

    public static Cube GetTestCube()
    {
        int sideLength = 5;

        Cube testCube = new()
        {
            Id = 1,
            Name = "test",
            SideLength = sideLength,
        };
        var ToRad = (double deg) => deg * (Math.PI / 180.0);
        for (int x = 0; x < sideLength; x++)
        {
            for (int y = 0; y < sideLength; y++)
            {
                for (int z = 0; z < sideLength; z++)
                {
                    // Dont create points on edges and inside of the cube.
                    if ((x == 0 || x == (sideLength - 1)) && (y != 0 && y != (sideLength - 1)) && (z != 0 && z != (sideLength - 1)) ||
                        (x != 0 && x != (sideLength - 1)) && (y == 0 || y == (sideLength - 1)) && (z != 0 && z != (sideLength - 1)) ||
                        (x != 0 && x != (sideLength - 1)) && (y != 0 && y != (sideLength - 1)) && (z == 0 || z == (sideLength - 1)))
                    {
                        Quaternion orientation;
                        if (x == (sideLength - 1))
                        {
                            orientation = new(1, 0, 0, 0);
                        }
                        else if (x == 0)
                        {
                            orientation = new((float)-Math.Cos(ToRad(180) / 2), 0, 0, (float)Math.Sin(ToRad(180) / 2));
                        }
                        else if (y == (sideLength - 1))
                        {
                            orientation = new((float)-Math.Cos(ToRad(ToRad(90) / 2)), 0, (float)Math.Sin(ToRad(ToRad(90) / 2)), 0);
                        }
                        else if (y == 0)
                        {
                            orientation = new((float)Math.Cos(ToRad(ToRad(90) / 2)), 0, (float)Math.Sin(ToRad(ToRad(90) / 2)), 0);
                        }
                        else if (z == (sideLength - 1))
                        {
                            orientation = new((float)-Math.Cos(ToRad(90) / 2), 0, 0, (float)Math.Sin(ToRad(90) / 2));
                        }
                        else
                        {
                            orientation = new((float)-Math.Cos(ToRad(270) / 2), 0, 0, (float)Math.Sin(ToRad(270) / 2));
                        }
                        string value = "t";
                        if (x == sideLength - 1 && _coordsMap.TryGetValue($"{y},{z}", out string temp)) value = temp;
                        Point testPoint = new()
                        {
                            Color = "red",
                            Position = new(x, y, z),
                            Orientation = orientation,
                            Letters = new string[,] { { value, "p", "s", "g" }, { "a", "o", "u", "e" }, { "q", "n", "k", "m" }, { "n", "h", "o", "j" }, },
                            Cube = testCube,
                        };

                        testCube.Points.Add(testPoint);
                        Console.WriteLine($"{x},{y},{z}");
                    }
                }
            }
        }
        return testCube;
    }
}
