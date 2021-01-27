
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

namespace meta_pettycashopprofserviceview
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_pettycashopprofserviceview : Meta_easydata {
		public Meta_pettycashopprofserviceview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "pettycashopprofserviceview") {
			ListingTypes.Add("default");
		}

		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				int nPos = 1;
				DescribeAColumn(T, "pettycode", "Cod. fondo",nPos++);
				//DescribeAColumn(T, "pettycash", "Fondo",nPos++);
				DescribeAColumn(T, "yoperation", "Eserc. op.",nPos++);
				DescribeAColumn(T, "noperation", "Num. op.",nPos++);
				DescribeAColumn(T, "finance", "Denom. bil.",nPos++);
				DescribeAColumn(T, "upb", "U.P.B.",nPos++);
				DescribeAColumn(T, "description", "Descrizione",nPos++);
				DescribeAColumn(T, "ycon", "Eserc.Contratto",nPos++);
				DescribeAColumn(T, "ncon", "Num. Contratto",nPos++);
                DescribeAColumn(T, "codeser", ".Cod. Prestazione", nPos++);
				DescribeAColumn(T, "service", "Prestazione",nPos++);
				//DescribeAColumn(T, "servicestart", "Data Inizio",nPos++);
				//DescribeAColumn(T, "servicestop", "Data Fine",nPos++);
				DescribeAColumn(T, "movkind", "Tipo Contabil.",nPos++);
				DescribeAColumn(T, "registry", "Incaricato",nPos++);
				DescribeAColumn(T, "doc", "Documento",nPos++);
				DescribeAColumn(T, "docdate", "Data doc.",nPos++);
				DescribeAColumn(T, "manager", "Responsabile",nPos++);
				DescribeAColumn(T, "amount", "Importo",nPos++);
				DescribeAColumn(T, "adate", "Data contabile",nPos++);
			}
		}

	}
}
