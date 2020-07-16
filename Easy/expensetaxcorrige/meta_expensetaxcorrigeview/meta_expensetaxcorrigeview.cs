/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;

namespace meta_expensetaxcorrigeview {
    public class Meta_expensetaxcorrigeview : Meta_easydata {

        public Meta_expensetaxcorrigeview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
			base(Conn, Dispatcher, "expensetaxcorrigeview") {
			Name = "Dettaglio Correzioni";
            ListingTypes.Add("default");
			ListingTypes.Add("liquidazione");
		}

        protected override Form GetForm(string FormName)
        {
            if (FormName == "default")
            {
                DefaultListType = "default";
                Name = "Correzioni Ritenute Applicate";
                return MetaData.GetFormByDllName("expensetaxcorrigeview_default");
            }
            return null;
        }

        private string[] mykey = new string[] { "ayear", "taxcode", "idexp","idexpensetaxcorrige" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override bool CanSelect(DataRow R) {
            if (R.Table.Columns.Contains("ymov")) {
                if (R["ymov"] != DBNull.Value) {
                    if (Convert.ToInt32(R["ymov"]) != Convert.ToInt32(GetSys("esercizio"))) {
                        MessageBox.Show("La riga scelta non appartiene all'esercizio corrente e non può essere selezionata.");
                        return false;
                    }
                }
            }
            return DataAccess.CanSelect(Conn, R);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, ".taxcode", "#", nPos++);
                DescribeAColumn(T, "department", "Dipartimento", nPos++);
                DescribeAColumn(T, "taxref", "Codice", nPos++);
                DescribeAColumn(T, "tax", "Descrizione", nPos++);
                DescribeAColumn(T, "employamount", "Rit. dip.", nPos++);
                DescribeAColumn(T, "adminamount", "Rit. amm.", nPos++);
                DescribeAColumn(T, "expenseadate", "Data Pagamento", nPos++);
                DescribeAColumn(T, "expensedescription", "Descr. Pag.", nPos++);
                DescribeAColumn(T, "descriptionrenumeration", "Descr. Prestazione.", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
                DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
      
                DescribeAColumn(T, "ayear", "Anno di competenza", nPos++);
                DescribeAColumn(T, "adate", "Data Competenza", nPos++);
                DescribeAColumn(T, "ytaxpay", "Eserc. Liquidazione", nPos++);
                DescribeAColumn(T, "ntaxpay", "Num. Liquidazione", nPos++);
                DescribeAColumn(T, "city", "Comune", nPos++);
                DescribeAColumn(T, "fiscaltaxregion", "Regione Fiscale", nPos++);
               }

            if (ListingType == "liquidazione") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, ".taxcode", "#", nPos++);
                DescribeAColumn(T, "department", "Dipartimento", nPos++);
                DescribeAColumn(T, "taxref", "Codice", nPos++);
                DescribeAColumn(T, "tax", "Descrizione", nPos++);
                DescribeAColumn(T, "employamount", "Rit. dip.", nPos++);
                DescribeAColumn(T, "adminamount", "Rit. amm.", nPos++);
                //DescribeAColumn(T, "phasedescription", "Fase Spesa", nPos++);
                DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
                DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
                DescribeAColumn(T, "expensedescription", "Descr. Pag.", nPos++);
                DescribeAColumn(T, "descriptionrenumeration", "Descr. Prestazione.", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
               
                DescribeAColumn(T, "ayear", "Anno di competenza", nPos++);
                DescribeAColumn(T, "adate", "Data Competenza", nPos++);
                DescribeAColumn(T, "city", "Comune", nPos++);
                DescribeAColumn(T, "fiscaltaxregion", "Regione Fiscale", nPos++);
            }
        }

    }
}
