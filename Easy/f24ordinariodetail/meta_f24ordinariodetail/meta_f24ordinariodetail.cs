
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_f24ordinariodetail {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_f24ordinariodetail : Meta_easydata {
		public Meta_f24ordinariodetail(DataAccess Conn, MetaDataDispatcher Dispatcher) : base(Conn, Dispatcher, "f24ordinariodetail") {
			EditTypes.Add("single");
			ListingTypes.Add("lista");
		}
		protected override Form GetForm(string FormName) {
			switch (FormName) {
				case "single": {
						DefaultListType = "lista";
						Name = "Inserimento Sezione F24 Manuale";
						return MetaData.GetFormByDllName("f24ordinariodetail_single");
					}
			}
			return null;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
			RowChange.SetSelector(T, "idf24ordinario");
			RowChange.MarkAsAutoincrement(T.Columns["iddetail"], null, null, 0);
			return base.Get_New_Row(ParentRow, T);

		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType == "lista") {
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;

				DescribeAColumn(T, "iddetail", "Numero Dettaglio", nPos++);
				DescribeAColumn(T, "idf24sezione", "Tipo Sezione", nPos++);
				DescribeAColumn(T, "!f24sezione", "Sezione", "f24sezione.descrizione", nPos++);
				DescribeAColumn(T, "codicetributo", "Cod. Tributo", nPos++);
				DescribeAColumn(T, "catastalecomune", "Cod. Catastale Comune", nPos++);
				DescribeAColumn(T, "!regionefiscale", "Regione Fiscale", "fiscaltaxregion.title", nPos++);
				DescribeAColumn(T, "codiceufficio", "Cod. Ufficio", nPos++);
				DescribeAColumn(T, "codiceatto", "Cod. Atto", nPos++);
				DescribeAColumn(T, "riferimentoa", "Rif. A", nPos++);
				DescribeAColumn(T, "riferimentob", "Rif. B", nPos++);
				DescribeAColumn(T, "importoadebito", "Debito", nPos++);
				DescribeAColumn(T, "importoacredito", "Credito", nPos++);
			}
		}
	}
}
