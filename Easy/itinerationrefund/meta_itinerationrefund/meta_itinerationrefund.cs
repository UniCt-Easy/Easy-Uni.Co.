/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using metadatalibrary;
using metaeasylibrary;
//Pino: using missionespesa; diventato inutile
using funzioni_configurazione;//funzioni_configurazione
using itinerationFunctions;//FunzioniMissione

namespace meta_itinerationrefund//meta_missionespesa//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_itinerationrefund : Meta_easydata
	{
		public Meta_itinerationrefund(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "itinerationrefund") {
			EditTypes.Add("default");
			EditTypes.Add("advance");
			EditTypes.Add("balance");
			ListingTypes.Add("advance");
			ListingTypes.Add("balance");
			//----------------------------------instm-------------------------------begin
			EditTypes.Add("instmuseradvance");
			ListingTypes.Add("instmuseradvance");
			EditTypes.Add("instmuserbalance");
			ListingTypes.Add("instmuserbalance");
			//$EditTypes$
			//----------------------------------instm-------------------------------end

		}

		protected override Form GetForm(string FormName) {
			if (FormName == "default") {
				//DefaultListType="default";
				Name = "Spesa";
				return MetaData.GetFormByDllName("itinerationrefund_default");
			}
			if (FormName == "advance") {
				Name = "Spesa su Anticipo";
				return MetaData.GetFormByDllName("itinerationrefund_default");
			}
			if (FormName == "balance") {
				Name = "Spesa su Saldo";
				return MetaData.GetFormByDllName("itinerationrefund_default");
			}
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "extraallowance", 0.0);
			SetDefault(PrimaryTable, "advancepercentage", 0.0);
			SetDefault(PrimaryTable, "idcurrency", Conn.DO_READ_VALUE("currency", QHS.CmpEq("codecurrency", "EUR"), "idcurrency"));
			SetDefault(PrimaryTable, "exchangerate", 1.0);
			SetDefault(PrimaryTable, "flag_geo", "I");
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "iditineration");
			RowChange.MarkAsAutoincrement(T.Columns["nrefund"], null, null, 6);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			if ((R["starttime"] != DBNull.Value) && (R["stoptime"] != DBNull.Value)) {
				DateTime start = (DateTime)R["starttime"];
				DateTime datacontabile = (DateTime)GetSys("datacontabile");
				DateTime stop = (DateTime)R["stoptime"];
				if (start > stop) {
					errmess = "Attenzione! Non può essere immessa una data inizio successiva alla data fine";
					errfield = "start";
					return false;
				}
				if (R.RowState == DataRowState.Added) {
					if ((R["flagadvancebalance"].ToString().ToUpper() == "A") &&
						 (stop < datacontabile)) {
						errmess = "Attenzione! Per una Spesa di tipo 'Anticipo' non può essere immessa una data fine precedente alla data contabile del programma";
						errfield = "stop";
						return false;
					}
					if ((R["flagadvancebalance"].ToString().ToUpper() == "S") &&
						(start > datacontabile)) {
						errmess = "Attenzione! Per una Spesa di tipo 'Saldo' non può essere immessa una data inizio successiva alla data contabile del programma";
						errfield = "start";
						return false;
					}
				}
			} else {
				errmess = "Attenzione! Specificare inizio e termine della spesa";
				return false;
			}

			if (R["iditinerationrefundkind"] == DBNull.Value || CfgFn.GetNoNullInt32(R["iditinerationrefundkind"]) == 0) {
				errfield = "iditinerationrefundkind";
				errmess = "E' necessario scegliere il tipo di spesa";
				return false;
			}

			string filter = QHS.CmpEq("iditinerationrefundkind", R["iditinerationrefundkind"]);
			DataTable Titinerationrefundkind = Conn.RUN_SELECT("itinerationrefundkind", "iditinerationrefundkindgroup", null, filter, null, null, true);
			if (Titinerationrefundkind.Rows.Count > 0) {
				DataRow Ritinerationrefundkind = Titinerationrefundkind.Rows[0];
				if ((R["flag_geo"].ToString().ToUpper() == "I") && (CfgFn.GetNoNullInt32(Ritinerationrefundkind["iditinerationrefundkindgroup"]) == 5)) {
					errfield = "iditinerationrefundkind";
					errmess = "Per le spese in Italia non è possibile scegliere un Rimborso di tipo forfettario";
					return false;
				}

				if ((R["flag_geo"].ToString().ToUpper() != "I") && (CfgFn.GetNoNullInt32(Ritinerationrefundkind["iditinerationrefundkindgroup"]) == 1)
						&& R["idforeigncountry"] == DBNull.Value) {
					errfield = "idforeigncountry";
					errmess = "Per le spese di tipo Vitto in località estera è necessario scegliere la località";
					return false;
				}
			}

			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			//----------------------------------instm-------------------------------begin

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;

			switch (ListingType) {

				case "advance": {
						DescribeAColumn(T, "nrefund", "Num.Spesa", nPos++);
						DescribeAColumn(T, "!classificazione", "Classificazione", "itinerationrefundkind_advance.description", nPos++);
						DescribeAColumn(T, "amount", "Accordato (EURO)", nPos++);
						DescribeAColumn(T, "requiredamount", "Richiesto", nPos++);
						break;
					}
				case "balance": {
						DescribeAColumn(T, "nrefund", "Num.Spesa", nPos++);
						DescribeAColumn(T, "!classificazione", "Classificazione", "itinerationrefundkind_balance.description", nPos++);
						DescribeAColumn(T, "amount", "Accordato (EURO)", nPos++);
						DescribeAColumn(T, "requiredamount", "Richiesto", nPos++);
						break;
					}
				case "instmuseradvance": {
						DescribeAColumn(T, "!iditinerationrefundkind_itinerationrefundkind_description", "Tipologia", nPos++);
						DescribeAColumn(T, "starttime", "data inizio ", nPos++);
						if (T.Columns.Contains("starttime")) T.Columns["starttime"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "requiredamount", "Importo", nPos++);
						DescribeAColumn(T, "!idcurrency_currency_description", "Valuta", nPos++);
						break;
					}
				case "instmuserbalance": {
						DescribeAColumn(T, "!iditinerationrefundkind_itinerationrefundkind_description", "Tipologia", nPos++);
						DescribeAColumn(T, "starttime", "data inizio ", nPos++);
						if (T.Columns.Contains("starttime")) T.Columns["starttime"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "requiredamount", "Importo", nPos++);
						DescribeAColumn(T, "!idcurrency_currency_description", "Valuta", nPos++);
						break;
					}
					//$DescribeAColumn$
			}

			//----------------------------------instm-------------------------------end


		}

	}
}
