using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBus
{
    public class MessageBus : IMessageBus
    {

        private string _connectionString = "Endpoint=sb://shoppingproject.servicebus.windows.net/;SharedAccessKeyName=service;SharedAccessKey=OyXkqd7cIcttCS+qZRqmewn1AObUDMRZK+ASbDVhwVg=;EntityPath=emailshopping";
        public async Task PublishMessage(object message, string topic_queue_name)
        {
            await using var client = new ServiceBusClient(_connectionString);
        }
    }
}
