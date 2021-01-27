
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
//Pino: using istitutocassiere_situazione; diventato inutile
//using treasurer_default;//istitutocassiere
using funzioni_configurazione;//funzioni_configurazione

namespace meta_treasurer //meta_istitutocassiere//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_treasurer : Meta_easydata {
		public Meta_treasurer(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "treasurer") {
			EditTypes.Add("default");
			EditTypes.Add("situazione");
			ListingTypes.Add("default");
			ListingTypes.Add("lista");
		}

		protected override Form GetForm(string FormName) {

			if (FormName == "default") {
				DefaultListType = "lista";
				Name = "Tesoriere";
				return GetFormByDllName("treasurer_default");
			}

			if (FormName == "situazione") {
				DefaultListType = "lista";
				Name = "Ricerca Cassiere";
				return MetaData.GetFormByDllName("treasurer_situazione");
			}

			return null;
		}

		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T, "active", "S");
			SetDefault(T, "flagfruitful", "F");
			SetDefault(T, "flagbank_grouping", 17);
			SetDefault(T, "enable_ndoc_treasurer", "N");
		}

		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype == "default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);

				int nPos = 1;
				DescribeAColumn(T, "codetreasurer", "Cod. Cassiere", nPos++);
				DescribeAColumn(T, "description", "Banca", nPos++);
				//DescribeAColumn(T, "flagdefault","");
				//DescribeAColumn(T, "cin", "");
				//DescribeAColumn(T, "idbank", "");
				//DescribeAColumn(T, "idcab", "");
				//DescribeAColumn(T, "cc", "");
				//DescribeAColumn(T, "address", "");
				//DescribeAColumn(T, "cap", "");
				//DescribeAColumn(T, "city", "");
				//DescribeAColumn(T, "country", "");
				//DescribeAColumn(T, "phoneprefix", "");
				//DescribeAColumn(T, "phonenumber", "");
				//DescribeAColumn(T, "faxprefix", "");
				//DescribeAColumn(T, "faxnumber", "");
			}
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType == "lista")
				return base.SelectOne(ListingType, filter, "treasurerview", Exclude);
			else
				return base.SelectOne(ListingType, filter, "treasurer", Exclude);
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			//Lunghezza del BBAN = 1 (CIN) + 5 (ABI) + 5(CAB) + 12 (C/C) = 23
			bool cinCorretto = CfgFn.CheckCIN(R["cin"].ToString(),
				R["idcab"].ToString(),
				R["idbank"].ToString(),
				R["cc"].ToString());

			if (!cinCorretto && (R["iban"].ToString().Length >= 2) && R["iban"].ToString().StartsWith("IT")) {
				errmess = "Poichè il CIN non è corretto, il codice IBAN deve essere vuoto";
				errfield = "iban";
				return false;
			}

			if (cinCorretto && ((R["iban"].ToString() != "")
			                    && R["iban"].ToString().ToUpper().StartsWith("IT")
			                    && R["iban"].ToString().Length != 27)) {
				errmess = "Il codice IBAN deve essere composto da 27 caratteri";
				errfield = "iban";
				return false;
			}

			if (cinCorretto && R["iban"].ToString().ToUpper().StartsWith("IT")) {
				string bban2 = R["cin"].ToString().ToUpper()
				               + R["idbank"]
				               + R["idcab"]
				               + R["cc"];
				string iban2 = CfgFn.calcolaIBAN("IT", bban2);
				if (R["iban"].ToString() != iban2) {
					errmess = "Il codice IBAN non è coerente con i campi CIN, CAB, ABI, CC";
					errfield = "iban";
					return false;
				}
			}

			if ((R["iban"].ToString() != "") &&
			    R["iban"].ToString().ToUpper().StartsWith("IT") == false &&
			    CfgFn.verificaIban(R["iban"].ToString()) == false) {
				errmess = "Il codice IBAN non è valido (codice di controllo errato)";
				errfield = "iban";
				return false;
			}

			//Check CIN
			if (!CfgFn.CheckCIN(R["cin"].ToString(),
				R["idcab"].ToString(),
				R["idbank"].ToString(),
				R["cc"].ToString())) {
				if (!showClientMsg("Il CIN inserito non corrisponde ai dati immessi. Proseguo lo stesso?",
					"Dati incoerenti",MessageBoxButtons.OKCancel)) {
					errmess = "";
					errfield = "cin";
					return false;
				}
			}

			if ((R["reccbikind"].ToString() == "17") && (R["ibancbi"] == DBNull.Value)) {
				errmess = "Il codice IBAN è obbligatorio se si intende usare il Record 17";
				errfield = "reccbikind";
				return false;
			}


			return true;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["idtreasurer"], null, null, 7);
			RowChange.setMinimumTempValue(T.Columns["idtreasurer"], 9999000);
			DataRow R = base.Get_New_Row(ParentRow, T);

			return R;
		}
	}
}
