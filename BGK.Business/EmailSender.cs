
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;
using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business
{
    public class EmailSender
    {
        public void SendEmail(string toEmail, string text, EventModel eventModel)
        {
            string to = "jokzik@gmail.com"; //To address    
            string from = "teeststeest555@yandex.ru"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "Тренинг состоится {eventModel.StartDate}";
            message.Subject = "Тренинг скоро состоится! Подробности в письме.";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.yandex.ru", 465); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("teeststeest555@yandex.ru", "9KdQXY9ZKgw5yHp");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
