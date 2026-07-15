/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

namespace meta_upbcostpartitionsetupview
{
	/// <summary>
	/// Summary description for meta_upbcostpartitionsetupview.
	/// </summary>
	public class Meta_upbcostpartitionsetupview :Meta_easydata
	{
		public Meta_upbcostpartitionsetupview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "upbcostpartitionsetupview")
		{
			ListingTypes.Add("default");
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType == "default")
			{
				foreach (DataColumn C in T.Columns)
				{
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T, "codeupb", "Cod. UPB", nPos++);
				DescribeAColumn(T, "upb", "UPB", nPos++);
				DescribeAColumn(T, "codemotive", "Cod. Causale", nPos++);
				DescribeAColumn(T, "accmotive", "Causale", nPos++);
				DescribeAColumn(T, "costpartitioncode", "Cod. Ripartizione", nPos++);
				DescribeAColumn(T, "costpartition", "Ripartizione", nPos++);
				DescribeAColumn(T, "start", "Data inizio validità", nPos++);
				DescribeAColumn(T, "stop", "Data fine validità", nPos++);
			}
		}

	}
}