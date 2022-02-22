
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
//using strutturaaliquotelista;
using metadatalibrary;


namespace meta_ratevalidity//meta_strutturaaliquote//
{
	public class Meta_ratevalidity : Meta_easydata
	{
		public Meta_ratevalidity(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "ratevalidity")
		{
			Name = "Struttura aliquote";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			ListingTypes.Add("combo");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="default";
				return GetFormByDllName("ratevalidity_default");
			}
			else return null;
		}
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType == "default")
			{
				DescribeAColumn(T,"taxcode","Codice ritenuta");
				DescribeAColumn(T,"validitystart","Data decorrenza");
			}
			else 
			{
				DescribeAColumn(T,"taxcode","Codice ritenuta");
				DescribeAColumn(T,"validitystart","");
				DescribeAColumn(T,"!datainiziostrutturastringa","Data decorrenza");
				ComputeRowsAs(T, ListingType);
			}
		}
		public override void CalculateFields(DataRow R, string list_type) 
		{
			if (R["validitystart"].ToString() == QueryCreator.EmptyDate().ToString()) 
			{
				R["!datainiziostrutturastringa"] = "";
			}
			else
			{
				R["!datainiziostrutturastringa"] = R["validitystart"].ToString();
			}
		}  


	}
}
