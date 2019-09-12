/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_payrollview{//meta_cedolinoview//
	/// <summary>
	/// Summary description for cedolinoview.
	/// </summary>
	public class Meta_payrollview : Meta_easydata {
		public Meta_payrollview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "payrollview") {
			EditTypes.Add("calcolomultiplo");
			ListingTypes.Add("default");
			ListingTypes.Add("lista");
		}

		protected override Form GetForm(string FormName) {
			switch (FormName) {
				case "calcolomultiplo": {
					Name = "Calcolo Multiplo dei Cedolini";
					DefaultListType = "lista";
					ActAsList();
					return GetFormByDllName("payrollview_calcolomultiplo");
				}
				default: return null;
			}
		}

        private string[] mykey = new string[] { "idpayroll" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			int nPos = 1;
			if (ListingType=="default") {
                //3) numero mandato di pagamento
                //4) numero liquidazione (ultima fase)
				foreach (DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"",-1);
				DescribeAColumn(T,"idpayroll","Id. cedolino", nPos++);
				DescribeAColumn(T,"fiscalyear","Anno Fiscale", nPos++);
				DescribeAColumn(T,"npayroll","Progressivo Anno", nPos++);
                DescribeAColumn(T, "start", "Inizio", nPos++);
                DescribeAColumn(T, "stop", "Fine", nPos++);
                DescribeAColumn(T,"registry","Percipiente", nPos++);
				DescribeAColumn(T,"matricula","Matricola", nPos++);
				DescribeAColumn(T,"ycon","Eserc. Contratto", nPos++);
				DescribeAColumn(T,"ncon","Num. Contratto", nPos++);
                DescribeAColumn(T, "codeser", ".Cod. Prestazione", nPos++);
				DescribeAColumn(T,"service","Prestazione", nPos++);
				DescribeAColumn(T,"ymov_lastphase","Eserc. Pagamento", nPos++);
                DescribeAColumn(T,"nmov_lastphase", "Num. Pagamento", nPos++);
                DescribeAColumn(T, "npay", "Num. Mandato", nPos++);
                DescribeAColumn(T,"workingdays","gg. lavorati", nPos++);
				DescribeAColumn(T,"feegross","Comp. Lordo", nPos++);
				DescribeAColumn(T,"netfee","Comp. Netto", nPos++);
				DescribeAColumn(T,"flagcomputed","completo", nPos++);
				DescribeAColumn(T,"flagbalance","conguaglio", nPos++);
                DescribeAColumn(T, "flagsummarybalance", "riepilogo", nPos++);
                DescribeAColumn(T,"currentrounding","Arrotond.", nPos++);
				DescribeAColumn(T,"enabletaxrelief","Applica Ag.Fiscali", nPos++);
				DescribeAColumn(T,"residencecity","Comune residenza", nPos++);
			}
			
			if (ListingType=="lista") {
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"",-1);
				DescribeAColumn(T, "idpayroll", "Num. Cedolino", nPos++);
				DescribeAColumn(T, "registry", "Percipiente", nPos++);
				DescribeAColumn(T, "ayear", "Eserc. Contratto", nPos++);
				DescribeAColumn(T, "ncon", "Num. Contratto", nPos++);
				DescribeAColumn(T, "fiscalyear", "Anno fiscale", nPos++);
				DescribeAColumn(T, "npayroll", "Progressivo Anno", nPos++);
				DescribeAColumn(T, "feegross", "Comp. Lordo", nPos++);
				DescribeAColumn(T, "netfee","Comp. Netto", nPos++);
				DescribeAColumn(T, "flagbalance", "Conguaglio", nPos++);
				DescribeAColumn(T, "start", "Inizio", nPos++);
				DescribeAColumn(T, "stop", "Fine", nPos++);
				DescribeAColumn(T, "flagcomputed", "Calcolato", nPos++);
				DescribeAColumn(T, "disbursementdate", "Erogazione", nPos++);
			}
		}
	}
}