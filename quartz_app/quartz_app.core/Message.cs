using System;

namespace quartz_app.core
{
    public class Message : IMessage
    {
        public Guid MessageId { get; set; }
        public string MessageText { get; set; }
    }
}
