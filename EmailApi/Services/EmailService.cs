using EmailApi.Data;
using EmailApi.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace EmailApi.Services
{
    public class EmailService : IEmailService
    {/*
        private readonly IAzureServiceBusProducer _azureServiceBusProducer;
        private readonly IConfiguration _configuration;

        public EmailService(IAzureServiceBusProducer azureServiceBusProducer, IConfiguration configuration)
        {
            _azureServiceBusProducer = azureServiceBusProducer;
            _configuration = configuration;
        }

        public async Task EmailCartLog(CartDto cartDto)
        {
            await _azureServiceBusProducer.SendMessage(cartDto);
        }*/
        private DbContextOptions<AppDbContext> options;

        public EmailService(DbContextOptions<AppDbContext> options)
        {
            this.options = options;
        }

        public Task EmailCartLog(CartDto cartDto)
        {
            throw new NotImplementedException();
        }
    }
}
