
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
using metadatalibrary;
using metaeasylibrary;

namespace meta_csa_incomesetupview
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_csa_incomesetupview : Meta_easydata {
		public Meta_csa_incomesetupview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csa_incomesetupview") {		
			Name= "Configurazione automatismi CSA";
			ListingTypes.Add("default");
		}
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idcsa_incomesetup", "Codice ritenuta", nPos++);
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. UPB", nPos++);
                DescribeAColumn(T, "codefin_income", "Capitolo Entrata (Ritenuta)", nPos++);
                DescribeAColumn(T, "fin_income", "Descrizione Capitolo Entrata (Ritenuta)", nPos++);
                DescribeAColumn(T, "codefin_expense", "Capitolo Spesa (Ritenuta)", nPos++);
                DescribeAColumn(T, "fin_expense", "Descrizione Capitolo Spesa (Ritenuta)", nPos++);
                DescribeAColumn(T, "sortcode_income", "Codice Siope Entrata (Ritenuta)", nPos++);
                DescribeAColumn(T, "sorting_income", "Siope Entrata (Ritenuta)", nPos++);
                DescribeAColumn(T, "sortcode_expense", "Codice Siope Spesa (Ritenuta)", nPos++);
                DescribeAColumn(T, "sorting_expense", "Siope Spesa (Ritenuta)", nPos++);
                DescribeAColumn(T, "codeacc_expense", "Conto Debito Vs Ente", nPos++);
                DescribeAColumn(T, "account_expense", "Descrizione Conto Debito Vs Ente", nPos++);
                DescribeAColumn(T, "codeacc_agency_credit", "Conto Credito Vs Ente", nPos++);
                DescribeAColumn(T, "account_agency_credit", "Descrizione Conto Credito Vs Ente", nPos++);
                DescribeAColumn(T, "codefin_clawback", "Capitolo Entrata (Contributo/Recupero)", nPos++);
                DescribeAColumn(T, "fin_clawback", "Capitolo Entrata (Contributo/Recupero)", nPos++);
                DescribeAColumn(T, "sortcode_clawback", "Codice Siope Entrata (Contributo/Recupero)", nPos++);
                DescribeAColumn(T, "sorting_clawback", "Siope Entrata (Contributo/Recupero)", nPos++);
                DescribeAColumn(T, "codefin_cost", "Capitolo Spesa (Recupero)", nPos++);
                DescribeAColumn(T, "fin_cost", "Descrizione Capitolo Spesa (Recupero)", nPos++);
                DescribeAColumn(T, "sortcode_cost", "Codice Capitolo Spesa (Recupero)", nPos++);
                DescribeAColumn(T, "sorting_cost", "Siope Spesa (Recupero)", nPos++);
                DescribeAColumn(T, "codeacc_revenue", "Conto Ricavo (Contributo/Recupero)", nPos++);  
                DescribeAColumn(T, "account_revenue", "Descrizione Conto Ricavo (Contributo/Recupero)", nPos++);  
                DescribeAColumn(T, "codeacc_cost", "Conto Costo (Recupero)", nPos++);   
                DescribeAColumn(T, "account_cost", "Descrizione Conto Costo (Recupero)", nPos++);   
                DescribeAColumn(T, "upb", "UPB", nPos++);
                //DescribeAColumn(T, "codeacc_debit", "Conto Debito", nPos++);                
                //DescribeAColumn(T, "codeacc_internalcredit", "Conto Credito Interno", nPos++);                              
                //DescribeAColumn(T, "sorting_clawback", "Siope recuperi", nPos++);                
      		}
		}
	}
}
