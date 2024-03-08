
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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

namespace meta_payrollkind//meta_descrizionecedolino//
{
	/// <summary>
	/// Summary description for Meta_descrizionecedolino.
	/// </summary>
	public class Meta_payrollkind : Meta_easydata
	{
		public Meta_payrollkind(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "payrollkind") 
		{
            Name = "Descrizione Cedolino";
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType = "default";
				ActAsList();
				return MetaData.GetFormByDllName("payrollkind_default");
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")
			{
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"idpayrollkind","Tipo Descr. Cedolino");
				DescribeAColumn(T,"description","Descrizione");
			}
		}
	}
}
