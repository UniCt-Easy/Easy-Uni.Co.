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


namespace meta_pettycashsetupview {//meta_perspiccolespeseview//
	/// <summary>
	/// Summary description for perspiccolespeseview.
	/// </summary>
	public class Meta_pettycashsetupview : Meta_easydata {
		public Meta_pettycashsetupview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "pettycashsetupview") {
			ListingTypes.Add("default");
			Name = "";
		}

		public override string GetStaticFilter(string ListingType) {
			string filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
			return filteresercizio;
		}

		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				int nPos = 1;
				DescribeAColumn(T, "pettycode", "Cod. Fondo Economale", nPos++);
				DescribeAColumn(T, "pettycash", "Fondo Economale", nPos++);
                DescribeAColumn(T, "flagmov", "Genera mov. finanziari", nPos++);
				DescribeAColumn(T, "ayear", "Esercizio", nPos++);
				DescribeAColumn(T, "registrymanager", "Responsabile", nPos++);
				DescribeAColumn(T, "manager", "Denominazione Responsabile", nPos++);
				DescribeAColumn(T, "finincomecode", "Cod. bilancio Entrata", nPos++);
				DescribeAColumn(T, "finincometitle", "Denominazione", nPos++);
				DescribeAColumn(T, "finexpensecode", "Cod. bilancio Spesa", nPos++);
				DescribeAColumn(T, "finexpensetitle", "Denominazione", nPos++);
				DescribeAColumn(T, "codeacc", "Codice Conto E/P", nPos++);
				DescribeAColumn(T, "account", "Conto E/P", nPos++);
				DescribeAColumn(T, "amount", "Importo", nPos++);
			}
		}   
	}
}