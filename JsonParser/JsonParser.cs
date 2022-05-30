using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonParser
{
    public static class JsonParser <T>
    {
        public static T ParseFromFile(string pathToFile)
        {
            var fileText = File.ReadAllText(pathToFile);
            var dateFormat = "dd/MM/yyyy";
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = dateFormat };

            return JsonConvert.DeserializeObject<T>(fileText, dateTimeConverter);
        }

        public static void WriteJsonToFile(string pathToFile, T jsonObject)
        {
            using (StreamWriter sw = File.CreateText(pathToFile))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(sw, jsonObject);
            }
        }
    }
}