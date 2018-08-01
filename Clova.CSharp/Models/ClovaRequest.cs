// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Clova.CSharp.Models;
//
//    var clovaRequest = ClovaRequest.FromJson(jsonString);

namespace Clova.CSharp.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;

    public partial class ClovaRequest
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("session")]
        public Session Session { get; set; }

        [JsonProperty("context")]
        public Context Context { get; set; }

        [JsonProperty("request")]
        public JObject Request { get; set; }

        [JsonIgnore]
        public RequestType RequestType => (RequestType)Enum.Parse(
            typeof(RequestType), 
            Request?.GetValue("type")?.Value<string>() ?? nameof(RequestType.Unknown));
    }

    public partial class Context
    {
        [JsonProperty("System")]
        public SystemClass System { get; set; }
    }

    public partial class SystemClass
    {
        [JsonProperty("application")]
        public Application Application { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("device")]
        public Device Device { get; set; }
    }

    public partial class Application
    {
        [JsonProperty("applicationId")]
        public string ApplicationId { get; set; }
    }

    public partial class Device
    {
        [JsonProperty("deviceId")]
        public Guid DeviceId { get; set; }

        [JsonProperty("display")]
        public Display Display { get; set; }
    }

    public partial class Display
    {
        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("orientation")]
        public string Orientation { get; set; }

        [JsonProperty("dpi")]
        public long Dpi { get; set; }

        [JsonProperty("contentLayer")]
        public ContentLayer ContentLayer { get; set; }
    }

    public partial class ContentLayer
    {
        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public partial class User
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
    }

    public partial class Session
    {
        [JsonProperty("new")]
        public bool New { get; set; }

        [JsonProperty("sessionAttributes")]
        public IDictionary<string, object> SessionAttributes { get; set; }

        [JsonProperty("sessionId")]
        public Guid SessionId { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public partial class ClovaRequest
    {
        public static ClovaRequest FromJson(string json) => JsonConvert.DeserializeObject<ClovaRequest>(json, Clova.CSharp.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ClovaRequest self) => JsonConvert.SerializeObject(self, Clova.CSharp.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
