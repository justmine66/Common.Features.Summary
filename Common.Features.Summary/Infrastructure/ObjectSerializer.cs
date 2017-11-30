using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace Common.Features.Summary.Infrastructure
{
    internal static class ObjectSerializer
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };

        private static readonly JsonSerializer Serializer = new JsonSerializer
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };

        static ObjectSerializer()
        {
            settings.Converters.Add(new NameValueCollectionConverter());
        }

        public static string ToString(object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        public static T FromString<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public static JObject ToJObject(object o)
        {
            return JObject.FromObject(o, Serializer);
        }
    }
}
