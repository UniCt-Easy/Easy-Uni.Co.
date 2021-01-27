
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_csa_agencypaymethod {
	/// <summary>
	/// Revised by Nino on 11/1/2003
	/// </summary>
	public class Meta_csa_agencypaymethod : Meta_easydata {
		public Meta_csa_agencypaymethod(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csa_agencypaymethod") {
			Name= "Modalità pagamento Ente CSA";
			EditTypes.Add("anagrafica");
			ListingTypes.Add("anagrafica");
            ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="anagrafica") 
				return GetFormByDllName("csa_agencypaymethod_anagrafica");
			return null;
		}	
		

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idcsa_agency");
            RowChange.MarkAsAutoincrement(T.Columns["idcsa_agencypaymethod"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);
        }

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);

			if (ListingType=="anagrafica") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T,C.ColumnName,"",-1);
				}
				int nPos = 1;
                DescribeAColumn(T, "idcsa_agencypaymethod", "#", nPos++);
				DescribeAColumn(T, "vocecsa","Voce CSA",nPos++);
                DescribeAColumn(T, "!paymentdescr", "Descrizione","registrypaymethod.paymentdescr", nPos++);
                DescribeAColumn(T, "!iban", "IBAN", "registrypaymethod.iban", nPos++);
                DescribeAColumn(T, "!idbank", "ABI", "registrypaymethod.idbank", nPos++);
                DescribeAColumn(T, "!idcab", "CAB", "registrypaymethod.idcab", nPos++);
                DescribeAColumn(T, "!cc", "C/C", "registrypaymethod.cc", nPos++);
                DescribeAColumn(T, "!cin", "CIN", "registrypaymethod.cin", nPos++);
            }
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 

			if (CfgFn.GetNoNullInt32(R["idregistrypaymethod"])==0) {
				errmess="Non è stata selezionata nessuna modalità pagamento";
                errfield = "idregistrypaymethod";
				return false;
			}
			return true;
		}

        public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "csa_agencypaymethodview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }
	}
}
