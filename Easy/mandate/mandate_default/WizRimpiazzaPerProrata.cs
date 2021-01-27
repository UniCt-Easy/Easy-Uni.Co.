
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace mandate_default {
    public partial class WizRimpiazzaPerProrata : Form {
        DataRow rContratto;
        MetaData MetaDettaglio;
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        DataTable tOldIvaKind;
        DataTable tNewIvaKind;
        DataTable tOldUnitaMisuraAcquisto;
        DataTable tNewUnitaMisuraAcquisto;
        DataTable tOldUnitaMisuraCS;
        DataTable tNewUnitaMisuraCS;
        MetaDataDispatcher Disp;
        public int flagActivityValue = 0;
        public DataRow rOldDettaglio;
        public DataRow rListChosen;
        double tassoCambio;
        bool inChiusura = false;
        public WizRimpiazzaPerProrata(DataRow rContratto, DataAccess Conn, MetaDataDispatcher Disp) {
            this.rContratto = rContratto;
            this.Conn = Conn;
            this.Disp = Disp;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            InitializeComponent();
            tOldIvaKind = DataAccess.CreateTableByName(Conn, "ivakind", "*");
            GetData.MarkToAddBlankRow(tOldIvaKind);
            GetData.Add_Blank_Row(tOldIvaKind);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, tOldIvaKind, "description",null, null, true);
            cmbOldTipoIva.DataSource = tOldIvaKind;
            cmbOldTipoIva.DisplayMember = "description";
            cmbOldTipoIva.ValueMember = "idivakind";

            tNewIvaKind = DataAccess.CreateTableByName(Conn, "ivakind", "*");
            GetData.MarkToAddBlankRow(tNewIvaKind);
            GetData.Add_Blank_Row(tNewIvaKind);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, tNewIvaKind, "description", QHS.NullOrEq("active", "S"), null, true);
            cmbNewTipoIva.DataSource = tNewIvaKind;
            cmbNewTipoIva.DisplayMember = "description";
            cmbNewTipoIva.ValueMember = "idivakind";

            tOldUnitaMisuraAcquisto = DataAccess.CreateTableByName(Conn, "package", "*");
            GetData.MarkToAddBlankRow(tOldUnitaMisuraAcquisto);
            GetData.Add_Blank_Row(tOldUnitaMisuraAcquisto);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, tOldUnitaMisuraAcquisto, "description", null, null, true);
            cmbOldUnitaMisuraAcquisto.DataSource = tOldUnitaMisuraAcquisto;
            cmbOldUnitaMisuraAcquisto.DisplayMember = "description";
            cmbOldUnitaMisuraAcquisto.ValueMember = "idpackage";

            tNewUnitaMisuraAcquisto = DataAccess.CreateTableByName(Conn, "package", "*");
            GetData.MarkToAddBlankRow(tNewUnitaMisuraAcquisto);
            GetData.Add_Blank_Row(tNewUnitaMisuraAcquisto);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, tNewUnitaMisuraAcquisto, "description", null, null, true);
            cmbNewUnitaMisuraAcquisto.DataSource = tNewUnitaMisuraAcquisto;
            cmbNewUnitaMisuraAcquisto.DisplayMember = "description";
            cmbNewUnitaMisuraAcquisto.ValueMember = "idpackage";

            tOldUnitaMisuraCS = DataAccess.CreateTableByName(Conn, "unit", "*");
            GetData.MarkToAddBlankRow(tOldUnitaMisuraCS);
            GetData.Add_Blank_Row(tOldUnitaMisuraCS);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, tOldUnitaMisuraCS, "description", null, null, true);
            cmbOldUnitaMisuraCS.DataSource = tOldUnitaMisuraCS;
            cmbOldUnitaMisuraCS.DisplayMember = "description";
            cmbOldUnitaMisuraCS.ValueMember = "idunit";

            tNewUnitaMisuraCS = DataAccess.CreateTableByName(Conn, "unit", "*");
            GetData.MarkToAddBlankRow(tNewUnitaMisuraCS);
            GetData.Add_Blank_Row(tNewUnitaMisuraCS);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, tNewUnitaMisuraCS, "description", null, null, true);
            cmbNewUnitaMisuraCS.DataSource = tNewUnitaMisuraCS;
            cmbNewUnitaMisuraCS.DisplayMember = "description";
            cmbNewUnitaMisuraCS.ValueMember = "idunit";


            tassoCambio = CfgFn.GetNoNullDouble(rContratto["exchangerate"]);
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (txtStop.Text == "") {
                MessageBox.Show(this, "Inserire la data di annullamento del dettaglio");
                this.DialogResult = DialogResult.None;
                return;
            }

            if (txtStart.Text == "") {
                MessageBox.Show(this, "Inserire la data di inizio validità del dettaglio");
                this.DialogResult = DialogResult.None;
                return;
            }

             if (CfgFn.GetNoNullInt32(cmbNewTipoIva.SelectedValue) == 0){
                MessageBox.Show(this, "Inserire il tipo IVA del nuovo dettaglio");
                this.DialogResult = DialogResult.None;
                return;
            }

            double quantitaconfezioni = CfgFn.GetNoNullDouble(
                HelpForm.GetObjectFromString(typeof(double), txtNewQuantitaConfezioni.Text, "x.y"));
            if (quantitaconfezioni <= 0){
                MessageBox.Show(this, "Inserire una quantità maggiore di 0 per il nuovo dettaglio");
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

            if (txtNewDescrizione.Text.Trim()== "") {
                MessageBox.Show(this, "Inserire la descrizione del nuovo dettaglio");
                this.DialogResult = DialogResult.None;
                return;
            }

        
            this.DialogResult = DialogResult.OK;
        }

        private void btnSelect_Click(object sender, EventArgs e) {
            MetaDettaglio = Disp.Get("mandatedetailgroupview");
            MetaDettaglio.FilterLocked = true;
            MetaDettaglio.DS = new DataSet();

            string filter = QHS.AppAnd(QHS.MCmp(rContratto, new string[] { "idmankind", "yman", "nman" })
                , QHS.IsNull("stop"), QHS.CmpNe("flagactivity",1),QHS.NullOrNe("epkind","F"));
            string filterNoInvoice = " ( SELECT COUNT (*)  " +
                 " FROM invoicedetailgroupview ID  " +
                 " WHERE mandatedetailgroupview.idmankind = ID.idmankind " +
                 " AND mandatedetailgroupview.yman = ID.yman " +
                 " AND mandatedetailgroupview.nman = ID.nman " +
                 " AND mandatedetailgroupview.idgroup = ID.manidgroup " +
                 " ) = 0 ";

            filter = QHS.AppAnd(filter, filterNoInvoice);
            int count = Conn.RUN_SELECT_COUNT("mandatedetailgroupview", filter, true);
            if (count == 0) {
                MessageBox.Show(this, "Nel contratto selezionato non esistono dettagli da annullare, potrebbero essere stati parzialmente fatturati", "Avviso",
                 MessageBoxButtons.OK);
                return;
            }
            DataRow rDett = MetaDettaglio.SelectOne("dettaglio", filter, null, null);
            if (rDett == null) {
                MessageBox.Show(this, "Non è stata selezionata alcuna riga", "Avviso",
                    MessageBoxButtons.OK);
                return;
            }

            // Valorizzazione degli oggetti:

            HelpForm.SetComboBoxValue(cmbOldTipoIva, rDett["idivakind"]);
            DataRow [] IvaKind = tOldIvaKind.Select(QHC.CmpEq("idivakind", rDett["idivakind"]));
            if (IvaKind.Length > 0) {
                DataRow rIvaKind = IvaKind[0];
                double perc = CfgFn.GetNoNullDouble(rIvaKind["rate"]);
                double percIndet = CfgFn.GetNoNullDouble(rIvaKind["unabatabilitypercentage"]);

                txtOldAliquota.Text = HelpForm.StringValue(perc, "x.y.fixed.4..%.100");
                txtOldPercIndet.Text = HelpForm.StringValue(percIndet, "x.y.fixed.4..%.100");
            }
            if (rDett["idlist"] != DBNull.Value ){
                string intcode = Conn.DO_READ_VALUE("list", QHC.CmpEq("idlist", rDett["idlist"]), "intcode").ToString();
                txtOldListino.Text = intcode;

                string list = Conn.DO_READ_VALUE("list", QHC.CmpEq("idlist", rDett["idlist"]), "description").ToString();
                txtOldDescrizioneListino.Text = list;

                HelpForm.SetComboBoxValue(cmbOldUnitaMisuraAcquisto, rDett["idpackage"]);

                int CoeffConversione = CfgFn.GetNoNullInt32(rDett["unitsforpackage"]);
                txtOldCoeffConversione.Text = CoeffConversione.ToString("n");

                HelpForm.SetComboBoxValue(cmbOldUnitaMisuraCS, rDett["idunit"]);
            }

            double quantitaconfezioni = CfgFn.GetNoNullDouble(rDett["npackage"]);
            txtOldQuantitaConfezioni.Text = quantitaconfezioni.ToString("n");

            double quantita = CfgFn.GetNoNullDouble(rDett["number"]);
            txtOldQuantita.Text = quantita.ToString("n");

            double importoUnitario = CfgFn.GetNoNullDouble(rDett["taxable"]);
            txtOldImportoUnitario.Text = importoUnitario.ToString();

            double sconto = CfgFn.GetNoNullDouble(rDett["discount"]);
            txtOldSconto.Text = sconto.ToString("p");

            double imponibileValuta = CfgFn.RoundValuta((importoUnitario * quantitaconfezioni * (1 - sconto)));
            txtOldImponibileValuta.Text = imponibileValuta.ToString();

            double ivaEuro = CfgFn.GetNoNullDouble(rDett["tax"]);
            txtOldIvaEuro.Text = ivaEuro.ToString("c");

            double ivaIndetraibileEuro = CfgFn.GetNoNullDouble(rDett["unabatable"]);
            txtOldIvaIndetraibileEuro.Text = ivaIndetraibileEuro.ToString("c");

            decimal imponibileEuro = CfgFn.GetNoNullDecimal(rDett["taxable_euro"]);
            txtOldImponibileEuro.Text = imponibileEuro.ToString("c");


            chkOldPromiscuo.Checked = (rDett["flagmixed"].ToString().ToUpper() == "S");

            int flagActivity = CfgFn.GetNoNullInt32(rDett["flagactivity"]);
            rdoOldAttivita1.Checked = (flagActivity == 1);
            rdoOldAttivita2.Checked = (flagActivity == 2);
            rdoOldAttivita3.Checked = (flagActivity == 3);
            rdoOldAttivita4.Checked = (flagActivity == 4);

            txtOldDescrizione.Text = rDett["detaildescription"].ToString();
            txtOldIdGroup.Text = rDett["idgroup"].ToString();
            btnCopy.Enabled = true;
            rOldDettaglio = rDett;
            btnOK.Enabled = true;

            btnCopy_Click(sender, e);
            grpBoxListinoNuovo.Enabled = false;
            txtNewQuantitaConfezioni.Enabled = false;
            grpBoxTipoivaNuovo.Enabled = false;
            grpValoreUnitInValuta.Enabled = false;
            grpBoxAttivitaNuovo.Enabled = false;
            grpBoxValoreTotaleNuovo.Enabled = false;
            chkNewPromiscuo.Enabled = false;
            }

        private void btnCopy_Click(object sender, EventArgs e) {
            // Ricopiatura delle informazioni del dettaglio annullato, nel nuovo dettaglio
            if (CfgFn.GetNoNullInt32(cmbOldTipoIva.SelectedValue) != 0) {
                HelpForm.SetComboBoxValue(cmbNewTipoIva, cmbOldTipoIva.SelectedValue);
            }

            if (CfgFn.GetNoNullInt32(cmbOldUnitaMisuraAcquisto.SelectedValue) != 0){
                HelpForm.SetComboBoxValue(cmbNewUnitaMisuraAcquisto, cmbOldUnitaMisuraAcquisto.SelectedValue);
            }

            if (CfgFn.GetNoNullInt32(cmbOldUnitaMisuraCS.SelectedValue) != 0){
                HelpForm.SetComboBoxValue(cmbNewUnitaMisuraCS, cmbOldUnitaMisuraCS.SelectedValue);
            }
            txtNewCoeffConversione.Text = txtOldCoeffConversione.Text;

            txtNewAliquota.Text = txtOldAliquota.Text;
            txtNewPercIndet.Text = txtOldPercIndet.Text;
            txtNewQuantitaConfezioni.Text = txtOldQuantitaConfezioni.Text;
            txtNewQuantita.Text = txtOldQuantita.Text;
            txtNewImportoUnitario.Text = txtOldImportoUnitario.Text;
            txtNewSconto.Text = txtOldSconto.Text;
            txtNewImponibileValuta.Text = txtOldImponibileValuta.Text;
            txtNewImponibileEuro.Text = txtOldImponibileEuro.Text;
            txtNewIvaEuro.Text = txtOldIvaEuro.Text;
            txtNewIvaIndetraibileEuro.Text = txtOldIvaIndetraibileEuro.Text;
            chkNewPromiscuo.Checked = chkOldPromiscuo.Checked;
            rdoNewAttivita1.Checked = rdoOldAttivita1.Checked;
            rdoNewAttivita2.Checked = rdoOldAttivita2.Checked;
            rdoNewAttivita3.Checked = rdoOldAttivita3.Checked;
            rdoNewAttivita4.Checked = rdoOldAttivita4.Checked;
            txtNewDescrizione.Text = txtOldDescrizione.Text;

            txtNewCoeffConversione.Text = txtOldCoeffConversione.Text;
            txNewListino.Text = txtOldListino.Text;
            txtNewDescrizioneListino.Text = txtOldDescrizioneListino.Text;
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
            if ((cmbNewTipoIva.SelectedValue != null) && (cmbNewTipoIva.SelectedValue != DBNull.Value)){
                DataRow[] IvaKind = tNewIvaKind.Select(QHC.CmpEq("idivakind", cmbNewTipoIva.SelectedValue));
                if (IvaKind.Length > 0) {
                    DataRow rIvaKind = IvaKind[0];

                    double perc = CfgFn.GetNoNullDouble(rIvaKind["rate"]);
                    double percIndet = CfgFn.GetNoNullDouble(rIvaKind["unabatabilitypercentage"]);

                    txtNewAliquota.Text = HelpForm.StringValue(perc, "x.y.fixed.4..%.100");
                    txtNewPercIndet.Text = HelpForm.StringValue(percIndet, "x.y.fixed.4..%.100");
                }
                else {
                    txtNewAliquota.Text = HelpForm.StringValue(0, "x.y.fixed.4..%.100");
                    txtNewPercIndet.Text = HelpForm.StringValue(0, "x.y.fixed.4..%.100");
                }
            }
            else {
                txtNewAliquota.Text = HelpForm.StringValue(0, "x.y.fixed.4..%.100");
                txtNewPercIndet.Text = HelpForm.StringValue(0, "x.y.fixed.4..%.100");
            }
            CalcolaImportiValuta();
            CalcolaImportiEUR();
        }

        //private void txtNewQuantita_TextChanged(object sender, EventArgs e) {
        //    if (inChiusura) return;
        //    ricalcolaImporti();
        //}

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

        private void txtNewIvaValuta_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            RicalcolaIvaIndeducibile();
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

                double quantitaconfezioni = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewQuantitaConfezioni.Text, "x.y"));
                    
                double aliquota  = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewAliquota.Text, "x.y.fixed.4..%.100"));
                    
                double sconto = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewSconto.Text, "x.y.fixed.4..%.100"));

                double imponibiletot = CfgFn.RoundValuta((imponibile * quantitaconfezioni * (1 - sconto)));

                double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot * tassoCambio);

                //double iva = CfgFn.RoundValuta(imponibiletot * aliquota);
                //double ivaEUR = CfgFn.RoundValuta(iva * tassoCambio);
                double ivaEUR = CfgFn.RoundValuta(imponibiletot * aliquota);

                double percindet = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewPercIndet.Text, "x.y.fixed.4..%.100"));

                //double impindet = CfgFn.RoundValuta(iva * percindet);
                //double impindetEUR = CfgFn.RoundValuta(impindet * tassoCambio);
                double impindetEUR = CfgFn.RoundValuta(ivaEUR * percindet);

                txtNewImponibileValuta.Text = HelpForm.StringValue(imponibiletot,
                    "x.y.fixed.2...1");
                txtNewIvaEuro.Text = ivaEUR.ToString("c");
                txtNewIvaIndetraibileEuro.Text = impindetEUR.ToString("c");
            }
            catch {
                txtNewImponibileValuta.Text = "";
                txtNewIvaEuro.Text = "";
                txtNewIvaIndetraibileEuro.Text = "";
            }
        }


        #endregion

        #region Importi in Euro

        void RicalcolaIvaIndeducibile() {

            try {
                double ivaEUR = CfgFn.GetNoNullDouble(
                   HelpForm.GetObjectFromString(typeof(double), txtNewIvaEuro.Text, "x.y.c"));

                double percindet = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewPercIndet.Text, "x.y.c"));

                double impindeducEUR = CfgFn.RoundValuta(percindet * ivaEUR);
                txtNewIvaIndetraibileEuro.Text = impindeducEUR.ToString("c");
            }
            catch {
                //txtImpDeducEUR.Text = "";
                //txtIvaEUR.Text ="";	
                //txtImpDeducEUR.Text="";
            }

        }

        private void CalcolaImportiEUR() {
            try {

                double imponibile = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewImportoUnitario.Text, "x.y"));

                double quantitaconfezioni = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewQuantitaConfezioni.Text, "x.y"));

                double aliquota = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewAliquota.Text, "x.y.fixed.4..%.100"));

                double sconto = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtNewSconto.Text, "x.y.fixed.4..%.100"));

                double imponibiletot = CfgFn.RoundValuta((imponibile * quantitaconfezioni * (1 - sconto)));

                double ivaEUR = CfgFn.GetNoNullDouble(
                   HelpForm.GetObjectFromString(typeof(double), txtNewIvaEuro.Text, "x.y.c"));

                double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot * tassoCambio);

                

                txtNewImponibileEuro.Text = HelpForm.StringValue(imponibiletotEUR,
                    "x.y.fixed.2...1");
                //txtNewIvaEuro.Text = HelpForm.StringValue(ivaEUR, "x.y.fixed.2...1");
                //txtNewIvaIndetraibileEuro.Text = HelpForm.StringValue(impindetEUR, "x.y.fixed.2...1");
            }
            catch {
                txtNewImponibileEuro.Text = "";
                
            }

        }
        #endregion

        private void btnNewTipoIva_Click(object sender, EventArgs e) {
            MetaData MetaTipoIva = Disp.Get("ivakind");
            MetaTipoIva.FilterLocked = true;
            MetaTipoIva.DS = new DataSet();

            string filter = QHS.NullOrEq("active", 'S');
            DataRow rTipoIva = MetaTipoIva.SelectOne("default", filter, null, null);
            if (rTipoIva == null) {
                return;
            }
            cmbNewTipoIva.SelectedValue = rTipoIva["idivakind"];
        }

        private void rdoNewAttivita2_CheckedChanged(object sender, EventArgs e) {
            if (rdoNewAttivita2.Checked) {
                chkNewPromiscuo.CheckState = CheckState.Unchecked;
                flagActivityValue = 2;
            }
        }

        private void rdoNewAttivita1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNewAttivita1.Checked)
            {
                flagActivityValue = 1;
                chkNewPromiscuo.CheckState = CheckState.Unchecked;
            }
        }

        private void rdoNewAttivita4_CheckedChanged(object sender, EventArgs e) {
            if (rdoNewAttivita4.Checked)
            {
                chkNewPromiscuo.CheckState = CheckState.Unchecked;
                flagActivityValue = 4;
            }
        }

        private void txtNewQuantitaConfezioni_TextChanged(object sender, EventArgs e){
            if (inChiusura) return;
            ricalcolaImporti();
        }

        private void btnListino_Click(object sender, EventArgs e){
            Meta = Disp.Get("listview");
            string filter = QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));
            MetaData Mlistino = Disp.Get("listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = new DataSet();
            int nFilter = 0;

            //Filtro sulla classificazione merceologica
            if (chkFilterClass.Checked){
                nFilter = 1;
            }

            //Filtro sulla descrizione
            if (chkListDescription.Checked){
                nFilter = nFilter + 2;
            }

            if (nFilter > 0){
                FrmAskDescr FR = new FrmAskDescr(Meta.Dispatcher, nFilter);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                if (FR.Selected != null)
                {
                    object idlistclass = FR.Selected["idlistclass"];
                    filter = GetData.MergeFilters(filter,
                            "(idlistclass =  " + QueryCreator.quotedstrvalue(FR.Selected["idlistclass"], true) + ")");
                }
                filter = GetData.MergeFilters(filter,
                     "(description like "
                     + QueryCreator.quotedstrvalue("%" + FR.txtDescrizione.Text + "%", true) + ")");
            }

            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) return;

            riempiOggetti(Choosen);

            return;
        }

        private void riempiOggetti(DataRow listRow){
            txNewListino.Text = (listRow != null) ? listRow["intcode"].ToString() : "";
            txtNewDescrizioneListino.Text = (listRow != null) ? listRow["description"].ToString() : "";
            txtNewCoeffConversione.Text = (listRow != null) ? listRow["unitsforpackage"].ToString() : "";

            HelpForm.SetComboBoxValue(cmbNewUnitaMisuraCS, listRow["idunit"]);
            HelpForm.SetComboBoxValue(cmbNewUnitaMisuraAcquisto, listRow["idpackage"]);
        }

        private void svuotaOggetti(){
            txtNewCoeffConversione.Text = "";
            txtNewDescrizioneListino.Text = "";
            if (cmbNewUnitaMisuraCS.SelectedIndex > 0){
                cmbNewUnitaMisuraCS.SelectedIndex = -1;
            }

            if (cmbNewUnitaMisuraAcquisto.SelectedIndex > 0){
                cmbNewUnitaMisuraAcquisto.SelectedIndex = -1;
            }
        }

        private void txNewtListino_Leave(object sender, EventArgs e){
            Meta = Disp.Get("listview");
            if (txNewListino.Text == ""){
                svuotaOggetti();
                return;
            }
            string filter = QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));

            string IntCode = txNewListino.Text;
            if (!IntCode.EndsWith("%")) IntCode += "%";
            filter = GetData.MergeFilters(filter, QHS.Like("intcode", IntCode));

            MetaData Mlistino = Disp.Get("listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = new DataSet();
            rListChosen = Mlistino.SelectOne("default", filter, null, null);
            if (rListChosen == null){
                return;
            }

            riempiOggetti(rListChosen);

            return;
        }

        private void txtNewQuantitaConfezioni_Leave(object sender, EventArgs e){
            if (txtNewQuantitaConfezioni.Text == ""){
                txtNewQuantita.Text = "";
                return;
            }
            double npackage = CfgFn.GetNoNullDouble(txtNewQuantitaConfezioni.Text);
            int unitsforpackage = CfgFn.GetNoNullInt32(txtNewCoeffConversione.Text);
            if (unitsforpackage == 0)
                unitsforpackage = 1;
            double number = npackage * unitsforpackage;
            txtNewQuantita.Text = HelpForm.StringValue(number, "x.y");
        }

        private void rdoNewAttivita3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNewAttivita3.Checked)
            {
                chkNewPromiscuo.CheckState = CheckState.Checked;
                flagActivityValue = 3;
            }
        }

        private void WizRimpiazzaPerProrata_FormClosed(object sender, FormClosedEventArgs e) {
            MetaData.UnregisterAllEvents(this);
        }
    }
}
