using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScaleFocusChat.Models
{
    [Serializable]
    public class Message
    {
        public int MessageId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        public int TargetGroupId { get; set; }
        public Group TargetGroup { get; set; }

        public int TargetUserId { get; set; }
        public User TargetUser { get; set; }

        [Required]
        [MaxLength(4096)]
        public string MessageText { get; set; }
    }
}
