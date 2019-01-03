using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScaleFocusChat.Models
{
    [Serializable]
    public class Group
    {
        public Group()
        {
            Messages = new List<Message>();
            GroupUsers = new List<GroupUser>();
        }

        public int GroupId { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsPublic { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public List<Message> Messages { get; set; }
        public List<GroupUser> GroupUsers { get; set; }
    }
}
