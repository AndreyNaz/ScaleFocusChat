using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScaleFocusChat.Data;
using ScaleFocusChat.Models;
using ScaleFocusChat.Services;

namespace ScaleFocusChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var groups = await _groupService.GetGroupsAsync();

            return Ok(groups);
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody]Group group)
        {
            await _groupService.AddGroupAsync(group);
        }
    }
}
