using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Amqp.Framing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MessageBus
{
    public class MessageBus : IMessageBus
    {

        private string _connectionString = "Endpoint=sb://shoppingproject.servicebus.windows.net/;SharedAccessKeyName=emailShopping;SharedAccessKey=G31IgDpe6oTBhgHsY+6gZqfUyXjeQ8APT+ASbL6doz4=;EntityPath=emailshopping";
        public async Task PublishMessage(object message, string topic_queue_name)
        {
            //create an instance of ServiceBusClient using the connection string
            await using var client = new ServiceBusClient(_connectionString);

            //create a sender for the specified topic or queue.The sender is responsible for sending messages to the specified destination.
            ServiceBusSender sender = client.CreateSender(topic_queue_name);

            //serializes the message object (of type object) into a JSON string using JsonConvert, converts the message to its JSON representation.
            var jsonMessage = JsonConvert.SerializeObject(message);

            ServiceBusMessage FinalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                //correlation ID helps track related messages or events
                CorrelationId = Guid.NewGuid().ToString()
            };

            //sends the messageBus to the specified topic or queue using the sender.The SendMessageAsync method sends the message asynchronously.
            await sender.SendMessageAsync(FinalMessage);

            //This line disposes of the ServiceBusClient after use.Proper disposal ensures that resources are released.
            await client.DisposeAsync();
        }
    }
}
