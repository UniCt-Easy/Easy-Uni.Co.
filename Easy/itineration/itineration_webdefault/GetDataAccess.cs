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

using metadatalibrary;
using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;

namespace itineration_webdefault
{
    public class GetVars
    {
        public static DataAccess GetSystemDataAccess(out string error)
        {
            error = null;
            
            DataSet DS = GetConfigDataSet();
            DataTable T = DS.Tables[0];
            if (T.Rows.Count == 0)
            {
                error = "Il file di config. è errato";
                return null;
            }
            DataRow R = T.Rows[0];

            //Da ripristinare al termine dello sviluppo:
            //string _Server = "your-db-server";
            //string _Database = "webreport";
            //string _User = "sa";
            //string _Password = "YOUR_SECRET";
            //string _Password = GetVars.CryptPassword("afrofite");

            string _Server =    R["Server"].ToString().TrimEnd().Replace("clienti-ng", "your-db-server");
            string _Database =  R["Database"].ToString().TrimEnd();
            string _User =      R["User"].ToString().TrimEnd();
            string _Password =  R["Password"].ToString().TrimEnd();

            DataAccess Conn = new DataAccess("myDsn", _Server, _Database, _User, _Password, DateTime.Now.Year, DateTime.Now);

            Conn.persisting = false;
            if (!Conn.Open())
            {
                error = $"Collegamento fallito a #{_Server}#{_Database}#{_User}#Password#";
                return null;
            }

            return Conn;
        }

        public static DataSet GetConfigDataSet()
        {
            FileStream FileS = null;
            try
            {
                DataSet DS = new DataSet();
                FileS = new FileStream("config.xml", FileMode.Open);
                CryptoStream CryptoS = new CryptoStream(FileS,
                   new TripleDESCryptoServiceProvider().CreateDecryptor(
                   new byte[] { 75, 12, 0, 215, 93, 89, 45, 11, 171, 96, 4, 64, 13, 158, 36, 190 },
                   new byte[] { 68, 13, 99, 43, 149, 192, 145, 43, 83, 19, 238, 57, 128, 38, 12, 4 }
                   ), CryptoStreamMode.Read);

                DS.ReadXml(CryptoS);

                CryptoS.Close();
                FileS.Close();

                return DS;
            }
            catch (Exception Ex)
            {
                if (FileS != null)
                {
                    try
                    {
                        FileS.Close();
                        FileS.Dispose();
                    }
                    catch { }
                }
                DataSet DS = new DataSet();
                DataTable T = new DataTable();
                DS.Tables.Add(T);
                return DS;
            }
        }
    }
}
