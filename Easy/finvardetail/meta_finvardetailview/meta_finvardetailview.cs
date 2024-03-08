
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
using funzioni_configurazione;

namespace meta_finvardetailview//meta_dettvarbilancioview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_finvardetailview : Meta_easydata {
		public Meta_finvardetailview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "finvardetailview") {		
			Name= "Dettaglio variazione di bilancio";
			ListingTypes.Add("listaestesa");
            ListingTypes.Add("bilancio");
            ListingTypes.Add("upb");
            ListingTypes.Add("underwriting");
		}

		public override string GetStaticFilter(string ListingType)
		{
			string filteresercvar;
			if (ListingType=="listaestesa")	
			{
				filteresercvar = "(yvar='"+GetSys("esercizio").ToString()+"')";
				return filteresercvar;
			}
			return base.GetStaticFilter (ListingType);
		}
        private string[] mykey = new string[] { "yvar", "nvar","rownum" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="listaestesa") {
				foreach(DataColumn C in T.Columns){
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
                int nPos = 1;
                DescribeAColumn(T, "yvar", "Eserc. variaz.", nPos++);
                DescribeAColumn(T, "nvar", "Num. variaz.", nPos++);
                DescribeAColumn(T, "variationkinddescr", "Tipo var.", nPos++);
                DescribeAColumn(T, "variationdescription", "Desc. variazione", nPos++);
                DescribeAColumn(T, "enactment", "Provvedimento", nPos++);
                DescribeAColumn(T, "nenactment", "Num. provv.", nPos++);
                DescribeAColumn(T, "enactementdate", "Data provv.", nPos++);
                DescribeAColumn(T, "previsionkind", "Tipo prev.", nPos++);
                DescribeAColumn(T, "idfin", "", nPos++);
                DescribeAColumn(T, "ayear", "Eserc. bil.", nPos++);
                DescribeAColumn(T, "finpart", "Parte bil.", nPos++);
                DescribeAColumn(T, "codefin", "Voce bil.", nPos++);
                DescribeAColumn(T, "finance", "Denom. bil.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "codeupb", "Codice UPB", nPos++);
                DescribeAColumn(T, "upb", "Denom. UPB.", nPos++);
                DescribeAColumn(T, "underwriting", "Finanziamento", nPos++);
                DescribeAColumn(T, "flagproceeds", "Var.dotaz.cassa", nPos++);
                DescribeAColumn(T, "flagcredit", "Var.dotaz.crediti", nPos++);
                DescribeAColumn(T, "flagprevision", "Prev. princ.", nPos++);
                DescribeAColumn(T, "flagsecondaryprev", "Prev. second.", nPos++);
			    object fase1 = Conn.DO_READ_VALUE("expensephase", "nphase=1", "description").ToString();
                DescribeAColumn(T, "createexpense", "Richiedi " + fase1, nPos++); 
                DescribeAColumn(T, "nmov", "N."+fase1, nPos++);
                DescribeAColumn(T, "activity", "Tipo Attività", nPos++);
                DescribeAColumn(T, "kindd", "Didattica", nPos++);
                DescribeAColumn(T, "kindr", "Ricerca", nPos++);
    		}
            if (ListingType == "bilancio") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "variationkinddescr", "Tipo Var.", nPos++);
                DescribeAColumn(T, "nvar", "Num. Prot.", nPos++);
                DescribeAColumn(T, "nofficial", "Num. Var. Uff.", nPos++);
                DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                DescribeAColumn(T, "underwriting", "Finanziamento", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                if (CfgFn.NomePrevisionePrincipale(Conn) != null)
                    DescribeAColumn(T, "!prev_competenza", "Prev. " + CfgFn.NomePrevisionePrincipale(Conn), nPos++);
                if (CfgFn.NomePrevisioneSecondaria(Conn) != null)
                    DescribeAColumn(T, "!prev_cassa", "Prev. " + CfgFn.NomePrevisioneSecondaria(Conn), nPos++);
                DescribeAColumn(T, "!crediti", "Dot. Crediti", nPos++);
                DescribeAColumn(T, "!cassa", "Dot.Cassa", nPos++);
                ComputeRowsAs(T, ListingType);
                FilterRows(T);
            }
            if (ListingType == "underwriting") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "nvar", "Num. Prot.", nPos++);
                DescribeAColumn(T, "finvarstatus", "Stato", nPos++);
                DescribeAColumn(T, "codefin", "Voce di bilancio", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "!entrata", "Entrata", nPos++);
                DescribeAColumn(T, "!spesa", "Spesa", nPos++);
                DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                DescribeAColumn(T, "underwriting", "Finanziamento", nPos++);
                ComputeRowsAs(T, ListingType);
            }
            if (ListingType == "upb") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "variationkinddescr", "Tipo Var.", nPos++);
                DescribeAColumn(T, "nvar", "Num. Prot.", nPos++);
                DescribeAColumn(T, "nofficial", "Num. Var. Uff.",  nPos++);
                DescribeAColumn(T, "finpart", "E/S", nPos++);
                DescribeAColumn(T, "codefin", "Voce di bilancio", nPos++);
                DescribeAColumn(T, "underwriting", "Finanziamento", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                if (CfgFn.NomePrevisionePrincipale(Conn) != null)
                    DescribeAColumn(T, "!prev_competenza", "Prev. " + CfgFn.NomePrevisionePrincipale(Conn), nPos++);
                if (CfgFn.NomePrevisioneSecondaria(Conn) != null)
                    DescribeAColumn(T, "!prev_cassa", "Prev. " + CfgFn.NomePrevisioneSecondaria(Conn), nPos++);
                DescribeAColumn(T, "!crediti", "Dot. Crediti", nPos++);
                DescribeAColumn(T, "!cassa", "Dot.Cassa", nPos++);
                ComputeRowsAs(T, ListingType);
                FilterRows(T);
            }
		}


        public override void CalculateFields(System.Data.DataRow R, string listtype) {
            if ((listtype == "bilancio") || (listtype == "upb")) {
                if (R["flagPrevision"].ToString() == "S") R["!prev_competenza"] = R["amount"];
                if (R["flagSecondaryPrev"].ToString() == "S") R["!prev_cassa"] = R["amount"];
                if (R["flagCredit"].ToString() == "S") R["!crediti"] = R["amount"];
                if (R["flagProceeds"].ToString() == "S") R["!cassa"] = R["amount"];
            }
            if (listtype == "underwriting") {
                if (R["finpart"].ToString() == "S") {
                    R["!spesa"] = R["amount"];
                }
                else {
                    R["!entrata"] = R["amount"];
                }
            }
        }
		

	}
}
