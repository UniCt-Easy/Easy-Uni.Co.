
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
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_accountvardetailview
{
	/// <summary>
	/// Summary description for Meta_accountvardetailview.
	/// </summary>
	public class Meta_accountvardetailview : Meta_easydata {
		public Meta_accountvardetailview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "accountvardetailview") {		
			Name= "Dettaglio variazione di budget";
			ListingTypes.Add("listaestesa");
            ListingTypes.Add("upb");
            ListingTypes.Add("account");
		}

		public override string GetStaticFilter(string ListingType) {
			string filteresercvar;
			if (ListingType=="listaestesa") {
				filteresercvar = QHS.CmpEq("yvar", GetSys("esercizio"));
				return filteresercvar;
			}
			return base.GetStaticFilter (ListingType);
		}

        /// <summary>
        /// Definisce la stringa primaria
        /// </summary>
        string[] mykey = new string[] { "yvar", "nvar", "rownum" };

        /// <summary>
        /// Override di primaryKey
        /// </summary>
        /// <returns></returns>
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType){
 
            object idsorkind1 = DBNull.Value;
            object idsorkind2 = DBNull.Value;
            object idsorkind3 = DBNull.Value;
            DataTable tUniConfig = Conn.RUN_SELECT("config", "*", null, QHS.CmpEq("ayear", GetSys("esercizio")), null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
                DataRow r = tUniConfig.Rows[0];
                idsorkind1 = r["idsortingkind1"];
                idsorkind2 = r["idsortingkind2"];
                idsorkind3 = r["idsortingkind3"];
            }
            string sorkind1 = "";
            string sorkind2 = "";
            string sorkind3 = "";
            if (idsorkind1 != DBNull.Value) {
                sorkind1 = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", idsorkind1), "description").ToString();
            }
            if (idsorkind2 != DBNull.Value) {
                sorkind2 = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", idsorkind2), "description").ToString();
            }
            if (idsorkind3 != DBNull.Value) {
                sorkind3 = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", idsorkind3), "description").ToString();
            }
            if (ListingType=="listaestesa") {
				foreach(DataColumn C in T.Columns){
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
 
				int nPos = 1;
				DescribeAColumn(T, "yvar", "Eserc. variaz.",nPos++);
				DescribeAColumn(T, "nvar", "Num. variaz.",nPos++);
                DescribeAColumn(T, "rownum", "Num. Dettaglio", nPos++);
                DescribeAColumn(T, "variationkinddescr", "Tipo var.", nPos++);
				DescribeAColumn(T, "variationdescription", "Desc. variazione",nPos++);
                DescribeAColumn(T, "enactmentnumber", "Atto Amministrativo",nPos++);
                DescribeAColumn(T, "enactment", "Provvedimento",nPos++);
				DescribeAColumn(T, "nenactment", "Num. provv.",nPos++);
				DescribeAColumn(T, "enactementdate", "Data provv.",nPos++);
				DescribeAColumn(T, "ayear", "Eserc. bil.",nPos++);
				DescribeAColumn(T, "idsorkind", "Codice Tipo Classificazione",nPos++);
				DescribeAColumn(T, "sortcode", "Codice Classificazione",nPos++);
				DescribeAColumn(T, "sorting", "Classificazione",nPos++);
				DescribeAColumn(T, "codeacc", "Codice Conto",nPos++);
				DescribeAColumn(T, "account", "Conto",nPos++);
                DescribeAColumn(T, "codeplaccount", "Cod. Conto Economico", nPos++);
                DescribeAColumn(T, "placcount", "Conto Economico", nPos++);
                DescribeAColumn(T, "codepatrimony", "Cod. Stato Patrimoniale", nPos++);
                DescribeAColumn(T, "patrimony", "Stato Patrimoniale", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
                DescribeAColumn(T, "upb", "U.P.B.", nPos++);
				DescribeAColumn(T, "description", "Descrizione",nPos++);
				DescribeAColumn(T, "title", "Tipo U.P.B.",nPos++);
				DescribeAColumn(T, "amount", "Importo",nPos++);
                int eserc = Convert.ToInt32(GetSys("esercizio"));
                DescribeAColumn(T, "amount2", (++eserc).ToString(), nPos++);
                DescribeAColumn(T, "amount3", (++eserc).ToString(), nPos++);
                DescribeAColumn(T, "amount4", (++eserc).ToString(), nPos++);
                DescribeAColumn(T, "amount5", (++eserc).ToString(), nPos++);
                if (sorkind1 != "") {
                    DescribeAColumn(T, "sortcode1", sorkind1, nPos++);
                }
                if (sorkind2 != "") {
                    DescribeAColumn(T, "sortcode2", sorkind2, nPos++);
                }
                if (sorkind3 != "") {
                    DescribeAColumn(T, "sortcode3", sorkind3, nPos++);
                }
                DescribeAColumn(T, "underwritingkind_desc", "Fonte finanziamento", nPos++);
                DescribeAColumn(T, "costpartitioncode", "Codice Ripartizione", nPos++);
                DescribeAColumn(T, "sortcode_economicbudget", "Codice Budget Economico", nPos++);
                DescribeAColumn(T, "sortcode_investmentbudget", "Codice Budget Investimenti", nPos++);
                
            }
            if (ListingType == "upb") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "variationkinddescr", "Tipo Var.", nPos++);
                DescribeAColumn(T, "nvar", "Num. Prot.", nPos++);
                DescribeAColumn(T, "nofficial", "Num. Var. Uff.", nPos++);
                DescribeAColumn(T, "codeacc", "Conto", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                int eserc= Convert.ToInt32(GetSys("esercizio"));
                DescribeAColumn(T, "amount", eserc.ToString(), nPos++);
                DescribeAColumn(T, "amount2", (++eserc).ToString(), nPos++);
                DescribeAColumn(T, "amount3", (++eserc).ToString(), nPos++);
                DescribeAColumn(T, "amount4", (++eserc).ToString(), nPos++);
                DescribeAColumn(T, "amount5", (++eserc).ToString(), nPos++);
                DescribeAColumn(T, "underwritingkind_desc", "Fonte finanziamento", nPos++);
     
                FilterRows(T);
            }
            if (ListingType == "account") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "variationkinddescr", "Tipo Var.", nPos++);
                DescribeAColumn(T, "nvar", "Num. Prot.", nPos++);
                DescribeAColumn(T, "nofficial", "Num. Var. Uff.", nPos++);
                DescribeAColumn(T, "codeupb", "UPB", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                int eserc = Convert.ToInt32(GetSys("esercizio"));
                DescribeAColumn(T, "amount", eserc.ToString(), nPos++);
                DescribeAColumn(T, "amount2", (++eserc).ToString(), nPos++);
                DescribeAColumn(T, "amount3", (++eserc).ToString(), nPos++);
                DescribeAColumn(T, "amount4", (++eserc).ToString(), nPos++);
                DescribeAColumn(T, "amount5", (++eserc).ToString(), nPos++);
                DescribeAColumn(T, "underwritingkind_desc", "Fonte finanziamento", nPos++);
                FilterRows(T);
   
            }
		}

        
	}
}
