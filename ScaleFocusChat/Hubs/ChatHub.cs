using Microsoft.AspNetCore.SignalR;
using ScaleFocusChat.Models;
using ScaleFocusChat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScaleFocusChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IGroupService _groupService;
        private readonly IMessageService _messageService;
        public int UsersOnline;

        public ChatHub(IGroupService groupService, IMessageService messageService)
        {
            _groupService = groupService;
            _messageService = messageService;
        }

        public async Task SendMessage(int groupId, int userId, string messageText)
        {
            Message m = new Message()
            {
                TargetGroupId = groupId,
                MessageText = messageText,
                UserId = userId
            };

            await _messageService.AddMessageToGroupAsync(groupId, m);
            await Clients.All.SendAsync("ReceiveMessage", userId, messageText, groupId, m.MessageId, m.TimeStamp);
        }

        public async Task AddGroup(string groupName)
        {
            Group group = new Group()
            {
                Name = groupName
            };

            await _groupService.AddGroupAsync(group);
            await Clients.All.SendAsync("NewRoom", groupName, group.GroupId);
        }

        public override async Task OnConnectedAsync()
        {
            UsersOnline++;
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            UsersOnline--;
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
}
