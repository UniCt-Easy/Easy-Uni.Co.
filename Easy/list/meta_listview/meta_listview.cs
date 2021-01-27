
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
using System.Collections.Generic;
using System.Text;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
namespace meta_listview
{
    public class Meta_listview : Meta_easydata{
        public Meta_listview(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "listview"){
            EditTypes.Add("default");
            ListingTypes.Add("default");
            ListingTypes.Add("webdefault");
            Name = "Listino";
        }


        private string[] mykey = new string[] { "idlist" };
        public override string[] primaryKey() {
            return mykey;
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

                DescribeAColumn(T, "idlist", "#", nPos++);
                DescribeAColumn(T, "intcode", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "unit", "Unità di misura", nPos++);
                DescribeAColumn(T, "package", "Unità di misura per l'acquisto", nPos++);
                DescribeAColumn(T, "unitsforpackage", "Coeff. di Conversione", nPos++);
                DescribeAColumn(T, "validitystop", "Fine Validità", nPos++);
                DescribeAColumn(T, "extcode", "Codice produttore", nPos++);
                DescribeAColumn(T, "codelistclass", "Cod. Class.Mercelogica", nPos++);
                DescribeAColumn(T, "listclass", "Class.Mercelogica", nPos++);
                DescribeAColumn(T, "assetkinddescr", "Tipo Bene (da Class. Merc.)", nPos++);
                DescribeAColumn(T, "codeinv", "Cod. Class. Invent.(da Class. Merc.)", nPos++);
                DescribeAColumn(T, "inventorytree", "Class. Invent.(da Class. Merc.)", nPos++);
                DescribeAColumn(T, "codemotive", "Cod. Causale Costo", nPos++);
                DescribeAColumn(T, "accmotive", "Causale Costo", nPos++);
                DescribeAColumn(T, "has_expiry", "Ha data scadenza", nPos++);
                DescribeAColumn(T, "extbarcode", "Codice a Barre Produttore", nPos++);
                DescribeAColumn(T, "intbarcode", "Codice a Barre interno", nPos++);
                DescribeAColumn(T, "validitystop", "Data scadenza", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
                DescribeAColumn(T, "price","Prezzo unitario", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["price"], "n");
            }

            if (ListingType == "webdefault")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;

                DescribeAColumn(T, "idlist", "#", nPos++);
                DescribeAColumn(T, "intcode", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "unit", "Unità di misura", nPos++);
                DescribeAColumn(T, "package", "Unità di misura per l'acquisto", nPos++);
                DescribeAColumn(T, "unitsforpackage", "Coeff. di Conversione", nPos++);
                DescribeAColumn(T, "listclass", "Class.Mercelogica", nPos++);
            }
        
        }

    }
}
