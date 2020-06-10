using Quartz;
using quartz_app.core;
using quartz_app.db;
using System;
using System.Threading.Tasks;

namespace quartz_app
{
    public class MessageProcessorJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {

           QueueDBConnection connection = new QueueDBConnection();
           IMessage message = connection.ReadItemFromQueue("dbo.PaymentOrderProcessingQueue");
           if(message != null)
            {
                ProcessMessage(message);
            }
        }

        private void ProcessMessage(IMessage message)
        {
            // custom logic to process the queue message
        }
    }
}
