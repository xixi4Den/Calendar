using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Calendar.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling  = DateTimeZoneHandling.Local,
            };

            var serializer = JsonSerializer.Create(serializerSettings);
            var jw = new StringWriter();
            serializer.Serialize(jw, obj);
            return jw.ToString();
        }
    }
}