using System.IO;
using UnityEngine;

namespace IndividualGames.CaseLib.JSON
{
    /// <summary>
    /// Engage with JSON files through this class.
    /// </summary>
    public static class JsonReader<T> where T : IJsonData
    {
        public static T ReadJson(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            return JsonUtility.FromJson<T>(jsonContent);
        }
    }

    public interface IJsonData
    { }

    /// <summary>
    /// This is an example to pass to JsonReader.
    /// </summary>
    [System.Serializable]
    public class ExampleJsonDataHolder : IJsonData
    {
        public string firstLine;
        public string secondLine;
    }
}