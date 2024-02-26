using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PDF.Core.Utilities
{
    public static class Extensions
    {
        private static JsonSerializerSettings GetSettings()
        {
            return new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public static T FromJsonString<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json, GetSettings());
        }

        public static decimal Rnd(this decimal value, int decimalPlaces)
        {
            return Math.Round(value, decimalPlaces);
        }
    }
}
