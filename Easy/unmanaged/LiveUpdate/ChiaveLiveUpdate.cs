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
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using metadatalibrary;

namespace LiveUpdate {

	public static class ChiaveLiveUpdate {

		public const string C_NONAUTORIZZATO = "Aggiornamenti non autorizzati per questa installazione: " +
			"manca o non vale la chiave del live update dell'ente (riga LIVEUPDATE di app_config)";

		const string codice = "LIVEUPDATE";
		static readonly byte[] entropia = Encoding.UTF8.GetBytes("Easy|liveupdate|chiave dell'ente");
		static readonly object blocco = new object();

		static string inMemoria;

		public static string NomeFile {
			get {
				return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
					"Tempo", "liveupdate.dat");
			}
		}

		public static string Leggi() {
			lock (blocco) {
				if (inMemoria != null) return inMemoria;
				try {
					if (!File.Exists(NomeFile)) return null;
					byte[] chiaro = ProtectedData.Unprotect(File.ReadAllBytes(NomeFile), entropia,
						DataProtectionScope.CurrentUser);
					inMemoria = Encoding.UTF8.GetString(chiaro);
				}
				catch (Exception e) {
					QueryCreator.MarkEvent("ChiaveLiveUpdate: " + NomeFile + " non si legge (" + e.Message +
						"): si riscrive al prossimo login");
				}
				return inMemoria;
			}
		}

		public static void AggiornaDalDatabase(DataAccess conn) {
			string dalDb = DalDatabase(conn);
			if (dalDb == null || dalDb == Leggi()) return;
			lock (blocco) {
				inMemoria = dalDb;
				try {
					Directory.CreateDirectory(Path.GetDirectoryName(NomeFile));
					File.WriteAllBytes(NomeFile, ProtectedData.Protect(Encoding.UTF8.GetBytes(dalDb), entropia,
						DataProtectionScope.CurrentUser));
				}
				catch (Exception e) {
					QueryCreator.MarkEvent("ChiaveLiveUpdate: " + NomeFile + " non si scrive (" + e.Message +
						"): la chiave vale solo per questa sessione");
				}
			}
		}

		public static string DalDatabase(DataAccess conn) {
			if (conn == null) return null;
			try {
				QueryHelper qhs = conn.GetQueryHelper();
				object valore = conn.DO_READ_VALUE("app_config", qhs.CmpEq("code", codice), "param", null);
				if (valore == null || valore == DBNull.Value) return null;
				string dalDb = valore.ToString().Trim();
				return dalDb == "" ? null : dalDb;
			}
			catch (Exception e) {
				QueryCreator.MarkEvent("ChiaveLiveUpdate: app_config non si legge (" + e.Message + ")");
				return null;
			}
		}

		public static void Prepara(WebClient web, string indirizzo) {
			Imposta(web, indirizzo, Leggi());
		}

		public static void Imposta(WebClient web, string indirizzo, string chiave) {
			if (web == null || indirizzo == null) return;
			if (!indirizzo.StartsWith("https://", StringComparison.OrdinalIgnoreCase)) return;
			web.Headers.Remove(HttpRequestHeader.Authorization);
			int separatore = chiave == null ? -1 : chiave.IndexOf('|');
			if (separatore <= 0) return;
			string basic = chiave.Substring(0, separatore) + ":" + chiave.Substring(separatore + 1);
			web.Headers[HttpRequestHeader.Authorization] = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(basic));
		}

		public static bool NonAutorizzato(Exception e) {
			WebException w = (e as WebException) ?? (e?.InnerException as WebException);
			HttpWebResponse risposta = w?.Response as HttpWebResponse;
			return risposta != null && risposta.StatusCode == HttpStatusCode.Unauthorized;
		}
	}
}
