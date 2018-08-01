// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Clova.CSharp.Models;
//
//    var clovaResponse = ClovaResponse.FromJson(jsonString);

namespace Clova.CSharp.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ClovaResponse
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("sessionAttributes")]
        public SessionAttributes SessionAttributes { get; set; }

        [JsonProperty("response")]
        public Response Response { get; set; }
    }

    public partial class Response
    {
        [JsonProperty("outputSpeech")]
        public OutputSpeech OutputSpeech { get; set; }

        [JsonProperty("directives")]
        public Directive[] Directives { get; set; }

        [JsonProperty("card")]
        public SessionAttributes Card { get; set; }

        [JsonProperty("reprompt")]
        public Reprompt Reprompt { get; set; }

        [JsonProperty("shouldEndSession")]
        public bool ShouldEndSession { get; set; }
    }

    public partial class SessionAttributes
    {
    }

    public partial class Directive
    {
        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("payload")]
        public object Payload { get; set; }
    }

    public partial class Header
    {
        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class OutputSpeech
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("values")]
        public Values Values { get; set; }
    }

    public partial class Values
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class Reprompt
    {
        [JsonProperty("outputSpeech")]
        public OutputSpeech OutputSpeech { get; set; }
    }
}

