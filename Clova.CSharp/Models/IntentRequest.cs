// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Clova.CSharp.Models;
//
//    var intentRequest = IntentRequest.FromJson(jsonString);

namespace Clova.CSharp.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class IntentRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("intent")]
        public Intent Intent { get; set; }
    }

    public partial class Intent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slots")]
        public IDictionary<string, Slot> Slots { get; set; }
    }

    public partial class Slot
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
