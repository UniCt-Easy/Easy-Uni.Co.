
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_assetpieceview{
	/// <summary>
	/// Summary description for eventotecnicoview.
	/// </summary>
	public class Meta_assetpieceview : Meta_easydata {
		public Meta_assetpieceview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "assetpieceview") {
			ListingTypes.Add("default");
			ListingTypes.Add("buonoscarico");
			Name = "Cespiti";
		}

		public override bool FilterRow(DataRow R, string list_type) {
			if (list_type=="buonoscarico"){
				if (R["idassetunload"]==DBNull.Value) return false;
				return true;
			}
			return true;
		}

        public override void CalculateFields (System.Data.DataRow R, string listtype) {
            int idPiece = CfgFn.GetNoNullInt32(R["idpiece"]);

            if (idPiece == 1) {
                R["!pieceorasset"] = "C";
            }
            else {
                R["!pieceorasset"] = "A";
            }
        }

		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);

                int nPos = 1;
                DescribeAColumn(T, "idasset", ".idasset", nPos++);
                DescribeAColumn(T, "idpiece", ".idpiece", nPos++);
                DescribeAColumn(T, "ninventory", "Num. inventario", nPos++);
                DescribeAColumn(T, "inventory", "Inventario", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "descriptionmain", ".Desc.Cespite Principale", nPos++);
                DescribeAColumn(T, "nassetacquire", ".Num. carico", nPos++);
                DescribeAColumn(T, "lifestart", ".Data Acquisizione", nPos++);
                DescribeAColumn(T, "yearstart", "Anno esistenza", nPos++);
                DescribeAColumn(T, "currlocationcode", ".Codice ubicazione", nPos++);
                DescribeAColumn(T, "currlocation", ".Ubicazione", nPos++);
                DescribeAColumn(T, "currmanager", ".Responsabile", nPos++);
                DescribeAColumn(T, "codeinv_lev1", "Codice cat.", nPos++);
                DescribeAColumn(T, "inventorytree_lev1", "Categoria", nPos++);
                DescribeAColumn(T, "codeinv", "Codice class.", nPos++);
                DescribeAColumn(T, "inventorytree", "Desc. class", nPos++);
                DescribeAColumn(T, "taxable", ".Imponibile", nPos++);
                DescribeAColumn(T, "taxrate", ".Aliquota IVA", nPos++);
                DescribeAColumn(T, "discount", ".Sconto", nPos++);
				//DescribeAColumn(T, "taxabletotal", "Tot. imp. (IVA incl.)",17);
                DescribeAColumn(T, "total", ".Prezzo acquisto", nPos++);
				DescribeAColumn(T, "abatable",".IVA detraibile",nPos++);
                DescribeAColumn(T, "cost", "Costo iniziale", nPos++);
                DescribeAColumn(T, "revals", "Ammortamenti/Rivalutazioni", nPos++);
                DescribeAColumn(T, "revals_pending", ".Ammortamenti pendenti", nPos++);
                DescribeAColumn(T, "subtractions", "Diminuzioni di val.", nPos++);
                DescribeAColumn(T, "currentvalue", "Valore attuale", nPos++);
				HelpForm.SetFormatForColumn(T.Columns["discount"],"p");
				HelpForm.SetFormatForColumn(T.Columns["taxrate"],"p");
			}
            if (listtype == "buonoscaricoautomatico") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;

                //                Buono di scarico
                //Sistemare l'ordine delle colonne:
                //- Tipo inventario
                // - Inventario
                // - Numero inventario
                //  - Numero parte
                DescribeAColumn(T, "idasset", ".idasset", nPos++);
                DescribeAColumn(T, "idpiece", "Num. parte", nPos++);
                DescribeAColumn(T, "inventorykind", "Tipo inventario", nPos++);
                DescribeAColumn(T, "inventory", "Inventario", nPos++);
                DescribeAColumn(T, "ninventory", "Num. inventario", nPos++);

                DescribeAColumn(T, "description", "Desc. Cespite", nPos++);

                DescribeAColumn(T, "inventorytree", "Classificazione inventariale", nPos++);
                DescribeAColumn(T, "taxable", ".Imponibile", nPos++);
                DescribeAColumn(T, "taxrate", ".Aliquota IVA", nPos++);
                DescribeAColumn(T, "discount", ".Sconto", nPos++);
                DescribeAColumn(T, "total", ".Prezzo acquisto", nPos++);
                DescribeAColumn(T, "abatable", ".IVA detraibile", nPos++);
                DescribeAColumn(T, "cost", ".Costo iniziale", nPos++);
                DescribeAColumn(T, "currentvalue", "Valore ", nPos++);
                ComputeRowsAs(T, listtype);
                HelpForm.SetFormatForColumn(T.Columns["discount"], "p");
                HelpForm.SetFormatForColumn(T.Columns["taxrate"], "p");
                FilterRows(T);
            }
            if (listtype=="buonoscarico") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;

                //                Buono di scarico
                //Sistemare l'ordine delle colonne:
                //- Tipo inventario
                // - Inventario
                // - Numero inventario
                //  - Numero parte

                DescribeAColumn(T, "inventorykind", "Tipo inventario", nPos++);
                DescribeAColumn(T, "inventory", "Inventario", nPos++);
                DescribeAColumn(T, "ninventory", "Num. inventario", nPos++);
                DescribeAColumn(T, "idpiece", "Num. parte", nPos++);
                DescribeAColumn(T, "description", "Desc. Cespite", nPos++);
                //DescribeAColumn(T, "inventorytree", "Descrizione Cespite", nPos++); 
              
                DescribeAColumn(T, "inventorytree", "Classificazione inventariale", nPos++);
                //DescribeAColumn(T, "descriptionmain", "Desc.Cespite Principale", nPos++);
                //DescribeAColumn(T, "lifestart", "Data Acquisizione", nPos++);
                //DescribeAColumn(T, "currlocation", "Ubicazione", nPos++);
                //DescribeAColumn(T, "currmanager", "Responsabile", nPos++);
                //DescribeAColumn(T, "inventorytree", "Desc. class", nPos++);
                DescribeAColumn(T, "taxable", ".Imponibile", nPos++);
                DescribeAColumn(T, "taxrate", ".Aliquota IVA", nPos++);
                DescribeAColumn(T, "discount", ".Sconto", nPos++);
                DescribeAColumn(T, "total", ".Prezzo acquisto", nPos++);
                DescribeAColumn(T, "abatable", ".IVA detraibile", nPos++);
                DescribeAColumn(T, "cost", ".Costo iniziale", nPos++);
                DescribeAColumn(T, "currentvalue", "Valore ", nPos++);
                DescribeAColumn(T, "!pieceorasset", "Cespite/Accessorio", nPos++);
                ComputeRowsAs(T, listtype);
				HelpForm.SetFormatForColumn(T.Columns["discount"],"p");
				HelpForm.SetFormatForColumn(T.Columns["taxrate"],"p");
				FilterRows(T);
			}
		}   
	}
}
