using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymOrganizer.Web.Aspects;
using Microsoft.Extensions.Logging;
using GymOrganizer.Web.Services;
using GymOrganizer.Web.ViewModels;

namespace GymOrganizer.Web.Controllers
{
    [Route("api/[controller]")]
    public class SchedulesController : BaseController
    {
        private ILogger<SchedulesController> logger;
        private readonly ScheduleService scheduleService;

        public SchedulesController(ILoggerFactory loggerFactory, ScheduleService scheduleService) : base(loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<SchedulesController>();
            this.scheduleService = scheduleService;
        }

        [HttpGet]
        [ExceptionHandlerAspect()]
        public async Task<IActionResult> Get()
        {
            return Json(await this.scheduleService.GetAllSchedules());
        }

        [HttpGet("{id}")]
        [ExceptionHandlerAspect()]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Json(await this.scheduleService.GetScheudleById(id));
        }


        [HttpPost]
        [ExceptionHandlerAspect()]
        public async Task<IActionResult> Post([FromBody]ScheduleVM schedule)
        {
            await this.scheduleService.AddSchedule(schedule);
            return Ok();

        }


        [HttpPut]
        [ExceptionHandlerAspect()]
        public async Task<IActionResult> Put([FromBody]ScheduleVM schedule)
        {
            await this.scheduleService.EditSchedule(schedule);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ExceptionHandlerAspect()]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.scheduleService.DeleteSchedule(id);
            return Ok();
        }
    }
}
