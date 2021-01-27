
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

namespace meta_pettycashopitinerationview
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_pettycashopitinerationview : Meta_easydata {
		public Meta_pettycashopitinerationview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "pettycashopitinerationview") {
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
				DescribeAColumn(T, "codefin", "Voce bil.",nPos++);
				DescribeAColumn(T, "finance", "Denom. bil.",nPos++);
				DescribeAColumn(T, "codeupb", "Cod. U.P.B.",nPos++);
				DescribeAColumn(T, "upb", "U.P.B.",nPos++);
				DescribeAColumn(T, "description", "Descrizione",nPos++);
				DescribeAColumn(T, "yitineration", "Eserc. Missione",nPos++);
				DescribeAColumn(T, "nitineration", "Num. Missione",nPos++);
                DescribeAColumn(T, "codeser", ".Cod. Prestazione", nPos++);
				DescribeAColumn(T, "service", "Prestazione",nPos++);
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
