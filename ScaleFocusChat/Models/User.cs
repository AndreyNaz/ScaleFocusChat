using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScaleFocusChat.Models
{
    [Serializable]
    public class User
    {
        public User()
        {
            Messages = new List<Message>();
            GroupUsers = new List<GroupUser>();
            BlockedUsers = new List<User>();
        }

        public int UserId { get; set; }

        [Required]
        [MaxLength(32)]
        public string Username { get; set; }

        [MaxLength(128)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        public List<Message> Messages { get; set; }
        public List<GroupUser> GroupUsers { get; set; }

        public List<User> BlockedUsers { get; set; }
    }
}
