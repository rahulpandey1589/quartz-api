using System;

namespace quartz_app.core
{
    public interface IMessage
    {
         Guid MessageId { get; set; }

         string MessageText { get; set; }
    }
}
