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

namespace meta_admpay {
	/// <summary>
	/// Summary description for Meta_admpay.
	/// </summary>
	public class Meta_admpay : Meta_easydata {
		public Meta_admpay(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "admpay") {	
			EditTypes.Add("default");
			EditTypes.Add("wizardmovspesa");
            EditTypes.Add("split");
            EditTypes.Add("spt");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="default";
				Name = "Pagamento Stipendi";
				return GetFormByDllName("admpay_default");
			}
			if (FormName == "wizardmovspesa") {
				DefaultListType="default";
				Name = "Procedura Guidata Creazione Movimenti di Spesa per il Pagamento degli Stipendi";
				return GetFormByDllName("admpay_to_expense");
			}
            if (FormName == "split") {
                DefaultListType = "default";
                Name = "Procedura che splitta le colonne dei contributi in più colonne";
                return GetFormByDllName("admpay_splitcolumn");
            }
            if (FormName == "spt") {
                DefaultListType = "default";
                Name = "Procedura che splitta le colonne dei contributi in più colonne";
                return GetFormByDllName("admpay_spt");
            }
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType=="default"){
				foreach(DataColumn C in T.Columns) 
					DescribeAColumn(T,C.ColumnName,"",-1);
				int nPos = 1;
				DescribeAColumn(T,"yadmpay", "Esercizio", nPos++);
				DescribeAColumn(T,"nadmpay", "Numero", nPos++);
				DescribeAColumn(T,"description", "Descrizione", nPos++);
				DescribeAColumn(T,"amount", "Importo", nPos++);
				DescribeAColumn(T,"processed", "Elaborato", nPos++);
			}
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable, "yadmpay", Conn.GetSys("esercizio"));
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "yadmpay");
			RowChange.MarkAsAutoincrement(T.Columns["nadmpay"], null, null, 7);
			return base.Get_New_Row(ParentRow, T);
		}


	}
}