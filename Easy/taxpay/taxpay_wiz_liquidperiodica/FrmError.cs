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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;

namespace taxpay_wiz_liquidperiodica {
    public partial class FrmError : Form {
        ContextMenu ExcelMenu;
        object taxpaykind;
        public bool IgnoraSegnalazione = false;
        public FrmError(DataTable tErrorLiq, DataTable tErrorFin, object taxpaykind) {
            InitializeComponent();

            this.taxpaykind = taxpaykind;

            tErrorLiq.Columns["nrow"].Caption = "";
            tErrorLiq.Columns["description"].Caption = "Descrizione Errore";

            tErrorFin.Columns["nrow"].Caption = "";
            tErrorFin.Columns["description"].Caption = "Descrizione Errore";

            DataSet dsApp = new DataSet();

            if (tErrorLiq.DataSet == null) {
                dsApp.Tables.Add(tErrorLiq);
            }

            if (tErrorFin.DataSet == null) {
                dsApp.Tables.Add(tErrorFin);
            }

            string modello = (taxpaykind.ToString().ToUpper() == "I")
                ? "F24" : "F24EP";

            string campi = (taxpaykind.ToString().ToUpper() == "I")
                ? "(Codice Ritenuta)" : "(Codice Tributo, Anno Fiscale, Mese Riferimento, Comune (ove presente), Regione Fiscale (ove presente))";

            string msgLiquidazione = "Vengono visualizzati i dettagli precedentemente selezionati che raggruppati secondo " +
                "i seguenti criteri " + campi + " stabiliti dalla legge nella produzione del modello " + modello + 
                " darebbero vita a dei rimborsi, mentre tale modello non li prevede";
            lblLiq.Text = msgLiquidazione;

            string msgFinanziario = "Vengono visualizzati i dettagli precedentemente selezionati che raggruppati secondo " +
                "i seguenti criteri (Codice Bilancio, Codice U.P.B., Responsabile, Ente Percipiente) " +
                " darebbero vita a movimenti di spesa NEGATIVI";
                
            lblFin.Text = msgFinanziario;

            HelpForm.SetDataGrid(dataGrid1, tErrorLiq);
            HelpForm.SetDataGrid(dataGrid2, tErrorFin);

            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));

            dataGrid1.ContextMenu = ExcelMenu;
            dataGrid2.ContextMenu = ExcelMenu;
        }

        private void Excel_Click(object menusender, EventArgs e) {
            if (menusender == null) return;
            if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType()))) return;
            object sender = ((MenuItem)menusender).Parent.GetContextMenu().SourceControl;
            if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType()))) return;
            DataGrid G = (DataGrid)sender;
            object DDS = G.DataSource;
            if (DDS == null) return;
            if (!typeof(DataSet).IsAssignableFrom(DDS.GetType())) return;
            string DDT = G.DataMember;
            if (DDT == null) return;
            DataTable T = ((DataSet)DDS).Tables[DDT];
            if (T == null) return;
            exportclass.DataTableToExcel(T, true);
        }

        private void btnOk_Click(object sender, EventArgs e) {

        }

        private void btnIgnora_Click(object sender, EventArgs e) {
            IgnoraSegnalazione = true;
        }
    }
}