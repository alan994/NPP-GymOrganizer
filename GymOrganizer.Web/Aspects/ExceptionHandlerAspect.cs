using GymOrganizer.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GymOrganizer.Web.Aspects
{
    [PSerializable]
    public class ExceptionHandlerAspect : OnExceptionAspect
    {
        
        public override void OnException(MethodExecutionArgs args)
        {
            if(args.Instance != null)
            {
                var logger = (args.Instance as BaseController).GetLogger<ExceptionHandlerAspect>();
                logger.LogInformation($"Alan - Exception handled {args.Exception.Message}");
            }
            args.FlowBehavior = FlowBehavior.Return;
            args.ReturnValue = new BadRequestResult();
        }
    }
}
