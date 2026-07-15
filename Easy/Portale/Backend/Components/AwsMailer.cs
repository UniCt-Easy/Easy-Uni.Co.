/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

#pragma warning disable CS1591

using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Configuration;

namespace Backend.Components
{
    public class AwsMailer
    {
        private string subject;
        private string textBody;
        private string htmlBody;
        private byte[] attachment;
        private string fileName;
        private string contentType;

        private string SesSmtpHost;
        private int    SesSmtpPort;
        private string SesSmtpUser;
        private string SesSmtpPass;

        MailboxAddress mailboxAddress;

        // FromName es: Conservatorio di Musica di Trapani
        // FromMail es: your-email@example.com
        // SesSmtpHost, SesSmtpPort, SesSmtpUser, SesSmtpPass vanno letti da app_config AWS_SES_SMTP_XXXX
        public AwsMailer(string _subject,
                         string _htmlBody,
                         byte[] _attachment,
                         string _fileName,
                         string _contentType,
                         string fromName,
                         string fromMail,
                         string _SesSmtpHost,
                            int _SesSmtpPort,
                         string _SesSmtpUser,
                         string _SesSmtpPass)
        {
            subject = _subject;
            htmlBody = _htmlBody;
            attachment = _attachment;
            fileName = _fileName;
            contentType = _contentType;

            string textBody = Regex.Replace(_htmlBody, "<.*?>", string.Empty);
            
            SesSmtpHost = _SesSmtpHost;
            SesSmtpPort = _SesSmtpPort;
            SesSmtpUser = _SesSmtpUser;
            SesSmtpPass = _SesSmtpPass;

            mailboxAddress = new MailboxAddress(fromName, fromMail);
        }

        public void Send(List<string> to)
        {
            // Send to each recipient
            foreach (var address in to)
                Send(address);
        }

        public bool Send(string to)
        {
            try
            {
                // New Message
                var message = new MimeMessage();

                // From, To, Subject
                message.From.Add(mailboxAddress);
                message.To.Add(MailboxAddress.Parse(to));
                message.Subject = subject;

                // Text
                var builder = new BodyBuilder
                {
                    TextBody = textBody,
                    HtmlBody = htmlBody
                };

                // Attachment
                if (attachment != null && !string.IsNullOrEmpty(fileName))
                    builder.Attachments.Add(fileName, attachment, ContentType.Parse(contentType));

                // Body (Text + Html + Attachment)
                message.Body = builder.ToMessageBody();

                // Send Email
                using (var client = new SmtpClient())
                {
                    client.Connect(SesSmtpHost, SesSmtpPort, SecureSocketOptions.StartTls);
                    client.Authenticate(SesSmtpUser, SesSmtpPass);
                    client.Send(message);
                    client.Disconnect(true);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}