using DMendez.Domain.Common;
using DMendez.Domain.Enums;

namespace DMendez.Domain.Entities.Notifications
{
    public class Notification : BaseEntity
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public NotificationTypeEnum Type { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime? ReadAt { get; set; }
    }
}