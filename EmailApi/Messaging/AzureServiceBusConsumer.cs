using Azure.Messaging.ServiceBus;
using EmailApi.Models.Dto;
using EmailApi.Services;
using Newtonsoft.Json;
using System.Text;

namespace EmailApi.Messaging
{
    public class AzureServiceBusConsumer : IAzureServiceBusConsumer
    {
        private readonly string _connectionString;
        private readonly string _emailQueue;

        private readonly IConfiguration _configuration;
      
        private readonly EmailService _emailService;

        private ServiceBusProcessor Emailprocessor;



        public AzureServiceBusConsumer(IConfiguration configuration, EmailService emailService)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("ServiceBusConnectionString");

            _emailQueue = _configuration.GetValue<string>("TopicAndQueueNames:emailshoppingQueue");



            var client = new ServiceBusClient(_connectionString); //create a service bus client on the connection string
            Emailprocessor = client.CreateProcessor(_emailQueue); // to listen to a queue or a topic
          
            _emailService = emailService;
        }

        public async Task Start()
        {
            Emailprocessor.ProcessMessageAsync += OnEmailCartRequestedReceived;
            Emailprocessor.ProcessErrorAsync += ErrorHandler;
            await Emailprocessor.StartProcessingAsync();

        }

       
        public async Task Stop()
        {
            await Emailprocessor.StopProcessingAsync();
            await Emailprocessor.DisposeAsync();

        }


        private async Task OnEmailCartRequestedReceived(ProcessMessageEventArgs args)
        {
            //where you will receive the message
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);
            CartDto objMessage = JsonConvert.DeserializeObject<CartDto>(body);

            try
            {
                //try to log the email
                await _emailService.EmailCartLog(objMessage);
                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception ex)
            {
                throw;
            }  
        }



        private async Task ErrorHandler(ProcessErrorEventArgs args)
        {
            /*_logger.LogError(args.Exception, "Error when receiving message from Azure Service Bus");

            await Task.CompletedTask;*/
        }   


    }
}
