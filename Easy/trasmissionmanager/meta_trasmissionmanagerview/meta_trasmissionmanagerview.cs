
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;

namespace meta_trasmissionmanagerview
{
	/// <summary>
	/// Summary description for Meta_trasmissionmanagerview.
	/// </summary>
	public class Meta_trasmissionmanagerview : Meta_easydata
	{
		public Meta_trasmissionmanagerview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "trasmissionmanagerview") 
		{
			ListingTypes.Add("default");
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns (T, ListingType);
			if (ListingType=="default") 
			{
				foreach (DataColumn C in T.Columns)	DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T, "registry", "Denominazione");
				DescribeAColumn(T, "description", "Documento");
			}
		}

	}
}
