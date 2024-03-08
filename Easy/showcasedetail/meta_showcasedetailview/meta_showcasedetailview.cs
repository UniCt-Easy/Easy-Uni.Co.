
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


using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_showcasedetailview
{
    public class Meta_showcasedetailview:Meta_easydata
    {
        public Meta_showcasedetailview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "showcasedetailview")
        {
            ListingTypes.Add("default");
            ListingTypes.Add("elenco");
            Name = "Dettaglio Vetrina";
        }

        private string[] mykey = new string[] { "idshowcase","idlist" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;

                //DescribeAColumn(T, "store", "Magazzino",nPos++);
                DescribeAColumn(T, "intcode", "Codice", nPos++);
                DescribeAColumn(T, "list", "Desc. Articolo", nPos++);
                //DescribeAColumn(T, "number", "Q.tà in Carico", nPos++);
                //DescribeAColumn(T, "booked", "Q.tà prenotata", nPos++);
                DescribeAColumn(T, "listclass", "Class. Merceologica", nPos++);
                DescribeAColumn(T, "tassonomia", "Tassonomia", nPos++);
                DescribeAColumn(T, "codicetassonomia", "Codice Tassonomia", nPos++);

            }
            if (ListingType == "elenco") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;

                //  1 showcase.idstore
                DescribeAColumn(T, "idstore", "Codice Magazzino", nPos++);
                //  2 store.description
                DescribeAColumn(T, "store", "Descrizione Magazzino", nPos++);
                //  3 showcase.title
                DescribeAColumn(T, "title", "Nome Vetrina", nPos++);
                //  4 showcase.description
                DescribeAColumn(T, "description", "Descrizione Vetrina", nPos++);
                //  5 list.description
                DescribeAColumn(T, "list", "Nome Articolo", nPos++);
                //  6 showcasedetail.unitprice
                DescribeAColumn(T, "unitprice", "Prezzo Unitario", nPos++);
                //  7 ivakind.description
                DescribeAColumn(T, "ivakind", "Tipo Iva", nPos++);
                //  8 ivakind.rate * 100
                DescribeAColumn(T, "rate", "Aliquota Iva", nPos++);
                //  9 ivakind.rate * showcasedetail.unitprice
                DescribeAColumn(T, "unitrate", "Iva Unitaria", nPos++);
                // 10 showcasedetail.idupb
                DescribeAColumn(T, "upb", "Upb", nPos++);
                DescribeAColumn(T, "codeupb", "Codice Upb", nPos++);
                // 11 showcasedetail.idupb_iva
                DescribeAColumn(T, "upb_iva", "Upb Iva", nPos++);
                DescribeAColumn(T, "codeupb_iva", "Codice Upb Iva", nPos++);
                // 12 estimatekind.description
                DescribeAColumn(T, "estimkind", "Tipo CA", nPos++);
                // 13 invoicekind.description
                DescribeAColumn(T, "invoicekind", "Tipo Fattura", nPos++);
                // 14 list.intcode
                DescribeAColumn(T, "intcode", "Codice Listino", nPos++);
                // 15 list.description
                DescribeAColumn(T, "listino", "Descrizione Listino", nPos++);
                // 16 listclass.codelistclass
                DescribeAColumn(T, "listclasscode", "Codice classificazione", nPos++);
                // 17 listclass.title
                DescribeAColumn(T, "listclasstitle", "Descrizione classificazione", nPos++);
            }
        }
    }
}
