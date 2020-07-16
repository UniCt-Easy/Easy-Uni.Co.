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
                DescribeAColumn(T, "codeacc_debit", "Conto Debito", nPos++);
                DescribeAColumn(T, "codeacc_ente", "Conto Debito Vs Ente", nPos++);
                DescribeAColumn(T, "codeacc_credit_agency", "Conto Credito Vs Ente", nPos++);
                DescribeAColumn(T, "codeacc_internalcredit", "Conto Credito Interno", nPos++);
                DescribeAColumn(T, "codeacc_revenue", "Conto Ricavo per Recuperi", nPos++);
                DescribeAColumn(T, "codefin_income", "Denom. bil. Entrata", nPos++);
                DescribeAColumn(T, "codefin_expense", "Voce bil. Spesa", nPos++);
                DescribeAColumn(T, "codefin_clawback", "Denom. bil. recuperi", nPos++);
                DescribeAColumn(T, "sorting_income", "Siope Entrata", nPos++);
                DescribeAColumn(T, "sorting_expense", "Siope Spesa", nPos++);
                DescribeAColumn(T, "sorting_clawback", "Siope recuperi", nPos++);

      			}
		}
	}
}
