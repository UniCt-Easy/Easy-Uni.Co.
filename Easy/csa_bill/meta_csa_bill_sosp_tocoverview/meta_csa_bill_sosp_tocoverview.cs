
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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

namespace meta_csa_bill_sosp_tocoverview
{
	/// <summary>
	/// </summary>
	public class Meta_csa_bill_sosp_tocoverview : Meta_easydata
	{
		public Meta_csa_bill_sosp_tocoverview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "csa_bill_sosp_tocoverview")
		{
			ListingTypes.Add("default");
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType == "default")
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);
				int nPos = 1;
				DescribeAColumn(T, "ybill", "Esercizio", nPos++);
				DescribeAColumn(T, "nbill", "Numero bolletta", nPos++);
				DescribeAColumn(T, "billkind", "Tipo bolletta", nPos++);
				DescribeAColumn(T, "tocover", "Importo rimanente da coprire", nPos++);
			}
		}
	}
}
