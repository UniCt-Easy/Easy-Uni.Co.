
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
//Pino: using dettmovimentobancario; diventato inutile
using metadatalibrary;

namespace meta_banktransactiondetail//meta_dettmovimentobancario//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
    public class Meta_banktransactiondetail : Meta_easydata {
        public Meta_banktransactiondetail(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "banktransactiondetail") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName)
		{
			if (FormName=="default")
			{
				Name = "Dettaglio del movimento bancario";
				return MetaData.GetFormByDllName("banktransactiondetail_default");//PinoRana
			}
            return null;
        }			
    
        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
            DescribeAColumn(T,"yban","");
            DescribeAColumn(T,"nban","");
            DescribeAColumn(T,"noperation",""); 
			DescribeAColumn(T,"bankreference","Rif. Banca");
            DescribeAColumn(T,"transactiondate","Data Operazione");
            DescribeAColumn(T,"valuedate","Data Valuta");
            DescribeAColumn(T,"amount","Importo"); 
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.MarkAsAutoincrement(T.Columns["noperation"],null,
                null,7);
            RowChange.SetSelector(T, "yban");
            RowChange.SetSelector(T, "nban");            
            return base.Get_New_Row(ParentRow, T);
        }

		public override bool IsValid(DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R,out errmess,out errfield))return false;
			if (R["amount"]==DBNull.Value){
				errmess= "E' necessario specificare l'importo";
				errfield="amount";
				return false;
			}
			if (R["transactiondate"] is DBNull)
			{
				errmess = "Inserire la data operazione";
				errfield = "transactiondate";
				return false;
			}
			return true;
		}
	}
}
