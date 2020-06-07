using Quartz;
using quartz_app.core;
using quartz_app.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz_app
{
    public class MessageProcessorJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {

            QueueDBConnection connection = new QueueDBConnection();
           IMessage message = connection.ReadItemFromQueue("dbo.PaymentOrderProcessingQueue");

            Console.WriteLine("Executing Job At 10 seconds ");
        }
    }
}
