namespace Clova.CSharp.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;

    public partial class EventRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("event")]
        public Event Event { get; set; }
    }

    public partial class Event
    {
        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("payload")]
        public JObject Payload { get; set; }
    }
}
