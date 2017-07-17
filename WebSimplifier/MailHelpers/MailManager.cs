using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WebSimplifier.MailHelpers.Models;

namespace WebSimplifier.MailHelpers
{
    public class MailManager
    {
        private string smtpHost;
        private int smtpPort;
        private NetworkCredential mailCredential;
        private bool enableSSL;
        public MailManager(string smtpHost, int smtpPort, NetworkCredential mailCredential, bool enableSSL)
        {
            this.smtpHost = smtpHost;
            this.smtpPort = smtpPort;
            this.mailCredential = mailCredential;
            this.enableSSL = enableSSL;
        }

        public async Task<bool> SendMail(MailMessage mailMessage)
        {

            using (var smtp = new SmtpClient())
            {
                try
                {
                    smtp.Credentials = mailCredential;
                    smtp.Host = smtpHost;
                    smtp.Port = smtpPort;
                    smtp.EnableSsl = enableSSL;
                    await smtp.SendMailAsync(mailMessage);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }


        }
        public static InformationsAboutIp FindAllInformationAboutIp(string ip)
        {
            string link = "http://www.freegeoip.net/json/" + ip;
            string json = "";

            using (WebClient client = new WebClient())
            {
                json = client.DownloadString(link);
            }

            InformationsAboutIp information = JsonConvert.DeserializeObject<InformationsAboutIp>(json);
            return information;
        }



    }
}
