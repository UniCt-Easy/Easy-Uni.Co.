
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
using System.Data;

namespace meta_assetview//meta_beneinventariabileview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_assetview : Meta_easydata
	{
		public Meta_assetview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "assetview") {

			Name= "cespiti inventariabili";
			ListingTypes.Add("default");
			ListingTypes.Add("scaricobeni");
			ListingTypes.Add("dettaglioparte");
            ListingTypes.Add("cespite");
        }
        private string[] mykey = new string[] { "idasset", "idpiece" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "idasset", ".idasset", nPos++);
                DescribeAColumn(T, "idpiece", "N.parte", nPos++);
                DescribeAColumn(T, "inventory", "Inventario", nPos++);
				DescribeAColumn(T, "ninventory", "Num. inventario", nPos++);
				DescribeAColumn(T, "rfid", "Rfid", nPos++); 

				DescribeAColumn(T, "inventoryagency", "Ente inventariale", nPos++);
                DescribeAColumn(T, "nassetacquire", ".Num. carico", nPos++);
                DescribeAColumn(T, "loaddescription", ".Descrizione buono di carico", nPos++);
                DescribeAColumn(T, "ratificationdate", "Data ratifica", nPos++);
                DescribeAColumn(T, "loadmotive", ".Causale carico", nPos++);
                DescribeAColumn(T, "yearstart", "Anno esistenza", nPos++);
                DescribeAColumn(T, "lifestart", "Inizio esistenza", nPos++);
                DescribeAColumn(T, "locationcode", ".Codice ubicazione originale", nPos++);
                DescribeAColumn(T, "location", ".Ubicazione originale", nPos++);

                DescribeAColumn(T, "currlocationcode", ".Codice ubicazione attuale",nPos++);
                DescribeAColumn(T, "currlocation", ".Ubicazione attuale", nPos++);
				DescribeAColumn(T, "currmanager", "Responsabile attuale",nPos++);
                DescribeAColumn(T, "manager", "Responsabile originale", nPos++);
                DescribeAColumn(T, "currsubmanager", ".SubConsegnatario", nPos++);
                DescribeAColumn(T, "codeinv_lev1", "Codice cat.", nPos++);
                DescribeAColumn(T, "inventorytree_lev1", "Categoria", nPos++);
                DescribeAColumn(T, "codeinv", "Codice class.", nPos++);
                DescribeAColumn(T, "inventorytree", "Desc. class", nPos++);
                DescribeAColumn(T, "intcode", "codice listino", nPos++);
                DescribeAColumn(T, "list", "Listino", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "taxable", ".Imponibile", nPos++);
                DescribeAColumn(T, "taxrate", ".Aliquota IVA", nPos++);
                DescribeAColumn(T, "discount", ".Sconto", nPos++);
                DescribeAColumn(T, "total", ".Prezzo acquisto", nPos++);
				DescribeAColumn(T, "abatable",".IVA detraibile",nPos++);
                DescribeAColumn(T, "unabatable", ".IVA indetraibile", nPos++);
                DescribeAColumn(T, "cost", "Costo iniziale", nPos++);
                DescribeAColumn(T, "revals", "Ammortamenti/Rivalutazioni", nPos++);
                DescribeAColumn(T, "revals_pending", ".Ammortamenti pendenti", nPos++);
                DescribeAColumn(T, "subtractions", "Diminuzioni di val.", nPos++);
                DescribeAColumn(T, "currentvalue", "Valore attuale", nPos++);
                DescribeAColumn(T, "yassetload", "Anno carico", nPos++);
                DescribeAColumn(T, "nassetload", "Num. buono carico", nPos++);
				DescribeAColumn(T, "ratificationdate", "Data ratifica", nPos++);
				

				DescribeAColumn(T, "loaddate", ".Data buono carico", nPos++);
                DescribeAColumn(T, "loaddoc", ".Doc. buono carico", nPos++);
                DescribeAColumn(T, "loaddocdate", ".Data doc. buono carico", nPos++);
                DescribeAColumn(T, "loadenactment", ".Provv. buono carico", nPos++);
                DescribeAColumn(T, "loadenactmentdate", ".Data Provv. buono carico", nPos++);
                DescribeAColumn(T, "loadprintdate", ".Data stampa buono carico", nPos++);


                DescribeAColumn(T, "unloaddate", "Data scarico", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
                DescribeAColumn(T, "upb", "U.P.B.", nPos++);                
                DescribeAColumn(T, "yassetunload", "Anno scarico", nPos++);
                DescribeAColumn(T, "nassetunload", "Num. buono scarico", nPos++);
                DescribeAColumn(T, "unloaddescription", ".Descrizione buono di scarico", nPos++);
                DescribeAColumn(T, "unloadmotive", ".Causale scarico", nPos++);
                DescribeAColumn(T, "unloaddoc", ".Doc. scarico", nPos++);
                DescribeAColumn(T, "unloaddocdate", ".Data doc. scarico", nPos++);
                DescribeAColumn(T, "unloadenactment", ".Provv. scarico", nPos++);
                DescribeAColumn(T, "unloadenactmentdate", ".Data Provv. scarico", nPos++);
                DescribeAColumn(T, "unloadratificationdate", "Data ratifica scarico", nPos++);
                DescribeAColumn(T, "unloadregistry", ".Cessionario", nPos++);
                DescribeAColumn(T, "inventory_prev",".Inventario di provenienza", nPos++);
                DescribeAColumn(T, "ninventory_prev",".Num. Inventario di provenienza", nPos++);
                DescribeAColumn(T, "inventory_succ", ".Inventario di destinazione", nPos++);
                DescribeAColumn(T, "ninventory_succ", ".Num. Inventario di destinazione", nPos++);
				
				HelpForm.SetFormatForColumn(T.Columns["discount"],"p");
				HelpForm.SetFormatForColumn(T.Columns["taxrate"],"p");
			}
			if (ListingType=="scaricobeni") {
				foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;

                DescribeAColumn(T, "inventory", "Inventario", nPos++);
                DescribeAColumn(T, "ninventory", "Num. inventario", nPos++);
				//DescribeAColumn(T, "rfid", "Rfid", nPos++);
				DescribeAColumn(T, "nassetacquire", ".Num. carico", nPos++);
                DescribeAColumn(T, "currlocationcode", ".Codice ubicazione", nPos++);
                DescribeAColumn(T, "currlocation", ".Ubicazione", nPos++);
                DescribeAColumn(T, "currmanager", ".Responsabile", nPos++);
                DescribeAColumn(T, "inventorytree", "Desc. class", nPos++);
                DescribeAColumn(T, "list", "Listino", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "taxable", ".Imponibile", nPos++);
                DescribeAColumn(T, "taxrate", ".Aliquota IVA", nPos++);
                DescribeAColumn(T, "discount", ".Sconto", nPos++);
				//DescribeAColumn(T, "taxabletotal", "Tot. imp. (IVA incl.)");
                DescribeAColumn(T, "total", ".Prezzo acquisto", nPos++);
                DescribeAColumn(T, "abatable", ".IVA detraibile", nPos++);
                DescribeAColumn(T, "cost", "Costo iniziale", nPos++);
                DescribeAColumn(T, "currentvalue", "Valore attuale", nPos++);
            }
            if (ListingType == "cespite") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "taxable", ".Imponibile", nPos++);
                DescribeAColumn(T, "taxrate", ".Aliquota IVA", nPos++);
                DescribeAColumn(T, "discount", ".Sconto", nPos++);
                //DescribeAColumn(T, "taxabletotal", "Tot. imp. (IVA incl.)");
                DescribeAColumn(T, "total", ".Prezzo acquisto", nPos++);
                DescribeAColumn(T, "abatable", ".IVA detraibile", nPos++);
                DescribeAColumn(T, "cost", "Costo iniziale", nPos++);
                DescribeAColumn(T, "revals", "Ammortamenti/Rivalutazioni", nPos++);
                DescribeAColumn(T, "revals_pending", ".Ammortamenti pendenti", nPos++);
                DescribeAColumn(T, "subtractions", "Diminuzioni di val.", nPos++);
                DescribeAColumn(T, "currentvalue", "Valore attuale", nPos++);
            }

            if (ListingType=="dettaglioparte") {
				foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;

                DescribeAColumn(T, "inventory", "Inventario", nPos++);
                DescribeAColumn(T, "ninventory", "Num. inventario", nPos++);
				//DescribeAColumn(T, "rfid", "Rfid", nPos++);
				DescribeAColumn(T, "nassetacquire", ".Num. carico", nPos++);
                DescribeAColumn(T, "currlocation", ".Ubicazione", nPos++);
                DescribeAColumn(T, "currmanager", ".Responsabile", nPos++);
                DescribeAColumn(T, "inventorytree", "Desc. class", nPos++);
                DescribeAColumn(T, "list", "Listino", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "taxable", ".Imponibile", nPos++);
                DescribeAColumn(T, "taxrate", ".Aliquota IVA", nPos++);
                DescribeAColumn(T, "discount", ".Sconto", nPos++);
				//DescribeAColumn(T, "taxabletotal", "Tot. imp. (IVA incl.)");
                DescribeAColumn(T, "total", ".Prezzo acquisto", nPos++);
                DescribeAColumn(T, "abatable", ".IVA detraibile", nPos++);
                DescribeAColumn(T, "cost", "Costo iniziale", nPos++);
                DescribeAColumn(T, "currentvalue", "Valore attuale", nPos++);
            }
		}

		public override string GetNoRowFoundMessage(string listingtype) {
			if (listingtype=="dettaglioparte") 
				return "Non esiste alcun cespite con il numero specificato oppure esiste "+
					"ed è stato scaricato.";
			return base.GetNoRowFoundMessage (listingtype);
		}
	}
}
