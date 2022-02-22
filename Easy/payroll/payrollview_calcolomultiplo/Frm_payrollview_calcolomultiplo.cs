
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using System.Globalization;

namespace payrollview_calcolomultiplo //cedolino_calcolomultiplo//
{
    /// <summary>
    /// Summary description for frmcedolino_calcolomultiplo.
    /// </summary>
    public class Frm_cedolino_calcolomultiplo : MetaDataForm {
        private MetaData Meta;
        public vistaForm DS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSeleziona;
        private System.Windows.Forms.DataGrid dgCedolini;
        private System.Windows.Forms.GroupBox grpFiltroCedolini;
        private System.Windows.Forms.RadioButton rbArretrati;
        private System.Windows.Forms.RadioButton rbMese;
        private System.Windows.Forms.TextBox txtCedoliniSelezionati;
        private System.Windows.Forms.TextBox txtSelezionaCedolini;
        private System.Windows.Forms.Button btnCalcolaCedolini;
        private System.Windows.Forms.Button btnAggiorna;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCedoliniCalcolati;
        private System.Windows.Forms.Button btnContrattiSenzaCedolini;
        public System.Windows.Forms.GroupBox MetaDataDetail;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Frm_cedolino_calcolomultiplo() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.DS = new payrollview_calcolomultiplo.vistaForm();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.btnCalcolaCedolini = new System.Windows.Forms.Button();
            this.txtCedoliniSelezionati = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSelezionaCedolini = new System.Windows.Forms.TextBox();
            this.btnSeleziona = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgCedolini = new System.Windows.Forms.DataGrid();
            this.grpFiltroCedolini = new System.Windows.Forms.GroupBox();
            this.btnAggiorna = new System.Windows.Forms.Button();
            this.rbMese = new System.Windows.Forms.RadioButton();
            this.rbArretrati = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCedoliniCalcolati = new System.Windows.Forms.TextBox();
            this.MetaDataDetail = new System.Windows.Forms.GroupBox();
            this.btnContrattiSenzaCedolini = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dgCedolini)).BeginInit();
            this.grpFiltroCedolini.SuspendLayout();
            this.MetaDataDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChiudi.Location = new System.Drawing.Point(648, 392);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.TabIndex = 17;
            this.btnChiudi.Text = "Chiudi";
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // btnCalcolaCedolini
            // 
            this.btnCalcolaCedolini.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCalcolaCedolini.Location = new System.Drawing.Point(344, 392);
            this.btnCalcolaCedolini.Name = "btnCalcolaCedolini";
            this.btnCalcolaCedolini.Size = new System.Drawing.Size(154, 23);
            this.btnCalcolaCedolini.TabIndex = 16;
            this.btnCalcolaCedolini.Text = "Calcola i cedolini selezionati";
            this.btnCalcolaCedolini.Click += new System.EventHandler(this.btnCalcolaCedolini_Click);
            // 
            // txtCedoliniSelezionati
            // 
            this.txtCedoliniSelezionati.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCedoliniSelezionati.Enabled = false;
            this.txtCedoliniSelezionati.Location = new System.Drawing.Point(96, 56);
            this.txtCedoliniSelezionati.Name = "txtCedoliniSelezionati";
            this.txtCedoliniSelezionati.ReadOnly = true;
            this.txtCedoliniSelezionati.Size = new System.Drawing.Size(616, 20);
            this.txtCedoliniSelezionati.TabIndex = 15;
            this.txtCedoliniSelezionati.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(1, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Cedolini selezionati";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSelezionaCedolini
            // 
            this.txtSelezionaCedolini.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelezionaCedolini.Location = new System.Drawing.Point(96, 24);
            this.txtSelezionaCedolini.Name = "txtSelezionaCedolini";
            this.txtSelezionaCedolini.Size = new System.Drawing.Size(616, 20);
            this.txtSelezionaCedolini.TabIndex = 13;
            this.txtSelezionaCedolini.Text = "";
            // 
            // btnSeleziona
            // 
            this.btnSeleziona.Location = new System.Drawing.Point(8, 24);
            this.btnSeleziona.Name = "btnSeleziona";
            this.btnSeleziona.Size = new System.Drawing.Size(80, 23);
            this.btnSeleziona.TabIndex = 12;
            this.btnSeleziona.Text = "Seleziona";
            this.btnSeleziona.Click += new System.EventHandler(this.btnSeleziona_Click);
            // 
            // label1
            // 
            this.label1.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(704, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
                               "per selezionare più cedolini";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgCedolini
            // 
            this.dgCedolini.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCedolini.CaptionVisible = false;
            this.dgCedolini.DataMember = "";
            this.dgCedolini.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCedolini.Location = new System.Drawing.Point(16, 32);
            this.dgCedolini.Name = "dgCedolini";
            this.dgCedolini.Size = new System.Drawing.Size(704, 208);
            this.dgCedolini.TabIndex = 9;
            this.dgCedolini.Tag = "payrollview.lista.default";
            this.dgCedolini.Paint += new System.Windows.Forms.PaintEventHandler(this.dgCedolini_Paint);
            // 
            // grpFiltroCedolini
            // 
            this.grpFiltroCedolini.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpFiltroCedolini.Controls.Add(this.btnAggiorna);
            this.grpFiltroCedolini.Controls.Add(this.rbMese);
            this.grpFiltroCedolini.Controls.Add(this.rbArretrati);
            this.grpFiltroCedolini.Location = new System.Drawing.Point(16, 376);
            this.grpFiltroCedolini.Name = "grpFiltroCedolini";
            this.grpFiltroCedolini.Size = new System.Drawing.Size(264, 56);
            this.grpFiltroCedolini.TabIndex = 18;
            this.grpFiltroCedolini.TabStop = false;
            this.grpFiltroCedolini.Text = "Filtro sui cedolini";
            // 
            // btnAggiorna
            // 
            this.btnAggiorna.Location = new System.Drawing.Point(8, 24);
            this.btnAggiorna.Name = "btnAggiorna";
            this.btnAggiorna.Size = new System.Drawing.Size(80, 23);
            this.btnAggiorna.TabIndex = 3;
            this.btnAggiorna.Text = "Nessun filtro";
            this.btnAggiorna.Click += new System.EventHandler(this.btnAggiorna_Click);
            // 
            // rbMese
            // 
            this.rbMese.Location = new System.Drawing.Point(184, 24);
            this.rbMese.Name = "rbMese";
            this.rbMese.Size = new System.Drawing.Size(72, 24);
            this.rbMese.TabIndex = 1;
            this.rbMese.Text = "Del mese";
            this.rbMese.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rbArretrati
            // 
            this.rbArretrati.Location = new System.Drawing.Point(104, 24);
            this.rbArretrati.Name = "rbArretrati";
            this.rbArretrati.Size = new System.Drawing.Size(64, 24);
            this.rbArretrati.TabIndex = 0;
            this.rbArretrati.Text = "Arretrati";
            this.rbArretrati.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(16, 344);
            this.label4.Name = "label4";
            this.label4.TabIndex = 20;
            this.label4.Text = "Cedolini calcolati";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCedoliniCalcolati
            // 
            this.txtCedoliniCalcolati.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCedoliniCalcolati.Location = new System.Drawing.Point(104, 344);
            this.txtCedoliniCalcolati.Name = "txtCedoliniCalcolati";
            this.txtCedoliniCalcolati.ReadOnly = true;
            this.txtCedoliniCalcolati.Size = new System.Drawing.Size(616, 20);
            this.txtCedoliniCalcolati.TabIndex = 21;
            this.txtCedoliniCalcolati.Text = "";
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.Controls.Add(this.txtCedoliniSelezionati);
            this.MetaDataDetail.Controls.Add(this.btnSeleziona);
            this.MetaDataDetail.Controls.Add(this.txtSelezionaCedolini);
            this.MetaDataDetail.Controls.Add(this.label3);
            this.MetaDataDetail.Location = new System.Drawing.Point(8, 248);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(720, 88);
            this.MetaDataDetail.TabIndex = 23;
            this.MetaDataDetail.TabStop = false;
            this.MetaDataDetail.Text =
                "Immettere i numeri e/o gli intervalli di cedolini separati da virgole. Es.: per s" +
                "elezionare i cedolini 1,4,6,7,8 scrivere 1,4,6-8 e premi Seleziona.";
            // 
            // btnContrattiSenzaCedolini
            // 
            this.btnContrattiSenzaCedolini.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContrattiSenzaCedolini.Location = new System.Drawing.Point(508, 392);
            this.btnContrattiSenzaCedolini.Name = "btnContrattiSenzaCedolini";
            this.btnContrattiSenzaCedolini.Size = new System.Drawing.Size(130, 23);
            this.btnContrattiSenzaCedolini.TabIndex = 24;
            this.btnContrattiSenzaCedolini.Text = "Contratti senza cedolini";
            this.btnContrattiSenzaCedolini.Click += new System.EventHandler(this.btnContrattiSenzaCedolini_Click);
            // 
            // Frm_cedolino_calcolomultiplo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(736, 446);
            this.Controls.Add(this.btnContrattiSenzaCedolini);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.txtCedoliniCalcolati);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grpFiltroCedolini);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.btnCalcolaCedolini);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgCedolini);
            this.Name = "Frm_cedolino_calcolomultiplo";
            this.Text = "frmcedolino_calcolomultiplo";
            ((System.ComponentModel.ISupportInitialize) (this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dgCedolini)).EndInit();
            this.grpFiltroCedolini.ResumeLayout(false);
            this.MetaDataDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            GetData.SetSorting(DS.payrollview, "idcon, fiscalyear, npayroll");
            GetData.SetStaticFilter(DS.payrollview, QHS.AppAnd(QHS.CmpEq("flagcomputed", 'N'),
                QHS.CmpEq("fiscalyear", Meta.GetSys("esercizio")), QHS.CmpLe("start", Meta.GetSys("datacontabile")),
                QHS.CmpEq("year(stop)", Meta.GetSys("esercizio"))             ,
                QHS.CmpEq("flagbalance", 'N')));
            HelpForm.SetAllowMultiSelection(DS.payrollview, true);
        }

        private void btnSeleziona_Click(object sender, System.EventArgs e) {
            string dataMember = dgCedolini.DataMember;
            CurrencyManager cm = (CurrencyManager) dgCedolini.BindingContext[DS, dataMember];
            DataView view = (DataView) cm.List;
            if (txtSelezionaCedolini.Text == "") {
                txtCedoliniSelezionati.Text = null;
                for (int i = 0; i < cm.Count; i++) {
                    dgCedolini.UnSelect(i);
                }
                return;
            }
            int max = int.MinValue;
            int min = int.MaxValue;
            foreach (DataRowView r in view) {
                int numDoc = Convert.ToInt32(r["idpayroll"]);
                if (numDoc < min) {
                    min = numDoc;
                }
                if (numDoc > max) {
                    max = numDoc;
                }
            }

            ArrayList al = new ArrayList();
            string[] valori = txtSelezionaCedolini.Text.Split(new char[] {','});
            foreach (string valore in valori) {
                int pos = valore.IndexOf('-');
                try {
                    if (pos == -1) {
                        int numDoc = Int32.Parse(valore);
                        al.Add(numDoc);
                    }
                    else {
                        string valore1 = valore.Substring(0, pos);
                        string valore2 = valore.Substring(pos + 1);
                        int doc1 = (valore1 == "") ? min : Int32.Parse(valore1);
                        int doc2 = (valore2 == "") ? max : Int32.Parse(valore2);
                        if (doc1 > doc2) {
                            int h = doc1;
                            doc1 = doc2;
                            doc2 = h;
                        }
                        for (int i = doc1; i <= doc2; i++) {
                            al.Add(i);
                        }
                    }
                }
                catch (FormatException) {
                    show(this,
                        "Errore nella selezione desiderata: " + valore +
                        "\nImmettere i numeri di cedolino e/o gli intervalli di cedolino separati da virgole.");
                    return;
                }
            }
            for (int i = 0; i < cm.Count; i++) {
                int numDoc = Convert.ToInt32(view[i]["idpayroll"]);
                int pos = al.IndexOf(numDoc);
                if (pos != -1) {
                    dgCedolini.Select(i);
                }
                else {
                    dgCedolini.UnSelect(i);
                }
            }
            selezioneRigheCambiata();
        }

        private int getPrimaRigaSelezionata(DataView view) {
            for (int i = 0; i < view.Count; i++) {
                if (dgCedolini.IsSelected(i)) {
                    return i;
                }
            }
            return -1;
        }

        private void selezioneRigheCambiata() {
            string dataMember = dgCedolini.DataMember;
            CurrencyManager cm = (CurrencyManager) dgCedolini.BindingContext[DS, dataMember];
            DataView view = cm.List as DataView;
            if (view != null) {
                int primaRigaSelezionata = getPrimaRigaSelezionata(view);
                if (primaRigaSelezionata == -1) {
                    txtCedoliniSelezionati.Text = null;
                }
                else {
                    txtCedoliniSelezionati.Text = view[primaRigaSelezionata]["idpayroll"].ToString();

                    for (int i = primaRigaSelezionata + 1; i < view.Count; i++) {
                        if (dgCedolini.IsSelected(i)) {
                            txtCedoliniSelezionati.Text += "," + view[i]["idpayroll"];
                        }
                    }
                }
            }
        }

        private void aggiornaDataGrid() {
            string filtro = "";
            DateTime dataContabile = (DateTime) Meta.GetSys("datacontabile");
            if (rbArretrati.Checked) {
                filtro = ".(start < "
                         + QueryCreator.quotedstrvalue(dataContabile.AddMonths(-1), true) + ")";
            }
            if (rbMese.Checked) {
                filtro = ".(start between ("
                         + QueryCreator.quotedstrvalue(dataContabile.AddMonths(-1), true) + ") and ("
                         + QueryCreator.quotedstrvalue(dataContabile, true) + "))";
            }
            txtCedoliniSelezionati.Text = null;
            Meta.DoMainCommand("maindosearch.calcolomultiplo" + filtro);
            string dataMember = dgCedolini.DataMember;
            CurrencyManager cm = dgCedolini.BindingContext[DS, dataMember] as CurrencyManager;
            if (cm == null) return;
            for (int i = 0; i < cm.Count; i++) {
                dgCedolini.UnSelect(i);
            }
            new formatgrids(dgCedolini).AutosizeColumnWidth();
        }

        private void btnCalcolaCedolini_Click(object sender, System.EventArgs e) {
            string dataMember = dgCedolini.DataMember;
            CurrencyManager cm = (CurrencyManager) dgCedolini.BindingContext[DS, dataMember];
            DataView view = cm.List as DataView;
            if (view == null) {
                show(this, "Lista vuota!");
                return;
            }
            ArrayList cedolini = new ArrayList();
            ArrayList contratti = new ArrayList();
            string filtroContratti = "";
            for (int i = 0; i < view.Count; i++) {
                if (dgCedolini.IsSelected(i)) {
                    object idContratto = view[i]["idcon"];
                    object idCedolino = view[i]["idpayroll"];
                    if (contratti.IndexOf(idContratto) == -1) {
                        contratti.Add(idContratto);
                        filtroContratti += ", '" + idContratto + "'";
                    }
                    cedolini.Add(idCedolino);
                }
            }
            if (cedolini.Count == 0) {
                show(this, "Nessun cedolino selezionato!");
                return;
            }
            filtroContratti = filtroContratti.Substring(1);
            FrmProgressCalcoloCedolini frm = new FrmProgressCalcoloCedolini(Meta, cedolini, contratti, filtroContratti);
            frm.ShowDialog(this);
            if (frm.occorreAggiornare) {
                aggiornaDataGrid();
            }
        }

        private void radioButtons_CheckedChanged(object sender, System.EventArgs e) {
            if (((RadioButton) sender).Checked) {
                aggiornaDataGrid();
            }

        }

        private void dgCedolini_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            selezioneRigheCambiata();
        }

        private void btnAggiorna_Click(object sender, System.EventArgs e) {
            rbArretrati.Checked = false;
            rbMese.Checked = false;
            aggiornaDataGrid();
        }

        private void btnChiudi_Click(object sender, System.EventArgs e) {
            Close();
        }

        private void btnContrattiSenzaCedolini_Click(object sender, System.EventArgs e) {
            MetaData MetaContratto_SC = MetaData.GetMetaData(this, "parasubcontract");
            MetaContratto_SC.Edit(this, "senzacedolini", true);
        }
    }
}
