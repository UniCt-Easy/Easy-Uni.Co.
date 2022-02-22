
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
//Pino: using movimentobancario; diventato inutile
//Pino: using movimentobancarioacredito; diventato inutile
//using banktransaction_importazione;//movimentobancario_import
using metadatalibrary;
using funzioni_configurazione;

namespace meta_banktransaction//meta_movimentobancario//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
    public class Meta_banktransaction : Meta_easydata {
        public Meta_banktransaction(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "banktransaction") {		
            Name= "Movimento bancario";
            EditTypes.Add("acredito");
            EditTypes.Add("adebito");
			EditTypes.Add("importazione");
			EditTypes.Add("recuperadati");
			ListingTypes.Add("adebito");
            ListingTypes.Add("payment");
			ListingTypes.Add("proceeds");
            ListingTypes.Add("acredito");
        }
        protected override Form GetForm(string FormName){
//            if (FormName=="lista") {
//                Name="Lista dei movimenti bancari a debito";
//                 return new frmMovimentoBancarioADebito();
//            }

			if (FormName == "payment") {
				Name = "Transazione Bancaria";
				DefaultListType="adebito";
				return GetFormByDllName("banktransaction_payment");
			}
			if (FormName == "proceeds") {
				Name = "Transazione Bancaria";
				DefaultListType="acredito";
				return GetFormByDllName("banktransaction_proceeds");
			}

			if (FormName == "default") {
				Name = "Esitazione bancaria";
				DefaultListType="default";
				return GetFormByDllName("banktransaction_default");
			}

			if (FormName=="importazione") 
			{
				Name = "Importazione esito movimenti";
				return MetaData.GetFormByDllName("banktransaction_importazione");
			}
			
			if (FormName == "recuperadati") {
				Name = "Recupero Dati Movimenti Bancari e Esiti";
				return GetFormByDllName("banktransaction_recuperadati");
			}

			return null;
        }

		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "yban", GetSys("esercizio"));
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			RowChange.SetSelector(T,"yban");
			RowChange.MarkAsAutoincrement(T.Columns["nban"],null,
				null,7);
			SetDefault(T, "yban", GetSys("esercizio"));
            RowChange.setMinimumTempValue(T.Columns["nban"], 9900000);
			DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
		}

        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
            DescribeAColumn(T,"description","Descrizione");
			if (ListingType == "proceeds") 
			{
				foreach (DataColumn c in T.Columns){
					DescribeAColumn(T, c.ColumnName, "",-1);
				}
                int pos = 1;
				//DescribeAColumn(T, "ypro", "Esercizio",1);
				//DescribeAColumn(T, "npro", "Numero documento",2);
                DescribeAColumn(T, "!nmov", "N.mov.", "income1.nmov", pos++);				
                DescribeAColumn(T, "transactiondate", "Data operazione", pos++);
                DescribeAColumn(T, "valuedate", "Data valuta", pos++);
                DescribeAColumn(T, "amount", "Importo", pos++);
                DescribeAColumn(T, "description", "Descrizione", pos++);
                DescribeAColumn(T, "idbankimport", "Importazione Esiti", pos++);
				DescribeAColumn(T, "bankreference", "Riferimento banca", pos++);
			} 
			if (ListingType == "payment") 
			{
				foreach (DataColumn c in T.Columns)
				{
					DescribeAColumn(T, c.ColumnName, "",-1);
				}
                int pos = 1;
                //DescribeAColumn(T, "ypay", "Esercizio", 1);
                //DescribeAColumn(T, "npay", "Numero documento",2);
                DescribeAColumn(T, "!nmov", "N.mov.", "expense1.nmov", pos++);                
                DescribeAColumn(T, "transactiondate", "Data operazione", pos++);
                DescribeAColumn(T, "valuedate", "Data valuta", pos++);
                DescribeAColumn(T, "amount", "Importo", pos++);
                DescribeAColumn(T, "description", "Descrizione", pos++);
                DescribeAColumn(T, "idbankimport", "Importazione Esiti", pos++);
				DescribeAColumn(T, "bankreference", "Riferimento banca", pos++);
			}
		}   	

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "adebito") {
                filter=GetData.MergeFilters(filter,"(transactionkind='D')");
            }
            if (ListingType == "acredito") {
                filter=GetData.MergeFilters(filter,"(transactionkind='C')");
            }
            return base.SelectOne(ListingType, filter, "banktransactionview", Exclude);
        }

		public override bool IsValid(DataRow R, out string errmess, out string errfield) 
		{
			errmess = null;
			errfield = null;
			if (R["transactiondate"] is DBNull)
			{
				errmess = "Per esitare un movimento occorre inserire la data operazione.";
				errfield = "transactiondate";
				return false;
			}
			decimal amount = CfgFn.GetNoNullDecimal(R["amount"]);
			if (amount ==0) {
				errmess="L'importo dell'esito non può essere nullo";
				errfield="amount";
				return false;
			}

			string kind = R["kind"].ToString().ToUpper();
			if (kind == "D") {
				if (R["idexp"].ToString() == "") {
					errmess = "Bisogna specificare il movimento finanziario che si sta esitando";
					errfield = "idexp";
					return false;
				}
			}
			if (kind == "C") {
				if (R["idinc"].ToString() == "") {
					errmess = "Bisogna specificare il movimento finanziario che si sta esitando";
					errfield = "idinc";
					return false;
				}
			}
			return true;
		}
    }	
}
