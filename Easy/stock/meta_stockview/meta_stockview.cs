
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.Collections.Generic;
using System.Text;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
namespace meta_stockview
{
    public class Meta_stockview : Meta_easydata{
        public Meta_stockview(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "stockview"){
            EditTypes.Add("default");
            ListingTypes.Add("default");
            ListingTypes.Add("list");
        }
        private string[] mykey = new string[] { "idstock" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default"){
                foreach (DataColumn C in T.Columns){
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "list", "Articolo", nPos++);
                DescribeAColumn(T, "number", "Q.tà Caricata", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                DescribeAColumn(T, "residual", "Giacenza", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["residual"], "n");
                DescribeAColumn(T, "amount", "Costo", nPos++);
                DescribeAColumn(T, "adate", "Data Arrivo", nPos++);
                DescribeAColumn(T, "expiry", "Data scadenza", nPos++);
                DescribeAColumn(T, "store", "Magazzino", nPos++);
                DescribeAColumn(T, "intcode", "Cod.Art.", nPos++);
                DescribeAColumn(T, "storeload_motive", "Causale carico", nPos++);
                DescribeAColumn(T, "yddt_in", "Eserc.Bolla", nPos++);
                DescribeAColumn(T, "nddt_in", "N.Bolla", nPos++);
                DescribeAColumn(T, "mandatekind", "Contratto Passivo", nPos++);
                DescribeAColumn(T, "yman", "Eserc.", nPos++);
                DescribeAColumn(T, "nman", "Num.", nPos++);
                DescribeAColumn(T, "man_idgroup", "Gruppo", nPos++);
                DescribeAColumn(T, "invoicekind", "Tipo documento", nPos++);
                DescribeAColumn(T, "yinv", "Eserc.", nPos++);
                DescribeAColumn(T, "ninv", "Num.", nPos++);
                DescribeAColumn(T, "inv_idgroup", "Gruppo Doc. Iva", nPos++);
                DescribeAColumn(T, "stocklocationcode", "Cod.Ubicazione", nPos++);
                DescribeAColumn(T, "stocklocation", "Ubicazione", nPos++);
            }
            if (ListingType == "invoice") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idstock", ".", nPos++);
                DescribeAColumn(T, "list", "Articolo", nPos++);
                DescribeAColumn(T, "number", "Q.tà Caricata", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                DescribeAColumn(T, "residual", "Giacenza", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["residual"], "n");
                DescribeAColumn(T, "amount", "Costo", nPos++);
                DescribeAColumn(T, "adate", "Data Arrivo", nPos++);
                DescribeAColumn(T, "expiry", "Data scadenza", nPos++);
                DescribeAColumn(T, "store", "Magazzino", nPos++);
                DescribeAColumn(T, "intcode", "Cod.Art.", nPos++);
                DescribeAColumn(T, "yddt_in", "Eserc.Bolla", nPos++);
                DescribeAColumn(T, "nddt_in", "N.Bolla", nPos++);
                DescribeAColumn(T, "mandatekind", "Contratto Passivo", nPos++);
                DescribeAColumn(T, "yman", "Eserc.", nPos++);
                DescribeAColumn(T, "nman", "Num.", nPos++);
                DescribeAColumn(T, "man_idgroup", "Gruppo", nPos++);
                DescribeAColumn(T, "inv_idgroup", "Gruppo Doc. Iva", nPos++);

            }
            //store/quantità (la residua)/unità package/ costo
            if (ListingType == "list") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "store", "Magazzino", nPos++);
                DescribeAColumn(T, "residual", "Giacenza", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["residual"], "n");
                DescribeAColumn(T, "unit", "Unità di misura", nPos++);
                DescribeAColumn(T, "amount", "Costo", nPos++);
            }
            if (ListingType == "dettordine") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idstock", ".", nPos++);
                DescribeAColumn(T, "adate", "Data Arrivo", nPos++);
                DescribeAColumn(T, "number", "Q.tà Caricata", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                DescribeAColumn(T, "residual", "Giacenza", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["residual"], "n");
                DescribeAColumn(T, "expiry", "Data scadenza", nPos++);
                DescribeAColumn(T, "yddt_in", "Eserc.Bolla", nPos++);
                DescribeAColumn(T, "nddt_in", "N.Bolla", nPos++);
            }
        }

    }
}
