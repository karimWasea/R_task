    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using IReprosastory;

    using Microsoft.Extensions.Hosting;

    using ViewModel.MailSeting;
    namespace ReprestoryServess
    {
        public class ReminderSerivce(IServiceProvider serviceProvider , MailingService mailingService) : IHostedService, IDisposable
        {
      
            private readonly IServiceProvider _serviceProvider = serviceProvider;
            private readonly IMailingService _iMailingService= mailingService;
            private Timer _timer;
            private DateTime _lastTime;
     
            public Task StartAsync(CancellationToken cancellationToken)
            {
                DateTime now=DateTime.Now;
                DateTime nextTime = new DateTime(now.Year, now.Month, now.Day, 10, 0, 0);
                    if(now>nextTime)
                {
                    nextTime = nextTime.AddDays(1);
                }
                TimeSpan timeUntilNextTime = nextTime - now;
            // Schedule the timer to run the DoWork method every 30 minutes
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(30));
            _lastTime = DateTime.UtcNow;
                return Task.CompletedTask;

            }

            private async void DoWork(object state)
            {
                //Put Here Email Logic
                var mailRequestVM = new MailRequestVM();
                mailRequestVM.Subject = "taske";
                mailRequestVM.Body = $" Title : done   ";
                mailRequestVM.ToEmail = "karim.n.1995@gmail.com";
                //mailRequestVM.Attachments = null;
       await    _iMailingService.SendEmailAsync(mailRequestVM);
            }

            public Task StopAsync(CancellationToken cancellationToken)
            {
                _timer.Change(Timeout.Infinite, 0);
                return Task.CompletedTask;
            }

            public void Dispose()
            {
                _timer?.Dispose();
            }
        }
    }
