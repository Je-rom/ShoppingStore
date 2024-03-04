using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MessageBus
{
    public class MessageBus : IMessageBus
    {

        private string _connectionString = "Endpoint=sb://shoppingproject.servicebus.windows.net/;SharedAccessKeyName=service;SharedAccessKey=OyXkqd7cIcttCS+qZRqmewn1AObUDMRZK+ASbDVhwVg=;EntityPath=emailshopping";
        public async Task PublishMessage(object message, string topic_queue_name)
        {
            await using var client = new ServiceBusClient(_connectionString);

            ServiceBusSender sender = client.CreateSender(topic_queue_name);

            var jsonMessage = JsonConvert.SerializeObject(message);

            ServiceBusMessage messageBus = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString()
            };

            await sender.SendMessageAsync(messageBus);
            await sender.DisposeAsync();
        }
    }
}
