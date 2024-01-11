
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

public class NetJsonUtil
{
    class JsonPropertyContractResolver : DefaultContractResolver
    {

        protected override IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, memberSerialization).ToList().FindAll(it => it.Writable && !it.Ignored);
        }
    }

    private static JsonSerializerSettings _jsonSerializerWriteableSettings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Auto,
        DefaultValueHandling = DefaultValueHandling.Ignore,
        ContractResolver = new JsonPropertyContractResolver()
    };


    class JsonPublicContractResolver : DefaultContractResolver
    {

        protected override IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, MemberSerialization.OptOut).ToList().FindAll(it => it.Writable && !it.Ignored);
        }
    }

    private static JsonSerializerSettings _jsonSerializerPublicFieldSettings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Auto,
        DefaultValueHandling = DefaultValueHandling.Ignore,
        ContractResolver = new JsonPublicContractResolver()
    };

    public static string ToJson<T>(T val, bool indented, bool onlyPublicField = false)
    {
        return JsonConvert.SerializeObject(val, indented ? Formatting.Indented : Formatting.None, onlyPublicField ? _jsonSerializerPublicFieldSettings : _jsonSerializerWriteableSettings);
    }

    public static T FromJson<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }
}
