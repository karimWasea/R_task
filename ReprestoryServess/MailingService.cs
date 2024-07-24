using DataAccessLayer;

using DataACesslayer;

using IReprosastory;

using MailKit.Security;

using Microsoft.AspNetCore.Http;
 
using Microsoft.Extensions.Options;
 
using MimeKit;
 

using ViewModel;
using ViewModel.MailSeting;
using MailKit.Net.Smtp;
 
 
namespace ReprestoryServess
{
    public class MailingService : IMailingService
    {
        private readonly MailSettings _mailSettings;

        public MailingService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequestVM mailRequestVM)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailSettings.Email),
                Subject = mailRequestVM.Subject,   
            };

            email.To.Add(MailboxAddress.Parse(mailRequestVM.ToEmail));

            var builder = new BodyBuilder();

            if (mailRequestVM.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequestVM.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using var ms = new MemoryStream();
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();

                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            builder.HtmlBody = mailRequestVM.Body;
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
            await smtp.SendAsync(email);

            smtp.Disconnect(true);
        }
    }

}