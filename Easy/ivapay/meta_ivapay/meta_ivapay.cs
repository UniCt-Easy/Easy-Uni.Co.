
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

namespace meta_ivapay{//meta_liquidazioneiva//
	/// <summary>
	/// Summary description for meta_liquidazioneiva
	/// </summary>
	public class Meta_ivapay : Meta_easydata {
		public Meta_ivapay(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "ivapay") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
			EditTypes.Add("wizard_calcolo");
			EditTypes.Add("wizard_acconto");
			Name="Liquidazione IVA";
		}
		
		protected override Form GetForm(string FormName){
			if (FormName=="default")
			{
				Name = "Liquidazione periodica";
				DefaultListType="default";
				this.CanInsert=false;
				this.CanInsertCopy=false;

				return GetFormByDllName("ivapay_default");
			}
			if (FormName=="wizard_calcolo")
			{
//				ActAsList();
				Name = "Calcola liquidazione corrente";
				return GetFormByDllName("ivapay_wizard_calcolo");
			}
			if (FormName=="wizard_acconto")
			{
//				ActAsList();
				Name = "Acconto";
				return GetFormByDllName("ivapay_wizard_acconto");
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");

				DescribeAColumn(T,"yivapay","Esercizio");
				DescribeAColumn(T,"nivapay","Numero");
				DescribeAColumn(T,"paymentkind","Tipo");
				DescribeAColumn(T,"start","Data inizio");
				DescribeAColumn(T,"stop","Data fine");
				DescribeAColumn(T,"totalcredit","Totale iva a credito");
				DescribeAColumn(T,"totaldebit","Totale iva a debito");
				DescribeAColumn(T,"refundamount","Importo rimborso");
				DescribeAColumn(T,"paymentamount","Importo versamento");
				DescribeAColumn(T,"prorata","% detraibilità");
				DescribeAColumn(T,"mixed","% promiscuità");
				DescribeAColumn(T,"paymentdetails","Estremi versamento");
				DescribeAColumn(T,"dateivapay","Data liquidazione");
				DescribeAColumn(T,"assesmentdate","Data regolamento");
				HelpForm.SetFormatForColumn(T.Columns["prorata"],"p");
				HelpForm.SetFormatForColumn(T.Columns["mixed"],"p");
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "yivapay");
			RowChange.MarkAsAutoincrement(T.Columns["nivapay"], null, null, 7);
			return base.Get_New_Row(ParentRow,T);
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "yivapay", Conn.GetEsercizio());
			SetDefault(PrimaryTable, "dateivapay", Conn.GetDataContabile());
		}
	}
}
