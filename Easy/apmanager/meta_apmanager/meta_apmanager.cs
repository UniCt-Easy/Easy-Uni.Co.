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
using metaeasylibrary;
using metadatalibrary;



namespace meta_apmanager
{
	/// <summary>
	/// Summary description for Meta_casualcontractyear.
	/// </summary>
	public class Meta_apmanager : Meta_easydata
	{
		public Meta_apmanager(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "apmanager") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType = "default";
				ActAsList();
				Name = "Qualifica (per anagrafe prestazioni)";
				return MetaData.GetFormByDllName("apmanager_default");
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")	
			{
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"idapmanager","Codice Qualifica");
				DescribeAColumn(T,"description","Descrizione");
			}
		}

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"ayear",GetSys("esercizio"));
		}
	}
}