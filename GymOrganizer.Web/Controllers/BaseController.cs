using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymOrganizer.Web.Controllers
{
    public class BaseController : Controller
    {
        private ILoggerFactory _loggerFactory;

        public BaseController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public ILogger<T> GetLogger<T>()
        {
            return _loggerFactory.CreateLogger<T>();
        }
    }
}
