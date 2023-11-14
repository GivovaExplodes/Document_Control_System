using System.Globalization;
public static class CsvUtility
{
    public static void WriteRecords<T>(string filePath, IEnumerable<T> records)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(records);
        }
    }
}
