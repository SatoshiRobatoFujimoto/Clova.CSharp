using Clova.CSharp.Models;
using System;
using Xunit;

namespace Clova.CSharp.Tests
{
    public class ClovaRequestTest
    {
        [Fact]
        public void ParseEventRequest()
        {
            var json = @"{
  ""version"": ""1.0"",
  ""session"": {
    ""new"": false,
    ""sessionAttributes"": {},
    ""sessionId"": ""a29cfead-c5ba-474d-8745-6c1a6625f0c5"",
    ""user"": {
      ""userId"": ""U399a1e08a8d474521fc4bbd8c7b4148f"",
      ""accessToken"": ""XHapQasdfsdfFsdfasdflQQ7""
    }
  },
  ""context"": {
    ""System"": {
      ""application"": {
        ""applicationId"": ""com.yourdomain.extension.pizzabot""
      },
      ""user"": {
        ""userId"": ""U399a1e08a8d474521fc4bbd8c7b4148f"",
        ""accessToken"": ""XHapQasdfsdfFsdfasdflQQ7""
      },
      ""device"": {
        ""deviceId"": ""096e6b27-1717-33e9-b0a7-510a48658a9b"",
        ""display"": {
          ""size"": ""l100"",
          ""orientation"": ""landscape"",
          ""dpi"": 96,
          ""contentLayer"": {
            ""width"": 640,
            ""height"": 360
          }
        }
      }
    }
  },
  ""request"": {
    ""type"": ""EventRequest"",
    ""requestId"": ""f09874hiudf-sdf-4wku-flksdjfo4hjsdf"",
    ""timestamp"": ""2018-06-11T09:19:23Z"",
    ""event"" : {
      ""namespace"":""ClovaSkill"",
      ""name"":""SkillEnabled"",
      ""payload"": null
    }
  }
}";
            var request = ClovaRequest.FromJson(json);
            Assert.Equal(RequestType.EventRequest, request.RequestType);
            var eventRequest = request.Request.ToObject<EventRequest>();
            Assert.Equal("f09874hiudf-sdf-4wku-flksdjfo4hjsdf", eventRequest.RequestId);
            Assert.Equal("2018-06-11T09:19:23Z", eventRequest.Timestamp);

            Assert.Equal("ClovaSkill", eventRequest.Event.Namespace);
            Assert.Equal("SkillEnabled", eventRequest.Event.Name);
            Assert.Null(eventRequest.Event.Payload);
        }
        [Fact]
        public void ParseIntentRequest()
        {
            var json = @"{
  ""version"": ""1.0"",
  ""session"": {
    ""new"": false,
    ""sessionAttributes"": {},
    ""sessionId"": ""a29cfead-c5ba-474d-8745-6c1a6625f0c5"",
    ""user"": {
      ""userId"": ""U399a1e08a8d474521fc4bbd8c7b4148f"",
      ""accessToken"": ""XHapQasdfsdfFsdfasdflQQ7""
    }
  },
  ""context"": {
    ""System"": {
      ""application"": {
        ""applicationId"": ""com.yourdomain.extension.pizzabot""
      },
      ""user"": {
        ""userId"": ""U399a1e08a8d474521fc4bbd8c7b4148f"",
        ""accessToken"": ""XHapQasdfsdfFsdfasdflQQ7""
      },
      ""device"": {
        ""deviceId"": ""096e6b27-1717-33e9-b0a7-510a48658a9b"",
        ""display"": {
          ""size"": ""l100"",
          ""orientation"": ""landscape"",
          ""dpi"": 96,
          ""contentLayer"": {
            ""width"": 640,
            ""height"": 360
          }
        }
      }
    }
  },
  ""request"": {
    ""type"": ""IntentRequest"",
    ""intent"": {
      ""name"": ""OrderPizza"",
      ""slots"": {
        ""pizzaType"": {
          ""name"": ""pizzaType"",
          ""value"": ""ペパロニ""
        }
      }
    }
  }
}";
            var request = ClovaRequest.FromJson(json);
            Assert.Equal(RequestType.IntentRequest, request.RequestType);
            var intentRequest = request.Request.ToObject<IntentRequest>();
            Assert.Equal("OrderPizza", intentRequest.Intent.Name);
            Assert.Equal("pizzaType", intentRequest.Intent.Slots["pizzaType"].Name);
            Assert.Equal("ペパロニ", intentRequest.Intent.Slots["pizzaType"].Value);
        }

        [Fact]
        public void ParseLaunchRequest()
        {
            var json = @"{
  ""version"": ""1.0"",
  ""session"": {
    ""new"": true,
    ""sessionAttributes"": {},
    ""sessionId"": ""a29cfead-c5ba-474d-8745-6c1a6625f0c5"",
    ""user"": {
      ""userId"": ""U399a1e08a8d474521fc4bbd8c7b4148f"",
      ""accessToken"": ""XHapQasdfsdfFsdfasdflQQ7""
    }
  },
  ""context"": {
    ""System"": {
      ""application"": {
        ""applicationId"": ""com.yourdomain.extension.pizzabot""
      },
      ""user"": {
        ""userId"": ""U399a1e08a8d474521fc4bbd8c7b4148f"",
        ""accessToken"": ""XHapQasdfsdfFsdfasdflQQ7""
      },
      ""device"": {
        ""deviceId"": ""096e6b27-1717-33e9-b0a7-510a48658a9b"",
        ""display"": {
          ""size"": ""l100"",
          ""orientation"": ""landscape"",
          ""dpi"": 96,
          ""contentLayer"": {
            ""width"": 640,
            ""height"": 360
          }
        }
      }
    }
  },
  ""request"": {
    ""type"": ""LaunchRequest""
  }
}";
            var request = ClovaRequest.FromJson(json);
            Assert.Equal(RequestType.LaunchRequest, request.RequestType);
        }

        [Fact]
        public void ParseSessionEndedRequest()
        {
            var json = @"{
  ""version"": ""1.0"",
  ""session"": {
    ""new"": false,
    ""sessionAttributes"": {},
    ""sessionId"": ""a29cfead-c5ba-474d-8745-6c1a6625f0c5"",
    ""user"": {
      ""userId"": ""U399a1e08a8d474521fc4bbd8c7b4148f"",
      ""accessToken"": ""XHapQasdfsdfFsdfasdflQQ7""
    }
  },
  ""context"": {
    ""System"": {
      ""application"": {
        ""applicationId"": ""com.yourdomain.extension.pizzabot""
      },
      ""user"": {
        ""userId"": ""U399a1e08a8d474521fc4bbd8c7b4148f"",
        ""accessToken"": ""XHapQasdfsdfFsdfasdflQQ7""
      },
      ""device"": {
        ""deviceId"": ""096e6b27-1717-33e9-b0a7-510a48658a9b"",
        ""display"": {
          ""size"": ""l100"",
          ""orientation"": ""landscape"",
          ""dpi"": 96,
          ""contentLayer"": {
            ""width"": 640,
            ""height"": 360
          }
        }
      }
    }
  },
  ""request"": {
    ""type"": ""SessionEndedRequest""
  }
}";
            var request = ClovaRequest.FromJson(json);
            Assert.Equal(RequestType.SessionEndedRequest, request.RequestType);
        }
    }

}
