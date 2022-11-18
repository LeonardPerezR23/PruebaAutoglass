using PruebaAutoGlass.Application.Models;

namespace PruebaAutoGlass.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
          
        Task<bool> SendEmail(Email email);
    }
}
