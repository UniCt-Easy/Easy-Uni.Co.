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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_afferenzeorganizzative {
	/// <summary>
	/// MetaData for afferenzeorganizzative
	/// </summary>
	public class Meta_afferenzeorganizzative : Meta_easydata {
		public Meta_afferenzeorganizzative(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "afferenzeorganizzative") {
			Name = "Afferenze Organizzative";
			ListingTypes.Add("default");
			EditTypes.Add("anagrafica");
			ListingTypes.Add("anagrafica");
			EditTypes.Add("anagraficadetail");
			ListingTypes.Add("anagraficadetail");
		}

		protected override Form GetForm(string FormName) {

			if (FormName == "anagraficadetail") {
				Name = "Afferenze Organizzative";
				DefaultListType = "anagraficadetail";
				return GetFormByDllName("afferenzeorganizzative_anagraficadetail");
			}

			if (FormName == "anagrafica") {
				Name = "Afferenze Organizzative";
				DefaultListType = "anagrafica";
				return GetFormByDllName("afferenzeorganizzative_anagrafica");
			}
			return null;
		}

		public override DataRow SelectOne(string ListingType,
			string filter, string searchtable, DataTable ToMerge) {
			//if (ListingType == "posgiuridica")
			//	return base.SelectOne(ListingType, filter, "afferenzeorganizzativeview", ToMerge);

			if (ListingType == "anagrafica")
				return base.SelectOne(ListingType, filter, "afferenzeorganizzativeregview", ToMerge);

			return base.SelectOne(ListingType, filter, searchtable, ToMerge);
		}

		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T, "active", "S");
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "anagraficadetail": {
						return "active desc ,start desc, stop desc";
					}
			}
			return base.GetSorting(ListingType);
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType == "default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);
				int nPos = 1;
				DescribeAColumn(T, "codice", "Codice", nPos++);
				DescribeAColumn(T, "datainizio", "Data inizio", nPos++);
				DescribeAColumn(T, "datafine", "Data fine", nPos++);
				DescribeAColumn(T, "csa_role", "Ruolo", nPos++);
				DescribeAColumn(T, "incomeclass", "Classe", nPos++);
				DescribeAColumn(T, "Comparto", "Comparto", nPos++);
			}

			if (ListingType == "anagraficadetail") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);
				int nPos = 1;
				DescribeAColumn(T, "codice", "Codice", nPos++);
				DescribeAColumn(T, "datainizio", "Data inizio", nPos++);
				DescribeAColumn(T, "datafine", "Data fine", nPos++);
				DescribeAColumn(T, "csa_role", "Ruolo", nPos++);
				DescribeAColumn(T, "incomeclass", "Classe", nPos++);
				DescribeAColumn(T, "Comparto", "Comparto", nPos++);
			}

		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			int codicecreddeb = CfgFn.GetNoNullInt32(R["idreg"]);
			if (codicecreddeb <= 0) {
				errmess = "Inserire l'anagrafica";
				errfield = "idreg";
				return false;
			}
			
			if (R["codice"] == DBNull.Value) {
				errmess = "Inserire il Codice Afferenza";
				errfield = "codice";
				return false;
			}

			if ((R["datainizio"] != DBNull.Value) && (R["datafine"] != DBNull.Value)) {
				DateTime start = (DateTime)R["datainizio"];
				DateTime stop = (DateTime)R["datafine"];

				if (start > stop) {
					errmess = "Attenzione! Il termine dell'afferenza non può essere successivo alla data inizio.";
					errfield = "datafine";
					return false;
				}
			}

			return true;
		}
		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "idreg");
			RowChange.MarkAsAutoincrement(T.Columns["idafferenzeorganizzative"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idafferenzeorganizzative"], 9999);
			return base.Get_New_Row(ParentRow, T);

		}


	}



}

