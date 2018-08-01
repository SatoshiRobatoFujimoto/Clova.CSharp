using System;
using System.Collections.Generic;
using System.Text;

namespace Clova.CSharp.Models
{
    public enum RequestType
    {
        Unknown,
        EventRequest,
        IntentRequest,
        LaunchRequest,
        SessionEndedRequest,
    }
}
