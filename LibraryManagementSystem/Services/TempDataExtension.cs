using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

//Able to extract non-primitive objects from TempData functionality
//Specifically used to store and retrieve Lists of type ReservationModel and BookModel
//Code taken from https://stackoverflow.com/a/35042391
public static class TempDataExtension
{
    public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
    {
        tempData[key] = JsonSerializer.Serialize(value);
    }

    public static T? Get<T>(this ITempDataDictionary tempData, string key) where T : class
    {
        object o;
        tempData.TryGetValue(key, out o);
        return o == null ? null : JsonSerializer.Deserialize<T>((string)o);
    }
}