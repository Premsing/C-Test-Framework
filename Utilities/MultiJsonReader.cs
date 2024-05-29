using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CSharpFramework.Utilities
{
    public class TestDataSet
    {
        public LoginData Login { get; set; }
        public string[] ExpectedProducts { get; set; }
    }

    public class LoginData
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    class MultiJsonReader
    {
        private static List<TestDataSet> _testDataSets;

        static MultiJsonReader()
        {
            var json = File.ReadAllText("C:/Users/Prem/source/repos/CSharpFramework/Tests/MultiTestDataFile.json"); // Replace with the actual path to the JSON file
            var jObject = JObject.Parse(json);
            _testDataSets = jObject["testDataSets"].ToObject<List<TestDataSet>>();
        }

        public static IEnumerable<TestDataSet> GetTestDataSets()
        {
            return _testDataSets;
        }
    }
}
