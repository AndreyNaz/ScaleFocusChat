using Microsoft.EntityFrameworkCore;
using ScaleFocusChat.Data;
using ScaleFocusChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScaleFocusChat.Services
{
    public interface IGroupService
    {
        Task<List<Group>> GetGroupsAsync();
        Task<bool> AddGroupAsync(Group newGroup);
    }

    public class GroupService : IGroupService
    {
        private readonly ScaleFocusChatDbContext _context;

        public GroupService(ScaleFocusChatDbContext context)
        {
            _context = context;
        }

        public async Task<List<Group>> GetGroupsAsync()
        {
            var groups = await _context.Groups.ToListAsync();

            return groups;
        }

        public async Task<bool> AddGroupAsync(Group group)
        {
            _context.Groups.Add(group);

            var saveResults = await _context.SaveChangesAsync();

            return saveResults > 0;
        }
    }
}
