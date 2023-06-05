using Server.Database.Models;
using System.Net.Mail;

namespace Server.Services
{
    public class MailService
    {
        private MyContext context = new();
        public void SendMail(Admin admin)
        {
            var smtpClient = new SmtpClient("LocalHost", 25);
            smtpClient.EnableSsl = false;

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("Foo@bak.cup");
            mailMessage.To.Add(admin.Email);
            mailMessage.Subject = "FooBakReport";
            mailMessage.Body = this.GetMessageBody(mailMessage, admin);

            smtpClient.Send(mailMessage);
            this.context.Admins!.Find(admin.Id)!.LastEmail = DateTime.Now;
            this.context.SaveChanges();

        }
        private string GetMessageBody(MailMessage message, Admin admin)
        {
            var reports = this.context.Reports!.ToList();
            if(admin.LastEmail != null)
            {
                reports = reports.Where(report => report.ReportTime > admin.LastEmail).ToList();
            }

            return $"Total number of new reports: {reports.Count}, {reports.Count(report => report.Status == 'f')} of them failed, {reports.Count(report => report.Status == 'w')} of them ended with warning.";
        }

    }
}
