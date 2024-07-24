using Microsoft.AspNetCore.Http;

using ViewModel;
using ViewModel.MailSeting;


namespace IReprosastory
{
    public interface IMailingService
    {
        Task SendEmailAsync(MailRequestVM mailSettings);
    }
}


