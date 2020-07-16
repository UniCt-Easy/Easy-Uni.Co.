/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace meta_csa_importver_annualpaymentview
{
	/// <summary>
    /// Summary description for Meta_csa_contractview.
	/// </summary>
	public class Meta_csa_importver_annualpaymentview : Meta_easydata
	{
        public Meta_csa_importver_annualpaymentview (DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "csa_importverview") {
 
            ListingTypes.Add("versamentiannuali");
 
        }
        //string[] mykey = new string[] { "idcsa_import", "idcsa_agency"};
        //public override string[] primaryKey() {
        //    return mykey;
        //}
        public override string GetStaticFilter (string ListingType) {
            string filteresercizio;
            string filtertipo = "";
            filteresercizio = QHS.CmpEq("yimport", GetSys("esercizio"));  
            if ( ListingType == "versamentiannuali" ) {
                return filteresercizio;
            }
            //switch (ListingType) {
            //    case "ritenuta":
            //        filtertipo = QHS.CmpEq("kind", "Ritenuta");
            //        break;
            //    case "contributo":
            //        filtertipo = QHS.CmpEq("kind", "Contributo");
            //        break;
            //    case "recupero":
            //        filtertipo = QHS.CmpEq("kind","Recupero");
            //        break;
            //    case "versamentiannuali":
            //        filtertipo = QHS.CmpEq("kind", "Voce CSA");
            //        break;
            //}

            if (ListingType == "versamentiannuali")   {
                return QHS.AppAnd(filteresercizio);
            }
            
            return base.GetStaticFilter(ListingType);
        }

     
        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "versamentiannuali") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
				//DescribeAColumn(T, "kind", "Tipo", nPos++);
				DescribeAColumn(T, "idcsa_import", "#import", nPos++);
				DescribeAColumn(T, "idreg_agency", "#agency", nPos++);
				DescribeAColumn(T, "yimport", "Eserc. Import.", nPos++);
				DescribeAColumn(T, "nimport", "Num. Import.", nPos++);
				DescribeAColumn(T, "ayear", "Es. Vers.", nPos++);
				//DescribeAColumn(T, "idver", "Num. Vers.", nPos++);
				//DescribeAColumn(T, "ndetail", "Riga", nPos++);
				DescribeAColumn(T, "idreg_agency", ".#cod.Anagr.", nPos++);
				//DescribeAColumn(T, "competenza", "Competenza", nPos++);
				//DescribeAColumn(T, "amount", "Importo", nPos++);
				//DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
				//DescribeAColumn(T, "ruolocsa", "Ruolo CSA", nPos++);
				//DescribeAColumn(T, "capitolocsa", "Capitolo CSA", nPos++);
				//DescribeAColumn(T, "csa_contractkindcode", "Tipo contr.", nPos++);
				//DescribeAColumn(T, "ycontract", "Esercizio Contr.", nPos++);
				//DescribeAColumn(T, "ncontract", "Numero Contr.", nPos++);
				//DescribeAColumn(T, "registry", "Anagrafica", nPos++);
				DescribeAColumn(T, "agency", "Ente Versamento", nPos++);
				DescribeAColumn(T, "registry_agency", "Anagrafica Ente Versamento", nPos++);
				FilterRows(T);
			}
			
		}
	}
}
