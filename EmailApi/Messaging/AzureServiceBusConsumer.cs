using Azure.Messaging.ServiceBus;

namespace EmailApi.Messaging
{
    public class AzureServiceBusConsumer
    {
        private readonly string _connectionString;
        private readonly string _emailQueue;
        private readonly IConfiguration _configuration;

        public AzureServiceBusConsumer(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
            _emailQueue = _configuration.GetValue<string>("TopicAndQueueNames:emailshoppingQueue");
        }

        public void RegisterOnMessageHandlerAndReceiveMessages()
        {
            var client = new ServiceBusClient(_connectionString);
            var processor = client.CreateProcessor(_emailQueue, new ServiceBusProcessorOptions()); // to listen to a queue or a topic

            processor.ProcessMessageAsync += ProcessMessages;
            processor.ProcessErrorAsync += ProcessError;

            await processor.StartProcessingAsync();
        }

      /*  private async Task ProcessMessages(ProcessMessageEventArgs args)
        {
            var body = args.Message.Body.ToString();
            var email = JsonSerializer.Deserialize<EmailLogger>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            _logger.LogInformation($"Received message: {email.Id} - {email.Email}");

            await args.CompleteMessageAsync(args.Message);
        }

        private Task ProcessError(ProcessErrorEventArgs args)
        {
            _logger.LogError(args.Exception, "Error when receiving message from Azure Service Bus");

            return Task.CompletedTask;
        }*/
    }
}
