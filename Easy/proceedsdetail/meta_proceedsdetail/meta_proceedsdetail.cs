/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace meta_proceedsdetail
{

	public class Meta_proceedsdetail : Meta_easydata {
		public Meta_proceedsdetail(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "proceedsdetail") {
			EditTypes.Add("single");
			// listapermovbancario elenca in ordine di numero mandato filtrando solo l'esercizio corrente            
			ListingTypes.Add("default");
			Name = "Esito Bancario";
		}

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
				DescribeAColumn(T,"ypro","",-1);
				DescribeAColumn(T,"npro","",-1);
				DescribeAColumn(T,"noperation","",-1); 
				DescribeAColumn(T,"bankreference","Rif. Banca",1);
				DescribeAColumn(T,"transactiondate","Data Operazione",2);
				DescribeAColumn(T,"valuedate","Data Valuta",3);
				DescribeAColumn(T,"amount","Importo",4); 
			}
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R,out errmess,out errfield))return false;
			if (R["amount"]==DBNull.Value){
				errmess= "E' necessario specificare l'importo";
				errfield="amount";
				return false;
			}
			if (R["transactiondate"] is DBNull) {
				errmess = "Inserire la data operazione";
				errfield = "transactiondate";
				return false;
			}
			return true;
		}

		protected override Form GetForm(string FormName){

			if (FormName=="single"){
				return MetaData.GetFormByDllName("proceedsdetail_single");//PinoRana
			}
			return null;
		}			
	}
}
