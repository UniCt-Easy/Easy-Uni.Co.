
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
using metadatalibrary;
using metaeasylibrary;
//Pino: using missionetappa; diventato inutile
using itinerationFunctions;//FunzioniMissione

namespace meta_itinerationlap//meta_missionetappa//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_itinerationlap : Meta_easydata
	{
		public Meta_itinerationlap(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "itinerationlap") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
			Name = "Tappa";
			//----------------------------------instm-------------------------------begin
			EditTypes.Add("instm_instmuser");
			ListingTypes.Add("instm_instmuser");
			EditTypes.Add("aid");
			ListingTypes.Add("aid");
			//$EditTypes$
			//----------------------------------instm-------------------------------end
		}


		protected override Form GetForm(string FormName) {
			//estraggo dal formname i paramtri e li passo al form

			if (FormName == "default") {
				//DefaultListType="default";
				Name = "Tappa";
				return MetaData.GetFormByDllName("itinerationlap_default");//PinoRana
			}
			return null;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "iditineration");
			RowChange.MarkAsAutoincrement(T.Columns["lapnumber"], null, null, 6);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "flagitalian", "S");
		}

		public override void CalculateFields(DataRow R, string list_type) {
			R["!indennita"] = MissFun.IndennitaTotale(R);
			DataRow CurrMiss = R.GetParentRow("itinerationitinerationlap");
			if (R["flagitalian"].ToString().ToUpper() == "S") {
				R["!italiaestero"] = "Italia";
			} else {
				R["!italiaestero"] = "Estero";
			}
			if (CurrMiss.Table.ExtendedProperties["MyCfgItineration"] == null) return;
			CfgItineration Cfg = (CfgItineration)CurrMiss.Table.ExtendedProperties["MyCfgItineration"];
			R["!indennitalorda"] = MissFun.IndennitaLordaTappa(CurrMiss, R, Cfg);
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;
			//			if (R["bilanciorecupero"]==DBNull.Value)
			//			{
			//				errmess="Attenzione! Inserire una voce di bilancio.";
			//				errfield="bilanciorecupero";
			//				return false;
			//			}

			if (R["starttime"] == DBNull.Value) {
				errmess = "Attenzione! Specificare l'inizio della tappa";
				errfield = "starttime";
				return false;
			}

			if (R["stoptime"] == DBNull.Value) {
				errmess = "Attenzione! Specificare la fine della tappa";
				errfield = "stoptime";
				return false;
			}

			if (((DateTime)R["starttime"]).CompareTo(((DateTime)R["stoptime"])) > 0) {
				errmess = "Attenzione! Non può essere immessa una data inizio successiva alla data fine";
				errfield = "starttime";
				return false;
			}

			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;

			switch (ListingType) {
				//----------------------------------instm-------------------------------begin
				case "instm_instmuser": {
						DescribeAColumn(T, "!idforeigncountry_foreigncountry_description", "Stato Estero", nPos++);
						DescribeAColumn(T, "starttime", "Inizio", nPos++);
						if (T.Columns.Contains("starttime")) T.Columns["starttime"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "stoptime", "Termine", nPos++);
						if (T.Columns.Contains("stoptime")) T.Columns["stoptime"].ExtendedProperties["format"] = "g";
						break;
					}
					//$DescribeAColumn$
				//----------------------------------instm-------------------------------end
				case "default": {
						DescribeAColumn(T, "!italiaestero", "Italia/estero", nPos++);
						DescribeAColumn(T, "starttime", "Inizio", nPos++);
						DescribeAColumn(T, "stoptime", "Termine", nPos++);
						DescribeAColumn(T, "days", "Giorni", nPos++);
						DescribeAColumn(T, "hours", "Ore", nPos++);
						DescribeAColumn(T, "!localita", "Località", "foreigncountry.description", nPos++);
						DescribeAColumn(T, "description", "Descrizione", nPos++);
						DescribeAColumn(T, "!indennita", "Indennita totale Euro", nPos++);
						DescribeAColumn(T, "!indennitalorda", "Indennita lorda", nPos++);
						ComputeRowsAs(T, "default");
						break;
					}
			}
		}


	}
}
