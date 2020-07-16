/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using System.Windows.Forms;
using System.Data;
//using Contatto;
//using Contattomain;
using metaeasylibrary;
using metadatalibrary;
using System.Text.RegularExpressions;

namespace meta_registryreference//meta_contatto//
{
	/// <summary>
	/// Summary description for  Meta_campusdata
	/// </summary>
	public class Meta_registryreference : Meta_easydata
	{
		public Meta_registryreference(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "registryreference") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
			EditTypes.Add("contatto");
			ListingTypes.Add("contatto");
			ListingTypes.Add("unione");
			//----------------------segreterie-------------------------------------------- begin
			EditTypes.Add("persone");
			ListingTypes.Add("persone");
			EditTypes.Add("seg");
			ListingTypes.Add("seg");
			EditTypes.Add("user");
			ListingTypes.Add("user");
			//----------------------segreterie-------------------------------------------- end
			Name = "Contatto";
			//$EditTypes$
		}
		protected override Form GetForm(string FormName) {
			if (FormName == "default") {
				DefaultListType = "default";
				return GetFormByDllName("registryreference_default");
				//return new frmContatto();
			}
			if (FormName == "contatto") {
				Name = "Contatto";
				DefaultListType = "contatto";
				return GetFormByDllName("registryreference_contatto");
				//return new frmcontatto();
			}
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "flagdefault", "N");
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "idreg");
			RowChange.MarkAsAutoincrement(T.Columns["idregistryreference"], null, null, 0);
			return base.Get_New_Row(ParentRow, T);
		}

		public override DataRow SelectOne(string ListingType,
			string filter, string searchtable, DataTable ToMerge) {
			if (ListingType == "contatto")
				return base.SelectOne(ListingType, filter,
					"registryreferenceview", ToMerge);

			return base.SelectOne(ListingType, filter,
				searchtable, ToMerge);
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {

			if (!base.IsValid(R, out errmess, out errfield)) return false;
			// Controllo sulla correttezza dell'indirizzo email
			string s = R["email"].ToString();
			if (s != "") {
				Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");

				Match m = emailregex.Match(s);

				if (!m.Success) {
					errfield = "email";
					errmess = "Inserire correttamente l'indirizzo email nel seguente formato: userid@dominio.organizzazione";
					return false;
				}
			}
			if (edit_type == "default") {

				if (!isSubentity) {
					errmess = "Non Ë possibile modificare l'entit‡ contatto senza un form padre";
					errfield = null;
					return false;
				}

				// Controllo di esistenza altri contatti predefiniti
				if (R["flagdefault"].ToString().ToLower() != "s") return true;
				DataTable ParentTable = SourceRow.Table;
				DataRow[] standard = ParentTable.Select("flagdefault='S'");
				if (standard.Length == 0) return true;
				if (SourceRow["flagdefault"].ToString().ToUpper() == "S") return true;
				errmess = "Esiste gi‡ un contatto predefinito. Eliminarlo prima di impostare quello corrente";
				errfield = "flagdefault";
				R["flagdefault"] = "N";
				return false;
			}

			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			if (ListingType == "default") {
				if (T.DataSet !=null && T.DataSet.Tables["registry"] != null)
					DescribeAColumn(T, "idreg", "", -1);
				int nPos = 1;
				DescribeAColumn(T, "idregistryreference", "#", nPos++);
				DescribeAColumn(T, "referencename", "Nome", nPos++);
				DescribeAColumn(T, "registryreferencerole", "Funzione", nPos++);
				DescribeAColumn(T, "phonenumber", "Num. tel.", nPos++);
				DescribeAColumn(T, "faxnumber", "Num. fax.", nPos++);
				DescribeAColumn(T, "mobilenumber", "Num. cellulare", nPos++);
				DescribeAColumn(T, "skypenumber", "Skype No.", nPos++);
				DescribeAColumn(T, "msnnumber", "MSN No.", nPos++);
				DescribeAColumn(T, "email", "Indirizzo EMail", nPos++);
				DescribeAColumn(T, "pec", "Indirizzo Pec", nPos++);
				//DescribeAColumn(T, "userweb", "utente", nPos++);
				//DescribeAColumn(T, "passwordweb", "", nPos++);
				DescribeAColumn(T, "flagdefault", "Predefinito", nPos++);
			}
			if (ListingType == "unione") {
				if (T.DataSet != null && T.DataSet.Tables["registry"] != null)
					DescribeAColumn(T, "idreg", "", -1);
				int nPos = 1;
				DescribeAColumn(T, "!kk", ".aaaa", nPos++);
				DescribeAColumn(T, "idreg", "#", nPos++);
				DescribeAColumn(T, "idregistryreference", "#", nPos++);
				DescribeAColumn(T, "referencename", "Nome", nPos++);
				DescribeAColumn(T, "registryreferencerole", "Funzione", nPos++);
				DescribeAColumn(T, "phonenumber", "Num. tel.", nPos++);
				DescribeAColumn(T, "faxnumber", "Num. fax.", nPos++);
				DescribeAColumn(T, "mobilenumber", "Num. cellulare", nPos++);
				DescribeAColumn(T, "skypenumber", "Skype No.", nPos++);
				DescribeAColumn(T, "msnnumber", "MSN No.", nPos++);
				DescribeAColumn(T, "email", "Indirizzo EMail", nPos++);
				DescribeAColumn(T, "pec", "Indirizzo Pec", nPos++);
				DescribeAColumn(T, "userweb", "utente", nPos++);
				DescribeAColumn(T, "passwordweb", "", nPos++);
				DescribeAColumn(T, "flagdefault", "Predefinito", nPos++);
				DescribeAColumn(T, "lt", "Data ultima mod.", nPos++);
			}

			//----------------------segreterie-------------------------------------------- begin
			switch (ListingType) {
				case "persone": {
						foreach (DataColumn C in T.Columns) {
							DescribeAColumn(T, C.ColumnName, "", -1);
						}
						int nPos = 1;
						DescribeAColumn(T, "referencename", "Nome Contatto", nPos++);
						DescribeAColumn(T, "flagdefault", "Contatto predefinito", nPos++);
						DescribeAColumn(T, "email", "Email", nPos++);
						DescribeAColumn(T, "skypenumber", "Skype No.", nPos++);
						DescribeAColumn(T, "msnnumber", "MSN No.", nPos++);
						DescribeAColumn(T, "phonenumber", "Numero tel.", nPos++);
						DescribeAColumn(T, "faxnumber", "Numero fax.", nPos++);
						DescribeAColumn(T, "mobilenumber", "Num. cellulare", nPos++);
						DescribeAColumn(T, "pec", "Pec", nPos++);
						DescribeAColumn(T, "userweb", "login web", nPos++);
						DescribeAColumn(T, "passwordweb", "password per accesso web", nPos++);
						DescribeAColumn(T, "registryreferencerole", "Funzione contatto", nPos++);
						DescribeAColumn(T, "website", "Website", nPos++);
						break;
					}
				case "seg": {
						foreach (DataColumn C in T.Columns) {
							DescribeAColumn(T, C.ColumnName, "", -1);
						}
						int nPos = 1;
						DescribeAColumn(T, "referencename", "Nome Contatto", nPos++);
						DescribeAColumn(T, "flagdefault", "Contatto predefinito", nPos++);
						DescribeAColumn(T, "email", "Email", nPos++);
						DescribeAColumn(T, "skypenumber", "Skype No.", nPos++);
						DescribeAColumn(T, "msnnumber", "MSN No.", nPos++);
						DescribeAColumn(T, "phonenumber", "Numero tel.", nPos++);
						DescribeAColumn(T, "faxnumber", "Numero fax.", nPos++);
						DescribeAColumn(T, "mobilenumber", "Num. cellulare", nPos++);
						DescribeAColumn(T, "pec", "Pec", nPos++);
						DescribeAColumn(T, "website", "Website", nPos++);
						break;
					}
				case "user": {
						foreach (DataColumn C in T.Columns) {
							DescribeAColumn(T, C.ColumnName, "", -1);
						}
						int nPos = 1;
						DescribeAColumn(T, "!clientpassword", "Password", nPos++);
						DescribeAColumn(T, "!confirmpassword", "Conferma password", nPos++);
						DescribeAColumn(T, "referencename", "Nome Contatto", nPos++);
						DescribeAColumn(T, "email", "E-Mail", nPos++);
						DescribeAColumn(T, "phonenumber", "Numero di telefono", nPos++);
						DescribeAColumn(T, "faxnumber", "Numero Fax", nPos++);
						DescribeAColumn(T, "mobilenumber", "Numero di cellulare", nPos++);
						DescribeAColumn(T, "pec", "Pec", nPos++);
						DescribeAColumn(T, "userweb", "Nome utente", nPos++);
						DescribeAColumn(T, "passwordweb", "Password", nPos++);
						DescribeAColumn(T, "website", "Web page", nPos++);
						break;
					}
				//----------------------segreterie-------------------------------------------- end
					//$DescribeAColumn$
			}
		}
	}

}
