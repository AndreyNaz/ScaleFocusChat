using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScaleFocusChat.Models
{
    [Serializable]
    public class GroupUser
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
        
    }
}
