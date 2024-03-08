
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


using funzioni_configurazione;
using metadatalibrary;
using metaeasylibrary;
using System;
using System.Data;
using System.Windows.Forms;

namespace meta_showcasedetail_related {

    public class Meta_showcasedetail_related : Meta_easydata {

        public Meta_showcasedetail_related(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "showcasedetail_related") {
            ListingTypes.Add("list");
            EditTypes.Add("single");
            EditTypes.Add("default");
            Name = "Dettaglio Vetrina";
        }

        protected override Form GetForm(string FormName) {
            DefaultListType = "list";

            if (FormName == "single" || FormName == "default") {
                return MetaData.GetFormByDllName("showcasedetail_related_single");
            }

            return null;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            RowChange.SetSelector(T, "idshowcase");
            RowChange.SetSelector(T, "idlist");
            RowChange.MarkAsAutoincrement(T.Columns["rownum"], null, null, 6);
            RowChange.setMinimumTempValue(T.Columns["rownum"], 10000);
            int idlist_related = Convert.ToInt32(ParentRow["idlist"]);
            SetDefault(T, "idlist_related", idlist_related);

            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
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
                DescribeAColumn(T, "!intcode", "Codice listino", "listview_related.intcode", nPos++);
                DescribeAColumn(T, "!description", "Descr. listino", "listview_related.description", nPos++);
                DescribeAColumn(T, "title", "Nome articolo", nPos++);
                DescribeAColumn(T, "unitprice", "Prezzo unitario", nPos++);
                DescribeAColumn(T, "availability", "Disponibilità", nPos++);
                DescribeAColumn(T, "competencystart", "Inizio Competenza", nPos++);
                DescribeAColumn(T, "competencystop", "Fine Competenza", nPos++);
                DescribeAColumn(T, "!listclass", "Class. merceologica", "listview_related.listclass", nPos++);
                DescribeAColumn(T, "!codicetassonomia", "Codice Tassonomia", "listview_related.codicetassonomia", nPos++);
                DescribeAColumn(T, "!tassonomia", "Tassonomia", "listview_related.tassonomia", nPos++);
                DescribeAColumn(T, "!codeupb", "UPB", "upb1.codeupb", nPos++);
                DescribeAColumn(T, "!codeupb_iva", "UPB IVA", "upb_iva1.codeupb", nPos++);

            }
        }

    }

}
