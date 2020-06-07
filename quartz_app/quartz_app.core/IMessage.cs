using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz_app.core
{
    public interface IMessage
    {
         Guid MessageId { get; set; }

         string MessageText { get; set; }
    }
}
