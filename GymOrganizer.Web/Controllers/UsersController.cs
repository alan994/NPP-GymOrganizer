using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymOrganizer.Web.Aspects;
using Microsoft.Extensions.Logging;
using GymOrganizer.Web.Services;
using GymOrganizer.Web.ViewModels;
using System.Collections.Generic;

namespace GymOrganizer.Web.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private ILogger<UsersController> logger;
        private readonly UserService userService;

        public UsersController(ILoggerFactory loggerFactory, UserService userService) : base(loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<UsersController>();
            this.userService = userService;
        }

        [HttpGet]
        [ExceptionHandlerAspect()]
        public async Task<List<UserVM>> Get()
        {
            return await this.userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        [ExceptionHandlerAspect()]
        public async Task<UserVM> GetById(Guid id)
        {
            return await this.userService.GetUserById(id);
        }

        
        [HttpPost]
        [ExceptionHandlerAspect()]
        public async Task<IActionResult> Post([FromBody]UserVM user)
        {
            await this.userService.AddUser(user);
            return Ok();            
        }

        
        [HttpPut]
        [ExceptionHandlerAspect()]
        public async Task<IActionResult> Put([FromBody]UserVM user)
        {
            await this.userService.EditUser(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ExceptionHandlerAspect()]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.userService.DeleteUser(id);
            return Ok();
        }
    }
}
