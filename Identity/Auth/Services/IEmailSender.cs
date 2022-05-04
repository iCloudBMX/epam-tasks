using Auth.Models;
using System.Threading.Tasks;

namespace Auth.Services
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}
