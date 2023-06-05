using Quartz;
using Server.Database.Models;

namespace Server.Services.QuartzClasses
{
    public class MailJob : IJob
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Execute(IJobExecutionContext context)
#pragma warning restore CS1998
        {
            var map = context.MergedJobDataMap as IDictionary<string, object>;
            var admin = (Admin)map["admin"];
            var mails = new MailService();

            try
            {
                mails.SendMail(admin);
            }
            catch (Exception)
            { 

            }
        }
    }
}
