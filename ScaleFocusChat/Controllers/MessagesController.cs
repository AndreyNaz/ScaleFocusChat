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
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // GET: api/Messages
        public async Task<IActionResult> Get()
        {
            var GroupMessages = await _messageService.GetMessagesAsync();

            return Ok(GroupMessages);
        }

        // GET: api/Messages/5
        [HttpGet("{groupId}")]
        public async Task<IActionResult> Get(int groupId)
        {
            var groupMessages = await _messageService.GetMessagesForChatGroupAsync(groupId);

            return Ok(groupMessages);
        }

        // POST: api/Messages
        [HttpPost]
        public async void Post([FromBody] Message message)
        {
            await _messageService.AddMessageToGroupAsync(message.TargetGroupId, message);
        }
    }
    }
}
