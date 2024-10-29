using Microsoft.Extensions.Configuration;
using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;


namespace FacturacionLabco_Utilidades.Utilidades
{
    public class EmailSender : IEmailSender
    {
        public string SendGridSecret { get; set; }

        public EmailSender(IConfiguration _config) //el IConfiguration nos permitira acceder al AppSetting.Json
        {
            SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");//asi capturamos la APIKey
        }

        //aca creo la estructura de email y finalmente lo envio
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(SendGridSecret);
            var from = new EmailAddress("mauricio_vargas@covao.ed.cr");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);

            return client.SendEmailAsync(msg);
        }
    
    }
}
