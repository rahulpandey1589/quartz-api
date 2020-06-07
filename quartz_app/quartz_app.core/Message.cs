using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz_app.core
{
    public class Message : IMessage
    {
        public Guid MessageId { get; set; }
        public string MessageText { get; set; }
    }
}
