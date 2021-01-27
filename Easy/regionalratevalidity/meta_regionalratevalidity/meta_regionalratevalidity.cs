
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


namespace meta_regionalratevalidity//meta_strutturaaliquoteregionali//
{
	/// <summary>
	/// Summary description for Meta_strutturaaliquoteregionali.
	/// </summary>
	public class Meta_regionalratevalidity : Meta_easydata
	{
		public Meta_regionalratevalidity(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "regionalratevalidity")
		{
			
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName)
		{
			//			if (FormName=="default") {
			//				ActAsList();
			//				StartEmpty=true;
			//				return new frmaliquotaritenutalista();
			//			}

			if (FormName=="default") 
			{
				Name="Struttura Aliquote Regionali";
				DefaultListType = "default";
				return GetFormByDllName("regionalratevalidity_default");
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
				DescribeAColumn(T,"taxcode","");
				DescribeAColumn(T,"idregion","");
				DescribeAColumn(T,"validitystart","Data");
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
  
		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) 
		{
			if (ListingType == "default")	
				return base.SelectOne(ListingType, filter, "regionalratevalidityview", ToMerge);
			return base.SelectOne(ListingType, filter, searchtable, ToMerge);
		}

	}
}
