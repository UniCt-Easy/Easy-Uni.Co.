/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;

namespace estimate_default {
    public partial class WizSostituisciDettaglio : Form {
        DataRow rContratto;
        MetaData MetaDettaglio;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        DataTable tOldIvaKind;
        DataTable tNewIvaKind;
        MetaDataDispatcher Disp;
        public DataRow rOldDettaglio;
        double tassoCambio;
        bool inChiusura = false;
        private IMetaModel model ;
        public WizSostituisciDettaglio(DataRow rContratto, DataAccess Conn, MetaDataDispatcher Disp) {
            this.rContratto = rContratto;
            this.Conn = Conn;
            this.Disp = Disp;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            InitializeComponent();
            model= MetaFactory.factory.getSingleton<IMetaModel>();

            DataTable EstimateKind = Conn.RUN_SELECT("estimatekind", "*", null,
                QHS.CmpEq("idestimkind", rContratto["idestimkind"]), null, null, true);
            string linktoinvoice = EstimateKind.Rows[0]["linktoinvoice"].ToString();
            string statfilterivakind="";
            if (linktoinvoice == "N") {
                statfilterivakind = QHS.AppAnd(QHS.NullOrEq("active", "S"), QHS.NullOrEq("rate", 0));
            }

            string filterivakind = "";

            string flagintracom = rContratto["flagintracom"].ToString();

            if (flagintracom == "N") filterivakind = QHS.AppAnd(filterivakind, QHS.BitSet("flag", 6)); //Italia
            if (flagintracom == "S") filterivakind = QHS.AppAnd(filterivakind, QHS.BitSet("flag", 7)); //Intra-UE
            if (flagintracom == "X") filterivakind = QHS.AppAnd(filterivakind, QHS.BitSet("flag", 8)); //Extra-UE

            statfilterivakind = QHS.AppAnd(statfilterivakind, filterivakind);

            if (statfilterivakind != "") statfilterivakind = QHS.DoPar(statfilterivakind);



            tOldIvaKind = DataAccess.CreateTableByName(Conn, "ivakind", "*");
            model.markToAddBlankRow(tOldIvaKind);
            GetData.Add_Blank_Row(tOldIvaKind);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, tOldIvaKind, "description", statfilterivakind, null, true);
            cmbOldTipoIva.DataSource = tOldIvaKind;
            cmbOldTipoIva.DisplayMember = "description";
            cmbOldTipoIva.ValueMember = "idivakind";

            tNewIvaKind = DataAccess.CreateTableByName(Conn, "ivakind", "*");
            model.markToAddBlankRow(tNewIvaKind);
            GetData.Add_Blank_Row(tNewIvaKind);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, tNewIvaKind, "description", statfilterivakind, null, true);
            cmbNewTipoIva.DataSource = tNewIvaKind;
            cmbNewTipoIva.DisplayMember = "description";
            cmbNewTipoIva.ValueMember = "idivakind";

            tassoCambio = CfgFn.GetNoNullDouble(rContratto["exchangerate"]);
        }

        private void btnOK_Click(object sender, EventArgs e) {
            int yestim = CfgFn.GetNoNullInt32(rContratto["yestim"]);
            if (txtStop.Text == "") {
                MessageBox.Show(this, "Inserire la data di annullamento del dettaglio");
                this.DialogResult = DialogResult.None;
                return;
            }
            else {
               
                object date = HelpForm.GetObjectFromString(typeof(DateTime), txtStop.Text, "x.y.g");
                if (date == null) {
                    MessageBox.Show(this, "Inserire la data di annullamento del dettaglio");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                if (((DateTime) date).Year != Conn.GetEsercizio()) {
                    MessageBox.Show(this, "La data di annullamento deve essere dell'esercizio corrente.");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                if (((DateTime) date).Year < yestim) {
                    MessageBox.Show(this, "La data di annullamento deve essere successiva all'anno di creazione del contratto");
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }

            if (txtStart.Text == "") {
                MessageBox.Show(this, "Inserire la data di inizio validit‡ del dettaglio");
                this.DialogResult = DialogResult.None;
                return;
            }
            else {
                object date = HelpForm.GetObjectFromString(typeof(DateTime), txtStart.Text, "x.y.g");
                if (date == null) {
                    MessageBox.Show(this, "Inserire la data di inizio validit‡ del dettaglio");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                if (((DateTime) date).Year != Conn.GetEsercizio()) {
                    MessageBox.Show(this, "La data di inizio validit‡ deve essere dell'esercizio corrente.");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                if (((DateTime) date).Year < yestim) {
                    MessageBox.Show(this, "La data di inizio validit‡ deve essere successiva all'anno di creazione del contratto");
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }

            if (CfgFn.GetNoNullInt32(cmbNewTipoIva.SelectedValue) == 0) {
                MessageBox.Show(this, "Inserire il tipo IVA del nuovo dettaglio");
                this.DialogResult = DialogResult.None;
                return;
            }
            double quantita = CfgFn.GetNoNullDouble(
              HelpForm.GetObjectFromString(typeof(double), txtNewQuantita.Text, "x.y"));
            if (quantita <= 0) {
                MessageBox.Show(this, "Inserire una quantit‡ maggiore di 0 per il nuovo dettaglio");
                this.DialogResult = DialogResult.None;
                return;
            }

            double imponibile = CfgFn.GetNoNullDouble(
                HelpForm.GetObjectFromString(typeof(double), txtNewImportoUnitario.Text, "x.y"));
            if (imponibile <= 0) {
                MessageBox.Show(this, "Inserire un imponibile unitario maggiore di 0 per il  nuovo dettaglio");
                this.DialogResult = DialogResult.None;
                return;
            }

            double sconto = CfgFn.GetNoNullDouble(
              HelpForm.GetObjectFromString(typeof(double), txtNewSconto.Text, "x.y.fixed.4..%.100"));
            if (sconto < 0) {
                MessageBox.Show(this, "Inserire una percentuale di sconto valida per il nuovo dettaglio");
                this.DialogResult = DialogResult.None;
                return;
            }

            if (txtNewDescrizione.Text.Trim() == "") {
                MessageBox.Show(this, "Inserire la descrizione del nuovo dettaglio");
                this.DialogResult = DialogResult.None;
                return;
            }
                
            this.DialogResult = DialogResult.OK;
        }

        private void btnSelect_Click(object sender, EventArgs e) {
            MetaDettaglio = Disp.Get("estimatedetailgroupview");
            MetaDettaglio.FilterLocked = true;
            MetaDettaglio.DS = new DataSet();

            string filter = QHS.AppAnd(QHS.MCmp(rContratto, new string[] { "idestimkind", "yestim", "nestim" })
                , QHS.IsNull("stop"));
            int count = Conn.RUN_SELECT_COUNT("estimatedetailgroupview", filter, true);
            if (count == 0) {
                MessageBox.Show(this, "Nel contratto selezionato non esistono dettagli da annullare", "Avviso",
                 MessageBoxButtons.OK);
                return;
            }
            DataRow rDett = MetaDettaglio.SelectOne("dettaglio", filter, null, null);
            if (rDett == null) {
                MessageBox.Show(this, "Non Ë stata selezionata alcuna riga", "Avviso",
                    MessageBoxButtons.OK);
                return;
            }

            // Valorizzazione degli oggetti:
            HelpForm.SetComboBoxValue(cmbOldTipoIva, rDett["idivakind"]);
            DataRow[] IvaKind = tOldIvaKind.Select(QHC.CmpEq("idivakind", rDett["idivakind"]));
            if (IvaKind.Length > 0) {
                DataRow rIvaKind = IvaKind[0];
                double perc = CfgFn.GetNoNullDouble(rIvaKind["rate"]);

                txtOldAliquota.Text = HelpForm.StringValue(perc, "x.y.fixed.4..%.100");
            }

            double quantita = CfgFn.GetNoNullDouble(rDett["number"]);
            txtOldQuantita.Text = quantita.ToString("n");

            double importoUnitario = CfgFn.GetNoNullDouble(rDett["taxable"]);
            txtOldImportoUnitario.Text = importoUnitario.ToString();

            double sconto = CfgFn.GetNoNullDouble(rDett["discount"]);
            txtOldSconto.Text = sconto.ToString("p");

            double imponibileValuta = CfgFn.RoundValuta((importoUnitario * quantita * (1 - sconto)));
            txtOldImponibileValuta.Text = imponibileValuta.ToString();

            double ivaValuta = CfgFn.GetNoNullDouble(rDett["tax"]);
            txtOldIvaValuta.Text = ivaValuta.ToString();

            decimal imponibileEuro = CfgFn.GetNoNullDecimal(rDett["taxable_euro"]);
            txtOldImponibileEuro.Text = imponibileEuro.ToString("c");

            decimal ivaEuro = CfgFn.GetNoNullDecimal(rDett["iva_euro"]);
            txtOldIvaEuro.Text = ivaEuro.ToString("c");

            txtOldDescrizione.Text = rDett["detaildescription"].ToString();
            txtOldIdGroup.Text = rDett["idgroup"].ToString();

            btnCopy.Enabled = true;
            rOldDettaglio = rDett;
            btnOK.Enabled = true;
        }

        private void btnCopy_Click(object sender, EventArgs e) {
            // Ricopiatura delle informazioni del dettaglio annullato, nel nuovo dettaglio
            if (CfgFn.GetNoNullInt32(cmbOldTipoIva.SelectedValue) != 0) {
                HelpForm.SetComboBoxValue(cmbNewTipoIva, cmbOldTipoIva.SelectedValue);
            }

            txtNewAliquota.Text = txtOldAliquota.Text;
            txtNewQuantita.Text = txtOldQuantita.Text;
            txtNewImportoUnitario.Text = txtOldImportoUnitario.Text;
            txtNewSconto.Text = txtOldSconto.Text;
            txtNewImponibileValuta.Text = txtOldImponibileValuta.Text;
            txtNewIvaValuta.Text = txtOldIvaValuta.Text;
            txtNewImponibileEuro.Text = txtOldImponibileEuro.Text;
            txtNewIvaEuro.Text = txtOldIvaEuro.Text;
            txtNewDescrizione.Text = txtOldDescrizione.Text;
        }

        private void txtStop_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            HelpForm.ExtLeaveDateTimeTextBox(txtStop, null);
            bool dataValida = controllaData(txtStop);
            if (!dataValida) txtStop.Text = "";
        }

        private void txtStart_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            HelpForm.ExtLeaveDateTimeTextBox(txtStart, null);
            bool dataValida = controllaData(txtStart);
            if (!dataValida) txtStart.Text = "";
        }

        private bool controllaData(TextBox txt) {
            try {
                DateTime TT = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime),
                    txt.Text.ToString(), "x.y");
                return true;
            }
            catch {
                return false;
            }
        }

        private void cmbNewTipoIva_SelectedIndexChanged(object sender, EventArgs e) {
            if ((cmbNewTipoIva.SelectedValue != null) && (cmbNewTipoIva.SelectedValue != DBNull.Value)) {
                DataRow[] IvaKind = tNewIvaKind.Select(QHC.CmpEq("idivakind", cmbNewTipoIva.SelectedValue));
                if (IvaKind.Length > 0) {
                    DataRow rIvaKind = IvaKind[0];

                    double perc = CfgFn.GetNoNullDouble(rIvaKind["rate"]);

                    txtNewAliquota.Text = HelpForm.StringValue(perc, "x.y.fixed.4..%.100");
                }
                else {
                    txtNewAliquota.Text = HelpForm.StringValue(0, "x.y.fixed.4..%.100");
                }
            }
            else {
                txtNewAliquota.Text = HelpForm.StringValue(0, "x.y.fixed.4..%.100");
            }
            CalcolaImportiValuta();
            CalcolaImportiEUR();
        }

        private void txtNewQuantita_TextChanged(object sender, EventArgs e) {
            if (inChiusura) return;
            ricalcolaImporti();
        }

        private void txtNewImportoUnitario_TextChanged(object sender, EventArgs e) {
            if (inChiusura) return;
            ricalcolaImporti();
        }

        private void ricalcolaImporti() {
            CalcolaImportiValuta();
            CalcolaImportiEUR();
        }

        private void txtNewSconto_TextChanged(object sender, EventArgs e) {
            if (inChiusura) return;
            ricalcolaImporti();
        }

        private void txtNewIvaValuta_TextChanged(object sender, EventArgs e) {
            if (inChiusura) return;
            CalcolaImportiEUR();
        }

        private void txtNewIvaIndetraibileValuta_TextChanged(object sender, EventArgs e) {
            if (inChiusura) return;
            CalcolaImportiEUR();
        }

        private void txtNewSconto_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            object sconto = HelpForm.GetObjectFromString(typeof(double), txtNewSconto.Text, "x.y.fixed.4..%.100");
            txtNewSconto.Text = HelpForm.StringValue(sconto, "x.y.fixed.4..%.100");
        }

        #region Importi in Valuta
        private void CalcolaImportiValuta() {
            try {
                double imponibile = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewImportoUnitario.Text, "x.y"));

                double quantita = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewQuantita.Text, "x.y"));

                double aliquota = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewAliquota.Text, "x.y.fixed.4..%.100"));

                double sconto = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewSconto.Text, "x.y.fixed.4..%.100"));

                double imponibiletot = CfgFn.RoundValuta((imponibile * quantita * (1 - sconto)));

                double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot * tassoCambio);

                double iva = CfgFn.RoundValuta(imponibiletot * aliquota);

                double ivaEUR = CfgFn.RoundValuta(iva * tassoCambio);

                txtNewImponibileValuta.Text = HelpForm.StringValue(imponibiletot,
                    "x.y.fixed.2...1");
                txtNewIvaValuta.Text = HelpForm.StringValue(iva, "x.y.fixed.2...1");
            }
            catch {
                txtNewImponibileValuta.Text = "";
                txtNewIvaValuta.Text = "";
            }
        }


        #endregion

        #region Importi in Euro
        private void CalcolaImportiEUR() {
            try {

                double imponibile = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewImportoUnitario.Text, "x.y"));

                double quantita = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewQuantita.Text, "x.y"));

                double aliquota = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewAliquota.Text, "x.y.fixed.4..%.100"));

                double sconto = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewSconto.Text, "x.y.fixed.4..%.100"));

                double imponibiletot = CfgFn.RoundValuta((imponibile * quantita * (1 - sconto)));

                double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot * tassoCambio);

                //double iva = CfgFn.RoundValuta(imponibiletot * aliquota);
                double iva = CfgFn.GetNoNullDouble(
                  HelpForm.GetObjectFromString(typeof(double), txtNewIvaValuta.Text, "x.y"));

                double ivaEUR = CfgFn.RoundValuta(iva * tassoCambio);

                txtNewImponibileEuro.Text = HelpForm.StringValue(imponibiletotEUR,
                    "x.y.fixed.2...1");
                txtNewIvaEuro.Text = HelpForm.StringValue(ivaEUR, "x.y.fixed.2...1");
            }
            catch {
                txtNewImponibileEuro.Text = "";
                txtNewIvaEuro.Text = "";
            }

        }
        #endregion

        private void btnNewTipoIva_Click(object sender, EventArgs e) {
            MetaData MetaTipoIva = Disp.Get("ivakind");
            MetaTipoIva.FilterLocked = true;
            MetaTipoIva.ds = new DataSet();

            string filter = QHS.NullOrEq("active", 'S');
            DataRow rTipoIva = MetaTipoIva.SelectOne("default", filter, null, null);
            if (rTipoIva == null) {
                return;
            }
            cmbNewTipoIva.SelectedValue = rTipoIva["idivakind"];
        }
    }
}