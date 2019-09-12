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
//using faseentrata;

namespace meta_incomephase//meta_faseentrata//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_incomephase : Meta_easydata 
	{
		public Meta_incomephase(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "incomephase") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName)
		{
			
			if (FormName=="default") 
			{
				Name = "Fasi di entrata";
				ActAsList();
				return GetFormByDllName("incomephase_default");
//				frmfaseentrata F = new frmfaseentrata();
//				return F;
			}
			return null;
		}			
	
		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
			RowChange.MarkAsAutoincrement(T.Columns["nphase"],null,
				null,0);
			return base.Get_New_Row(ParentRow, T);
		}
	
		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			foreach (DataColumn C in T.Columns)
				DescribeAColumn(T, C.ColumnName, "");
			DescribeAColumn(T, "nphase","Codice Fase");
			DescribeAColumn(T, "description","Descrizione");
		}   
	}
}
