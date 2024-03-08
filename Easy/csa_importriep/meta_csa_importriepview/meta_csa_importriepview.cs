
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_csa_importriepview
{
	/// <summary>
    /// Summary description for Meta_csa_contractview.
	/// </summary>
	public class Meta_csa_importriepview : Meta_easydata
	{
        public Meta_csa_importriepview (DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "csa_importriepview") {
            ListingTypes.Add("default");
        }
        string[] mykey = new string[] { "ayear", "idcsa_import","idriep" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetStaticFilter (string ListingType) {
            string filteresercizio;
            if (ListingType == "default") {
                filteresercizio = "(yimport='" + GetSys("esercizio").ToString() + "')";
                return filteresercizio;
            }
            return base.GetStaticFilter(ListingType);
        }

        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "ayear", ".Es. Riep.", nPos++);
                DescribeAColumn(T, "idriep", "Num. Riep.", nPos++);
                DescribeAColumn(T, "yimport", ".Es.Imp.", nPos++);
                DescribeAColumn(T, "nimport", "N.Imp.", nPos++);
                DescribeAColumn(T, "registry", "Anagrafica", nPos++);
                DescribeAColumn(T, "csa_contractkindcode", "Tipo", nPos++);
                DescribeAColumn(T, "ycontract", "Es.contr.", nPos++);
                DescribeAColumn(T, "ncontract", "N.contr.", nPos++);
                DescribeAColumn(T, "importo", "Importo", nPos++);
                DescribeAColumn(T, "title", "Descrizione", nPos++);
                DescribeAColumn(T, "competenza", "Competenza", nPos++);
                DescribeAColumn(T, "ruolocsa", "Ruolo CSA", nPos++);
                DescribeAColumn(T, "capitolocsa", "Capitolo CSA", nPos++);
                DescribeAColumn(T, "codeupb", "UPB", nPos++);
                DescribeAColumn(T, "codefin", "Bilancio", nPos++);
                DescribeAColumn(T, "sortcode", "SIOPE", nPos++);
                DescribeAColumn(T, "codeacc", "Conto E/P", nPos++);
                DescribeAColumn(T, "phase", "Fase Mov. colleg.", nPos++);
                DescribeAColumn(T, "ymov", "Eserc. Mov. colleg.", nPos++);
                DescribeAColumn(T, "nmov", "Num. Mov. colleg.", nPos++);
                DescribeAColumn(T, "underwriting", "Finanziamento", nPos++);
            }
        }
	}
}
