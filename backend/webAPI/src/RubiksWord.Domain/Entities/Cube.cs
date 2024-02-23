using RubiksWord.Domain.DataTypes;

namespace RubiksWord.Domain.Entities;

public class Cube
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int SideLength { get; set; }

    public ICollection<Point> Points { get; set; } = new List<Point>();

    private ICollection<Point> _rotationPoints;

    // TODO:
    // Two problems:
    // 1) I need to work with multidimentional array but in db I have one-dimentional
    // 2) SideLength cant be default parameter
    //private void RotatePoints(
    //    Quaternion rotation,
    //    int xStart = 0, int xEnd = SideLength - 1,
    //    int yStart = 0, int yEnd = SideLength - 1,
    //    int zStart = 0, int zEnd = SideLength - 1)
    //{
    //    for (int x = 0; x < SideLength; x++)
    //    {
    //        for (int y = 0; y < SideLength; y++)
    //        {
    //            for (int z = 0; z < SideLength; z++)
    //            {
    //                if (Points[x, y, z] is null) continue;

    //                if (x >= xStart && x <= xEnd &&
    //                    y >= yStart && y <= yEnd &&
    //                    z >= zStart && z <= zEnd)
    //                {
    //                    Quaternion currentPosition = new(0, x, y, z);
    //                    currentPosition.SubFromVectorPart(2);
    //                    Quaternion newPosition = rotation * currentPosition * rotation.GetConjugate();
    //                    newPosition.AddToVectorPart(2);

    //                    int xUpdated = (int)Math.Round(newPosition[1]);
    //                    int yUpdated = (int)Math.Round(newPosition[2]);
    //                    int zUpdated = (int)Math.Round(newPosition[3]);
    //                    _pointsUpdated[xUpdated, yUpdated, zUpdated] = _pointsCurrent[x, y, z];

    //                    Quaternion updatedOrientation = rotation * _pointsCurrent[x, y, z].Orientation;
    //                    _pointsUpdated[xUpdated, yUpdated, zUpdated].Orientation = updatedOrientation.GetNormalized();
    //                }
    //                else
    //                {
    //                    _pointsUpdated[x, y, z] = _pointsCurrent[x, y, z];
    //                }
    //            }
    //        }
    //    }

    //    var temp = _pointsCurrent;
    //    _pointsCurrent = _pointsUpdated;
    //    _pointsUpdated = temp;
    //}
}
