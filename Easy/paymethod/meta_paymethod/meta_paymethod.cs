
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
//using modalitapagamento;
using metaeasylibrary;
using metadatalibrary;
//using modalitapagamentoanagrafica;


namespace meta_paymethod//meta_modalitapagamento//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_paymethod : Meta_easydata {
		public Meta_paymethod(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "paymethod") {		
			Name= "Modalità di pagamento";
            //EditTypes.Add("lista");
            ListingTypes.Add("default");
			EditTypes.Add("anagrafica");
			ListingTypes.Add("anagrafica");
            ListingTypes.Add("checkimport");
		}
		protected override Form GetForm(string FormName){
			/*
			 if (FormName=="lista") {
				Name="Lista modalità di pagamento";
                ActAsList();
				return new frmModalitaPagamento();
			}
			*/
			if (FormName=="anagrafica") {
				Name="Lista modalità di pagamento";
				ActAsList();
				return GetFormByDllName("paymethod_anagrafica");
				//return new frmModalitaPagamentoAnagrafica();
			}
			return null;
		}


		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
            if (ListingType == "checkimport"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "methodbankcode", "Codice banca", nPos++);
                DescribeAColumn(T, "allowdeputy", "Ammetti Delegato", nPos++);

                return;
            }
            
			if (ListingType=="anagrafica") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);
				int nPos = 1;
				DescribeAColumn(T,"idpaymethod","#",nPos++);
				DescribeAColumn(T,"description","Descrizione",nPos++);
				DescribeAColumn(T,"active","Flag attivo",nPos++);
				DescribeAColumn(T,"allowdeputy","Ammetti Delegato",nPos++);
                DescribeAColumn(T, "methodbankcode", "Codice banca", nPos++);
                DescribeAColumn(T, "committeecode", "Cod.Commissioni", nPos++);
				DescribeAColumn(T, "abi_label", "Tipo Pagamento SIOPE+", nPos++);
				return;
			}

			int n = 1;
			foreach (DataColumn C in T.Columns)
				DescribeAColumn(T, C.ColumnName, "", -1);
            DescribeAColumn(T, "idpaymethod", "#", n++);
			DescribeAColumn(T,"description","Descrizione",n++);
			DescribeAColumn(T,"allowdeputy","Ammetti Delegato",n++);
            DescribeAColumn(T, "methodbankcode", "Codice", n++);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idpaymethod"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idpaymethod");
            if (N < 9999000)
                R["idpaymethod"] = 9999001;
            else
                R["idpaymethod"] = N + 1;

            return R;
        }
    }		
}
