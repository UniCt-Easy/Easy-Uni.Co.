
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
using metadatalibrary;

namespace meta_banktransactionview//meta_movimentobancarioview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
    public class Meta_banktransactionview : Meta_easydata {
        public Meta_banktransactionview(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "banktransactionview") {		
            Name= "Movimento bancario - elenco";
			EditTypes.Add("estinzionemultipla");
			ListingTypes.Add("estinzionemultipla");
		}
		public override string GetStaticFilter(string ListingType) {
			if (ListingType=="default"){
				string filterEsercizio = "(yban='"+GetSys("esercizio")+"')";
				return filterEsercizio;
			}
			return base.GetStaticFilter (ListingType);
		}


        private string[] mykey = new string[] { "yban", "nban" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
			if (ListingType == "estinzionemultipla") 
			{
				foreach (DataColumn c in T.Columns) 
				{
					DescribeAColumn(T, c.ColumnName, "");
				}// da cambiare i nomi dei campi ma prima rivedere il form
				DescribeAColumn(T, "ydoc", "Esercizio");
				DescribeAColumn(T, "ndoc", "Numero documento");
				DescribeAColumn(T, "performed", "Flag esito");
				DescribeAColumn(T, "transactiondate", "Data operazione");
				DescribeAColumn(T, "valuedate", "Data valuta");
				DescribeAColumn(T, "amount", "Importo");
				DescribeAColumn(T, "performedamount", "Importo esitato");
				DescribeAColumn(T, "description", "Descrizione");
				DescribeAColumn(T, "registry", "Creditore/debitore");
				DescribeAColumn(T, "bankreference", "Riferimento banca");
			} 
			if (ListingType == "default") {
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T,C.ColumnName,"",-1);
				}
				int nPos = 1;
				DescribeAColumn(T, "ypay", "Eserc. Mandato", nPos++);
				DescribeAColumn(T, "npay", "Num. Mandato", nPos++);
				DescribeAColumn(T, "ypro", "Eserc. Reversale", nPos++);
				DescribeAColumn(T, "npro", "Num. Reversale", nPos++);

				string nomefasespesa = Conn.DO_READ_VALUE("expensephase", "nphase=" + security.GetSys("maxexpensephase").ToString(), "description").ToString();
				DescribeAColumn(T, "yexp", "Eserc. " + nomefasespesa, nPos++);
				DescribeAColumn(T, "nexp", "Num. " + nomefasespesa, nPos++);

				string nomefaseentrata = Conn.DO_READ_VALUE("incomephase", "nphase=" + security.GetSys("maxincomephase").ToString(), "description").ToString();
				DescribeAColumn(T, "yinc", "Eserc. " + nomefaseentrata, nPos++);
				DescribeAColumn(T, "ninc", "Num. " + nomefaseentrata, nPos++);


				DescribeAColumn(T, "idpay", "Prog. sub Spesa/Entrata", nPos++);
				DescribeAColumn(T, "amount", "Importo", nPos++);
				DescribeAColumn(T, "transactiondate", "Data operazione", nPos++);
				DescribeAColumn(T, "valuedate", "Data valuta", nPos++);
				DescribeAColumn(T, "idbankimport", "Num. Importazione Esiti", nPos++);
			} 
			
        }   	
		protected override Form GetForm(string FormName)
		{
			if (FormName=="estinzionemultipla") 
			{
				ActAsList();
				StartEmpty = true;
				return GetFormByDllName("banktransactionview_estinzionemultipla");
			}
			return null;
		}
    }	
}
