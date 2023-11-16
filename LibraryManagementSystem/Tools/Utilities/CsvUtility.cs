using System.Globalization;
using CsvHelper;

public static class CsvUtility
{
    public static void WriteRecord<T>(string filePath, T record)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecord(record);
        }
    }
}
