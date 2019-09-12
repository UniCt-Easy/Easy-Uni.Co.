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
using metaeasylibrary;
using metadatalibrary;

namespace meta_chargehandling { 
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_chargehandling : Meta_easydata {
		public Meta_chargehandling(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "chargehandling") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				Name="Trattamento delle spese";               
				return MetaData.GetFormByDllName("chargehandling_default");
			}
			return null;
		}			
    
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
            if (ListingType == "default"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idchargehandling", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "handlingbankcode", "Cod. per Banca", nPos++);
                DescribeAColumn(T, "payment_kind", "Natura del Pagamento", nPos++);
                DescribeAColumn(T, "motive", "Causale Esenzione Spese", nPos++);
                DescribeAColumn(T, "active", "", nPos++);
            }
		}

		//aggiungere un IsValid su flagstandard
		public override bool IsValid(DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 

			if (R["idchargehandling"].ToString()==""){
				errmess="Non è stata selezionata nessun tipo di trattamento delle spese";
				errfield="idchargehandling";
				return false;
			}
            return true;
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idchargehandling"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idchargehandling");
            if (N < 9999000)
                R["idchargehandling"] = 9999001;
            else
                R["idchargehandling"] = N + 1;

            return R;
        }
    }
}