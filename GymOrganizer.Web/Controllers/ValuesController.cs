using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymOrganizer.Web.Aspects;
using Microsoft.Extensions.Logging;

namespace GymOrganizer.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        private ILogger<ValuesController> _logger;

        public ValuesController(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ValuesController>();
        }
        // GET api/values
        [HttpGet]
        [ExceptionHandlerAspect()]
        public IActionResult Get()
        {
            _logger.LogInformation("Info logged");
            throw new Exception();
            return Json(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
