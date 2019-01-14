using Microsoft.EntityFrameworkCore;
using ScaleFocusChat.Data;
using ScaleFocusChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScaleFocusChat.Services
{

    public interface IMessageService
    {
        Task<List<Message>> GetMessagesAsync();
        Task<List<Message>> GetMessagesForChatGroupAsync(int groupId);
        Task<bool> AddMessageToGroupAsync(int roomId, Message message);
    }

    public class MessageService : IMessageService
    {
        private readonly ScaleFocusChatDbContext _context;

        public MessageService(ScaleFocusChatDbContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetMessagesAsync()
        {
            var messages = await _context.Messages.ToListAsync<Message>();

            return messages;
        }

        public async Task<List<Message>> GetMessagesForChatGroupAsync(int groupId)
        {
            var messagesForRoom = await _context.Messages
                                      .Where(m => m.TargetGroupId == groupId)
                                               .ToListAsync();

            return messagesForRoom;
        }

        public async Task<bool> AddMessageToGroupAsync(int groupId, Message message)
        {
            message.TargetGroupId = groupId;
            message.TimeStamp = DateTime.Now;

            _context.Messages.Add(message);

            var saveResults = await _context.SaveChangesAsync();

            return saveResults > 0;
        }
    }
}
