
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Clova.CSharp.Models;
using Microsoft.Extensions.Logging;
using System;

namespace Clova.DiceSkill
{
    public static class Clova
    {
        private static Random Random { get; } = new Random();

        [FunctionName("clova")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequest httpRequest, ILogger log)
        {
            var s = new StreamReader(httpRequest.Body);
            var json = s.ReadToEnd();
            log.LogInformation(json);
            var req = ClovaRequest.FromJson(json);
            if (req.RequestType == RequestType.IntentRequest)
            {
                var intentRequest = req.Request.ToObject<IntentRequest>();
                switch (intentRequest.Intent.Name)
                {
                    case "ThrowDiceIntent":
                        return CreateSimpleTextResponse($"�T�C�R����1�����܂��B���ʂ�{Random.Next(1, 7)}�ł��B", true);
                    default:
                        return CreateSimpleTextResponse("�����܂���B�悭�킩��܂���B�T�C�R����U���ĂƘb�������Ă��������B");
                }
            }

            if (req.RequestType == RequestType.LaunchRequest)
            {
                return CreateSimpleTextResponse("����ɂ��́B�T�C�R����U���ĂƘb�������Ă��������B");
            }

            if (req.RequestType == RequestType.SessionEndedRequest)
            {
                return CreateSimpleTextResponse("���悤�Ȃ�B");
            }

            if (req.RequestType == RequestType.EventRequest)
            {
                return CreateSimpleTextResponse("�����܂���B�C�x���g�ɂ͑Ή����Ă��܂���B");
            }

            throw new InvalidOperationException();
        }

        private static JsonResult CreateSimpleTextResponse(string text, bool shouldEndSession = false)
        {
            return new JsonResult(new ClovaResponse
            {
                Response = new Response
                {
                    OutputSpeech = new OutputSpeech
                    {
                        Type = "SimpleSpeech",
                        Values = new Values
                        {
                            Type = "PlainText",
                            Lang = "ja",
                            Value = text,
                        },
                    },
                    ShouldEndSession = shouldEndSession,
                }
            });
        }
    }
}
