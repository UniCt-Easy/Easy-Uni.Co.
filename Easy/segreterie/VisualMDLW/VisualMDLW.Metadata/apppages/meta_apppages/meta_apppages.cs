
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
using metadatalibrary;
using metaeasylibrary;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security;
using Newtonsoft.Json.Linq;
//$CustomUsing$


namespace meta_apppages
{
    public class Meta_apppages : Meta_easydata 
	{
        public Meta_apppages(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "apppages") {
				Name = "Interfacce (pincipale)";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			//$EditTypes$
        }

		//$PrymaryKey$

		//$SetDefault$

		//$Get_New_Row$

		//$IsValid$

		//$DescribeAColumn$

		//$GetSortings$

		//$GetStaticFilter$
		
		public string GeneratePages(JValue prm1, JValue prm2)
		{
			ProcessStartInfo process = new ProcessStartInfo();
			process.CreateNoWindow = false;
			process.UseShellExecute = false;
			process.FileName = "cmd.exe";
			process.Arguments = @"/c ""D:\easy\segreterie\Segreterie.Generator\bin\Debug\Segreterie.Generator.exe " + prm1.Value + " " + prm2.Value;
			process.UserName = "nomeutente";
			string initString = "passwordutente";
			SecureString spsw = new SecureString();
			foreach (char ch in initString)
				spsw.AppendChar(ch);
			process.Password = spsw;
			process.RedirectStandardOutput = true;
			process.UseShellExecute = false;
			process.WorkingDirectory = @"D:\easy\segreterie\Segreterie.Generator\bin\Debug";
			process.CreateNoWindow = true;

			var msg = "";
			try
			{
				using (Process ProcessoExe = Process.Start(process) )
				{
					msg = ProcessoExe.StandardOutput.ReadToEnd();
					ProcessoExe.WaitForExit();
				}
				msg += "OK GeneratePages " + prm1.ToString() + " " + prm2.ToString();
			}
			catch (Exception e)
			{
				msg += "KO GeneratePages " + prm1.ToString() + " " + prm2.ToString() + "\r\n" + e.Message;
			}
			return msg;
		}

		public string GenerateDetail(JValue prm1) {
			var errmsg = "";
			base.dbConn.CallSP("GenerateAppPageDetail", new string[1] {prm1.ToString()}, -1, out errmsg);
			if (string.IsNullOrEmpty(errmsg))
				return "OK. Sono stati generati i dettagli per la pagina con id " + prm1.ToString();
			else
				return "KO. " + errmsg;
		}
//$CustomCode$
    }
}
