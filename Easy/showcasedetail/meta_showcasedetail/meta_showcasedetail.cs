
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


using funzioni_configurazione;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;

namespace meta_showcasedetail {

    public class Meta_showcasedetail : Meta_easydata {

        public Meta_showcasedetail(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "showcasedetail") {
            ListingTypes.Add("list");
            EditTypes.Add("single");
            Name = "Dettaglio Vetrina";
        }

        protected override Form GetForm(string FormName) {
            DefaultListType = "list";

            if (FormName == "single") {
                return MetaData.GetFormByDllName("showcasedetail_single");
            }

            return null;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (R.IsNull("title")) {
                errmess = "Specificare un nome per l'articolo";
                errfield = "title";
                return false;
            }

            if (R.IsNull("idlist")) {
                errmess = "Specificare un articolo";
                errfield = "idlist";
                return false;
            }

            return true;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "list") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "!intcode", "Codice", "listview.intcode", nPos++);
                DescribeAColumn(T, "title", "Nome articolo", nPos++);
                DescribeAColumn(T, "unitprice", "Prezzo unitario", nPos++);
                DescribeAColumn(T, "!description", "Desc. articolo", "listview.description", nPos++);
                DescribeAColumn(T, "!listclass", "Class. merceologica", "listview.listclass", nPos++);
                DescribeAColumn(T, "!codicetassonomia", "Class. merceologica", "listview.codicetassonomia", nPos++);
                DescribeAColumn(T, "!tassonomia", "Class. merceologica", "listview.tassonomia", nPos++);
                DescribeAColumn(T, "availability", "Disponibilità", nPos++);
                DescribeAColumn(T, "!codeupb", "UPB", "upb.codeupb", nPos++);
                DescribeAColumn(T, "idestimkind", "Tipo contratto attivo", nPos++);
				DescribeAColumn(T, "!codeinvkind", "Tipo fattura", "invoicekind.codeinvkind",  nPos++);
				DescribeAColumn(T, "competencystart", "Inizio Competenza", nPos++);
				DescribeAColumn(T, "competencystop", "Fine Competenza", nPos++);
				DescribeAColumn(T, "!codeupb_iva", "UPB IVA", "upb_iva.codeupb", nPos++);
			}
        }

    }

}
