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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_regionalrateforcityvalidity//meta_strutturaaliquoteregionalipercomune//
{
	/// <summary>
	/// Summary description for Meta_strutturaaliquoteregionalipercomune.
	/// </summary>
	public class Meta_regionalrateforcityvalidity : Meta_easydata
	{
		public Meta_regionalrateforcityvalidity(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "regionalrateforcityvalidity")
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
				Name="Struttura Aliquote Regionali per Comune";
				DefaultListType = "default";
				return GetFormByDllName("regionalrateforcityvalidity_default");
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
				DescribeAColumn(T,"taxcode","");
				DescribeAColumn(T,"idcity","");
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
				return base.SelectOne(ListingType, filter, "regionalrateforcityvalidityview", ToMerge);
			return base.SelectOne(ListingType, filter, searchtable, ToMerge);
		}

	}
}
