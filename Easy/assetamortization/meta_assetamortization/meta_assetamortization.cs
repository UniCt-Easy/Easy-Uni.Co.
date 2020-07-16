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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
//Pino: using rivalutazionebene; diventato inutile
using funzioni_configurazione;//funzioni_configurazione

namespace meta_assetamortization//meta_rivalutazionebene//
{
	/// <summary>
	/// Summary description for rivalutazionebene.
	/// </summary>
	public class Meta_assetamortization : Meta_easydata 
	{
		public Meta_assetamortization(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "assetamortization") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
	
		protected override Form GetForm(string FormName) {
			if (FormName=="default")
			{
				Name="Rivalutazione/Svalutazione";
				DefaultListType="default";
				return MetaData.GetFormByDllName("assetamortization_default");//PinoRana
			}
			return null;
		}
        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
            //if ((C.ColumnName=="idassetloadkind") || (C.ColumnName == "yassetload")||(C.ColumnName == "nassetload"))return;
            if (C.ColumnName == "transmitted") return;
            base.InsertCopyColumn(C, Source, Dest);
        }

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"adate",GetSys("datacontabile"));
            SetDefault(PrimaryTable, "flag", 1);
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["namortization"],null,null,6);
            RowChange.setMinimumTempValue(T.Columns["namortization"], 99999000);
			return base.Get_New_Row(ParentRow, T);
		}

		public override bool IsValid(DataRow R,out string errmess, out string errfield) {
			// Bisogna innanzitutto chiamare IsValid della classe base
			if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (CfgFn.GetNoNullInt32(R["idinventoryamortization"]) <= 0) {
                errmess = "E' necessario specificare il tipo di rivalutazione/svalutazione.";
                errfield = "idinventoryamortization";
                return false;
            }
            if (CfgFn.GetNoNullInt32(R["idasset"]) <= 0) {
				errmess="E' necessario specificare un cespite.";
				errfield=null;
				return false;
			}
			if(R["description"].ToString()=="") {
				errmess="E' necessario specificare la descrizione della rivalutazione/svalutazione.";
				errfield="description";
				return false;
			}
			if(R["amortizationquota"]==DBNull.Value) {
				errmess="E' necessario specificare la quota di rivalutazione/svalutazione.";
				errfield="amortizationquota";
				return false;
			}
			if(R["assetvalue"]==DBNull.Value) {
				errmess="Un determinato campo non puÚ essere vuoto (valore cespite)";
				errfield=null;
				return false;
			}
			return true;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
			if(ListingType=="default")
				return base.SelectOne(ListingType, filter,"assetamortizationview", ToMerge);
			return base.SelectOne(ListingType, filter,searchtable, ToMerge);
		}
	}
}
