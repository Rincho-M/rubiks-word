using AutoMapper;

namespace RubiksWord.API.Mappers;

public class JaggedStringArrayTypeConverter : ITypeConverter<string[,], string[][]>
{
    public string[][] Convert(string[,] source, string[][] destination, ResolutionContext context)
    {
        if (source is null) return null;

        int x = source.GetLength(0);
        int y = source.GetLength(1);
        string[][] result = new string[x][];

        for (int i = 0; i < x; i++)
        {
            result[i] = new string[y];
            for (int k = 0; k < y; k++)
            {
                result[i][k] = source[i, k];
            }
        }

        return result;
    }
}
