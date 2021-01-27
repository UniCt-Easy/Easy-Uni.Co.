
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
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_budgetvardetailview 
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_budgetvardetailview : Meta_easydata {
		public Meta_budgetvardetailview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "budgetvardetailview") {		
			Name= "Dettaglio variazione di budget classificazione";
			ListingTypes.Add("listaestesa");
            ListingTypes.Add("classificazione");
            ListingTypes.Add("upb");
     
		}

		public override string GetStaticFilter(string ListingType)
		{
			string filteresercvar;
			if (ListingType=="listaestesa")	
			{
				filteresercvar = "(ybudgetvar='"+GetSys("esercizio").ToString()+"')";
				return filteresercvar;
			}
			return base.GetStaticFilter (ListingType);
		}

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
            if (ListingType == "listaestesa")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "ybudgetvar", "Eserc. variaz.", nPos++);
                DescribeAColumn(T, "nbudgetvar", "Num. variaz.", nPos++);
                DescribeAColumn(T, "variationdescription", "Desc. variazione", nPos++);
                DescribeAColumn(T, "sortcode", "Cod. Voce Class.", nPos++);
                DescribeAColumn(T, "sorting", "Voce Class.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "codeupb", "Codice UPB", nPos++);
                DescribeAColumn(T, "upb", "Denom. UPB.", nPos++);
            }
          
            //if (ListingType == "upb") {
            //    foreach (DataColumn C in T.Columns) {
            //        DescribeAColumn(T, C.ColumnName, "", -1);
            //    }
            //    int nPos = 1;
            //    DescribeAColumn(T, "variationkinddescr", "Tipo Var.", nPos++);
            //    DescribeAColumn(T, "nvar", "Num. Prot.", nPos++);
            //    DescribeAColumn(T, "nofficial", "Num. Var. Uff.",  nPos++);
            //    DescribeAColumn(T, "finpart", "E/S", nPos++);
            //    DescribeAColumn(T, "codefin", "Voce di bilancio", nPos++);
            //    DescribeAColumn(T, "underwriting", "Finanziamento", nPos++);
            //    DescribeAColumn(T, "description", "Descrizione", nPos++);
            //    if (CfgFn.NomePrevisionePrincipale(Conn) != null)
            //        DescribeAColumn(T, "!prev_competenza", "Prev. " + CfgFn.NomePrevisionePrincipale(Conn), nPos++);
            //    if (CfgFn.NomePrevisioneSecondaria(Conn) != null)
            //        DescribeAColumn(T, "!prev_cassa", "Prev. " + CfgFn.NomePrevisioneSecondaria(Conn), nPos++);
            //    DescribeAColumn(T, "!crediti", "Dot. Crediti", nPos++);
            //    DescribeAColumn(T, "!cassa", "Dot.Cassa", nPos++);
               
            //}

            if (ListingType == "classificazione")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
              
                DescribeAColumn(T, "nbudgetvar", "Num. Prot.", nPos++);
                DescribeAColumn(T, "nofficial", "Num. Var. Uff.", nPos++);
                DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
            }
		}


    

	}
}
