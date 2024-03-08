
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
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;
using System.Data;

namespace meta_billview {
	/// <summary>
	/// Summary description for Meta_billview.
	/// </summary>
	public class Meta_billview : Meta_easydata {
		public Meta_billview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "billview") {
			ListingTypes.Add("default");
			ListingTypes.Add("spesa");
			ListingTypes.Add("entrata");
			DefaultListType = "default";
			Name = "Partita pendente";
		}
        public override string GetFilterForSearch(DataTable T) {
            return null;
        }
        private string[] mykey = new string[] { "billkind", "ybill", "nbill" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			int nPos = 1;
			switch (listtype) {
				case "default": {
					foreach (DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "", -1);
					}
					DescribeAColumn(T, "ybill", "Esercizio", nPos++);
					DescribeAColumn(T, "nbill", "Num. bolletta", nPos++);
					DescribeAColumn(T, "billkind", "Tipo", nPos++);
					DescribeAColumn(T, "adate", "Data contabile", nPos++);
					DescribeAColumn(T, "registry", "Anagrafica", nPos++);
					DescribeAColumn(T, "motive", "Causale", nPos++);
					DescribeAColumn(T, "total", "Importo Apertura", nPos++);
                    DescribeAColumn(T, "reduction", "Storni", nPos++);
                    DescribeAColumn(T, "covered", "Importo Coperto", nPos++);
                    DescribeAColumn(T, "regularized", "Esiti", nPos++);
                    DescribeAColumn(T, "toregularize", "Importo Da Regolarizzare", nPos++);
					DescribeAColumn(T, "tocover", "Importo Da Coprire", nPos++);
                    //DescribeAColumn(T, "active", "Da regolarizzare", nPos++);
                    DescribeAColumn(T, "regularizationnote", "Note", nPos++);
                    DescribeAColumn(T, "treasurer", "Cassiere", nPos++);
					break;
				}
				case "entrata":
				case "spesa": {
					foreach (DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "", -1);
					}

					DescribeAColumn(T, "nbill", "Num. bolletta", nPos++);
					DescribeAColumn(T, "registry", "Anagrafica", nPos++);
					DescribeAColumn(T, "motive", "Causale", nPos++);
                    DescribeAColumn(T, "total", "Importo Apertura", nPos++);
                    DescribeAColumn(T, "reduction", "Storni", nPos++);
                    DescribeAColumn(T, "covered", "Importo Coperto", nPos++);
                    DescribeAColumn(T, "toregularize", "Importo Da Regolarizzare", nPos++);
					DescribeAColumn(T, "tocover", "Importo Da Coprire", nPos++);
                    DescribeAColumn(T, "adate", "Data contabile", nPos++);
                    DescribeAColumn(T, "regularizationnote", "Note", nPos++);
                    DescribeAColumn(T, "treasurer", "Cassiere", nPos++);
					break;
				}
			}
		} 
	}
}
