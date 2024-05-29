using System.IO;
using Newtonsoft.Json.Linq;

namespace CSharpFramework.Utilities
{
    class JsonReader
    {
        private static JObject _jObject;

        static JsonReader()
        {
            var json = File.ReadAllText("C:/Users/Prem/source/repos/CSharpFramework/Tests/TestDataFile.json"); // Replace with the actual path to the JSON file
            _jObject = JObject.Parse(json);
        }

        public static string GetUsername()
        {
            return _jObject["login"]["username"].ToString();
        }

        public static string GetPassword()
        {
            return _jObject["login"]["password"].ToString();
        }

        public static string[] GetExpectedProducts()
        {
            return _jObject["expectedProducts"].ToObject<string[]>();
        }
    }
}
