using EmailApi.Models.Dto;

namespace EmailApi.Services
{
    public interface IEmailService
    {
        Task EmailCartLog(CartDto cartDto);
    }
}
