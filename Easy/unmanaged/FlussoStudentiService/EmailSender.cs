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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FlussoStudentiService
{
	public class EmailSender :IEmailSender
	{
		private string _smtpServer;
		private int _smtpPort;
		private string _username;
		private string _password;
		private string _fromAddress;
		private string[] _recipients;

		bool Tls = false;
		bool Tls11 = false;
		bool Tls12 = false;
		bool Ssl3 = false;

		public EmailSender(string smtpServer, int smtpPort, string username, string password, string fromAddress, string[] recipients)
		{
			_smtpServer = smtpServer;
			_smtpPort = smtpPort;
			_username = username;
			_password = password;
			_fromAddress = fromAddress;
			_recipients = recipients;

			checkLogin();
		}

		public Task SendEmailAsync(string subject, string body, bool isBodyHtml = false)
		{
			try
			{
				var client = new SmtpClient(_smtpServer, _smtpPort)
				{
                    Credentials = new NetworkCredential(_username, _password),
					EnableSsl = (Ssl3 | Tls | Tls11 | Tls12),
					DeliveryMethod = SmtpDeliveryMethod.Network
				};

				MailMessage mailMessage = new MailMessage
				{
					From = new MailAddress(_fromAddress),
					Subject = subject,
					Body = body,
					IsBodyHtml = isBodyHtml,
					BodyEncoding = Encoding.Default
				};

				foreach (var recipient in _recipients)
				{
					mailMessage.To.Add(recipient);
				}

				return client.SendMailAsync(mailMessage);
			}
			catch (Exception ex)
			{

			}
			return null;
		}

		private void checkLogin()
		{
			//if (_username.StartsWith("$$"))
			//{
			//    _username = _username.Substring(2);
			//    SqlMail = true;
			//}
			if (_username.StartsWith("Tls:"))
			{
				_username = _username.Substring(4);
				Tls = true;
			}

			if (_username.StartsWith("Tls11:"))
			{
				_username = _username.Substring(6);
				Tls11 = true;
			}

			if (_username.StartsWith("Tls12:"))
			{
				_username = _username.Substring(6);
				Tls12 = true;
			}

			if (_username.StartsWith("Ssl3:"))
			{
				_username = _username.Substring(5);
				Ssl3 = true;
			}

			if (Ssl3)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
			}
			if (Tls)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
			}
			if (Tls11)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
			}
			if (Tls12)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			}
		}
	}
}
