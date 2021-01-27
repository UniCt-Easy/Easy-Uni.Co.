
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Collections.Generic;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.IO;
using System.Net;
using System.Xml;

/// <summary>
/// Summary description for SendMail
/// </summary>
namespace funzioni_configurazione
{
   

    public class SendMail
    {
        /// <summary>
        /// Mittente
        /// </summary>
        public string From;


        /// <summary>
        /// Destinatario/i
        /// </summary>
        public string To;

        /// <summary>
        /// Copia conoscenza
        /// </summary>
        public string Cc;

        /// <summary>
        /// Copia conoscenza nascosto
        /// </summary>
        public string Bcc;

        /// <summary>
        /// Oggetto della mail
        /// </summary>
        public string Subject;
        /// <summary>
        /// Testo della mail
        /// </summary>
        public string MessageBody;

        public bool UseSMTPLoginAsFromField = false;
        public string ErrorMessage;

        private List<Attachment> attach = new List<Attachment>();

        public  void addAttachment(XmlDocument x, string fileName) {
            MemoryStream ms = new MemoryStream();
            x.Save(ms);
            ms.Flush();
            ms.Position = 0;
            addAttachment(new Attachment(ms, fileName));
        }
        /// <summary>
        /// Aggiunge un allegato avente un dato contenuto e nome file
        /// </summary>
        /// <param name="x">contanuto</param>
        /// <param name="fileName">Nome file</param>
        public void addAttachment(byte[] x, string fileName) {
            MemoryStream ms = new MemoryStream(x);
            addAttachment(new Attachment(ms, fileName));
        }

        public void addAttachment(Attachment a) {
            attach.Add(a);
        }

        /// <summary>
        /// Legge un file e lo aggiunge come allegato
        /// </summary>
        /// <param name="fName"></param>
        /// <returns></returns>
        public  bool  addAttachment(string fName) {
            byte[] b;
            try {
                b= File.ReadAllBytes(fName);                
            }
            catch  {
                return false;
            }
            addAttachment(b, Path.GetFileName(fName));
            return true;
        }

        private string SMTPAddress;
        private string SMTPLogin;
        private string SMTPPassword;
        private string sqlAttachmentsPath;
        private int SMTPPort;
        public DataAccess Conn;
        public bool NoConfig = false;
        private string postfix = "";

        public void useCuMail() {
            postfix = "_cu";
        }
        public bool Send()
        {
            if (!GetSMTPConnData())
            {
                //ErrorMessage = "Nessuna connessione SMTP presente nel Database.";
                ErrorMessage = "";
                return false;
            }
            if (SMTPLogin.StartsWith("$$")) {
                SqlSend(SMTPLogin.Substring(2));
                return true;
            }
            bool Tls = false;
            if (SMTPLogin.StartsWith("Tls:")) {
                SMTPLogin = SMTPLogin.Substring(4);
                Tls = true;
            }

            bool Tls11 = false;
            if (SMTPLogin.StartsWith("Tls11:")) {
                SMTPLogin = SMTPLogin.Substring(6);
                Tls11 = true;
            }
            bool Tls12 = false;
            if (SMTPLogin.StartsWith("Tls12:")) {
                SMTPLogin = SMTPLogin.Substring(6);
                Tls12 = true;
            }
            bool Ssl3 = false;
            if (SMTPLogin.StartsWith("Ssl3:")) {
                SMTPLogin = SMTPLogin.Substring(5);
                Ssl3 = true;
            }
            string EffectiveFrom;
            if (!UseSMTPLoginAsFromField)
                EffectiveFrom = From;
            else
                EffectiveFrom = SMTPLogin;

            if (To == null || To == "")
            {
                ErrorMessage = "Nessun destinatario specificato.";
                return false;
            }
            System.Net.Mail.MailMessage message = null;
            try {
                message = new System.Net.Mail.MailMessage(
                    EffectiveFrom,
                    To.Replace(';', ','),
                    Subject,
                    MessageBody);
            }
            catch (Exception e) {
                ErrorMessage = "Errore nell'invio del messaggio " + " DA: " + EffectiveFrom +"\r\n" + "A: " + To.Replace(';', ',') + 
                               "\r\n\r\n" + QueryCreator.GetErrorString(e);
                return false;
            }
            if (!string.IsNullOrEmpty(Bcc)) message.Bcc.Add(Bcc.Replace(';',','));
            if (!string.IsNullOrEmpty(Cc)) message.CC.Add(Cc.Replace(';', ','));

            foreach (Attachment a in attach) {
                message.Attachments.Add(a);
            }

            message.BodyEncoding = System.Text.Encoding.Default;


            System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(SMTPAddress);
            mailClient.Port = SMTPPort;
            mailClient.UseDefaultCredentials = false;
            mailClient.EnableSsl = (Ssl3|Tls|Tls11|Tls12);
            if (Ssl3) {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            }
            if (Tls) {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }
            if (Tls11) {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
            }
            if (Tls12) {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            if (SMTPLogin!="")  mailClient.Credentials = new System.Net.NetworkCredential(SMTPLogin, SMTPPassword);            
            mailClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

            try
            {
                mailClient.Send(message);
                mailClient.Dispose();
                return true;
            }
            catch (System.Net.Mail.SmtpFailedRecipientException F)
            {
                mailClient.Dispose();
                ErrorMessage = "Impossibile recapitare il messaggio ad uno o più destinatari. Invio messaggio fallito."
                    +"\r\n"+F.ToString();
                return false;
            }
            catch (System.Net.Mail.SmtpException E)
            {
                mailClient.Dispose();
                ErrorMessage = "Impossibile Contattare il server SMTP.Invio messaggio fallito."
                        + "\r\n" + E.ToString();
                return false;
            }
            catch (Exception E){
                mailClient.Dispose();
                ErrorMessage = QueryCreator.GetErrorString(E);
                return false;
            }
        }
        private void SqlSend(string profilename) {
            string attachFiles = "";
            string tempPath = sqlAttachmentsPath;
            if (tempPath == "") tempPath =Path.GetTempPath();
            
            foreach (Attachment a in attach) {                
                string baseName = a.Name??"";
                string fName = Path.Combine(tempPath,Path.ChangeExtension(Path.GetFileNameWithoutExtension(baseName) + "_"+Path.GetRandomFileName(), Path.GetExtension(baseName)));                
                byte[] allBytes = new byte[a.ContentStream.Length];
                int bytesRead = a.ContentStream.Read(allBytes, 0, (int)a.ContentStream.Length);
                BinaryWriter writer = new BinaryWriter(new FileStream(fName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None));
                writer.Write(allBytes);
                writer.Flush();
                writer.Close();
                if (attachFiles != "") attachFiles += ";";
                attachFiles += fName;

            }
            

            object[] par = new object[] {
                                            profilename,
                                            To, Cc, Bcc,
                                            Subject, MessageBody, "TEXT",
                                            attachFiles
                                        };
            bool res = Conn.CallSPParameter("msdb.dbo.sp_send_dbmail",
                                 new string[] {
                                                  "@profile_name",
                                                  "@recipients", "@copy_recipients", "@blind_copy_recipients",
                                                  "@subject", "@body", "@body_format",
                                     "@file_attachments"
                                              },
                                 new SqlDbType[] {
                                                     SqlDbType.VarChar,
                                                     SqlDbType.VarChar,SqlDbType.VarChar, SqlDbType.VarChar,                                                    
                                                     SqlDbType.NVarChar, SqlDbType.VarChar,SqlDbType.VarChar,
                                                     SqlDbType.VarChar
                                                 },
                                 new int[] {
                                               200,
                                               100000, 100000, 100000,
                                               255, 100000, 20,10000
                                           },
                                 new ParameterDirection[] {
                                                              ParameterDirection.Input,
                                                              ParameterDirection.Input, ParameterDirection.Input,ParameterDirection.Input,
                                                              ParameterDirection.Input,ParameterDirection.Input, ParameterDirection.Input,
                                                               ParameterDirection.Input
                                                          },
                                ref par,true,600);
            //if (res) {
            //    foreach (Attachment a in attach) {
            //        string baseName = a.Name ?? "";
            //        string fName = Path.Combine(tempPath, Path.ChangeExtension(Path.GetFileNameWithoutExtension(baseName) + "_" + Path.GetRandomFileName(), Path.GetExtension(baseName)));
            //        File.Delete(fName);               
            //    }
            //}




        }

    

        private bool GetSMTPConnData()
        {
            NoConfig = true;
            DataTable T = Conn.RUN_SELECT("configsmtp", "*", null, null, null, false);
            if (T != null && T.Rows.Count != 0)
            {
                SMTPAddress = T.Rows[0]["server"+postfix].ToString();
                SMTPLogin = T.Rows[0]["login"+postfix].ToString();
                SMTPPassword = T.Rows[0]["password"+postfix].ToString();
                SMTPPort = CfgFn.GetNoNullInt32(T.Rows[0]["port"+postfix]);
                sqlAttachmentsPath = T.Rows[0]["sqlattachmentspath"+postfix].ToString();
                NoConfig = false;
                return true;
            }
            else
                return false;
        }
    }
}
