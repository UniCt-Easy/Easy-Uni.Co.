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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using funzioni_configurazione;
using ep_functions;

namespace paymentview_esitazionemultipla {
    /// <summary>
    /// Summary description for FrmPaymentview_esitazionemultipla.
    /// </summary>
    public class FrmPaymentview_esitazionemultipla : System.Windows.Forms.Form {
        private string MESSAGGIO =
            "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse per selezionare più ";

        private MetaData meta;
        private System.Windows.Forms.DataGrid gridMandati;
        private System.Windows.Forms.Button btnSeleziona;
        private System.Windows.Forms.TextBox txtDocumentiSelezionati;
        private System.Windows.Forms.TextBox txtSelezione;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.TextBox txtDataOperaz;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDataValuta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRifBanca;
        public paymentview_esitazionemultipla.vistaForm DS;
        private TextBox txtImporto;
        private Label label3;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        CQueryHelper QHC;
        QueryHelper QHS;
        int esercizio;

        public FrmPaymentview_esitazionemultipla() {
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
            this.gridMandati = new System.Windows.Forms.DataGrid();
            this.btnSeleziona = new System.Windows.Forms.Button();
            this.txtDocumentiSelezionati = new System.Windows.Forms.TextBox();
            this.txtSelezione = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataValuta = new System.Windows.Forms.TextBox();
            this.txtRifBanca = new System.Windows.Forms.TextBox();
            this.txtDataOperaz = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSalva = new System.Windows.Forms.Button();
            this.DS = new paymentview_esitazionemultipla.vistaForm();
            ((System.ComponentModel.ISupportInitialize) (this.gridMandati)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMandati
            // 
            this.gridMandati.AllowNavigation = false;
            this.gridMandati.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMandati.DataMember = "";
            this.gridMandati.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridMandati.Location = new System.Drawing.Point(8, 23);
            this.gridMandati.Name = "gridMandati";
            this.gridMandati.Size = new System.Drawing.Size(725, 270);
            this.gridMandati.TabIndex = 33;
            this.gridMandati.Tag = "expenseview.default";
            this.gridMandati.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridMandati_MouseClick);
            this.gridMandati.CurrentCellChanged += new System.EventHandler(this.gridMandati_CurrentCellChanged);
            // 
            // btnSeleziona
            // 
            this.btnSeleziona.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSeleziona.Location = new System.Drawing.Point(10, 312);
            this.btnSeleziona.Name = "btnSeleziona";
            this.btnSeleziona.Size = new System.Drawing.Size(96, 23);
            this.btnSeleziona.TabIndex = 35;
            this.btnSeleziona.Text = "Seleziona";
            this.btnSeleziona.Click += new System.EventHandler(this.btnSeleziona_Click);
            // 
            // txtDocumentiSelezionati
            // 
            this.txtDocumentiSelezionati.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumentiSelezionati.Location = new System.Drawing.Point(106, 336);
            this.txtDocumentiSelezionati.Name = "txtDocumentiSelezionati";
            this.txtDocumentiSelezionati.ReadOnly = true;
            this.txtDocumentiSelezionati.Size = new System.Drawing.Size(629, 20);
            this.txtDocumentiSelezionati.TabIndex = 41;
            // 
            // txtSelezione
            // 
            this.txtSelezione.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelezione.Location = new System.Drawing.Point(106, 312);
            this.txtSelezione.Name = "txtSelezione";
            this.txtSelezione.Size = new System.Drawing.Size(629, 20);
            this.txtSelezione.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(2, 336);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 40;
            this.label4.Text = "Mov. selezionati:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label2
            // 
            this.label2.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(698, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Immettere i numeri e/o gli intervalli dei movimenti separati da virgole. Es.: per" +
                               " selezionare i movimenti 1,4,6,7,8 scrivere 1,4,6-8 e premere Seleziona.";
            // 
            // label1
            // 
            this.label1.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(557, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
                               "per selezionare più movimenti";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtImporto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDataValuta);
            this.groupBox1.Controls.Add(this.txtRifBanca);
            this.groupBox1.Controls.Add(this.txtDataOperaz);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnSalva);
            this.groupBox1.Location = new System.Drawing.Point(8, 354);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(725, 93);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informazioni sugli esiti dei movimenti selezionati";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(540, 28);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.ReadOnly = true;
            this.txtImporto.Size = new System.Drawing.Size(170, 20);
            this.txtImporto.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(537, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Importo Totale Movimenti Finanziari";
            // 
            // txtDataValuta
            // 
            this.txtDataValuta.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataValuta.Location = new System.Drawing.Point(96, 64);
            this.txtDataValuta.Name = "txtDataValuta";
            this.txtDataValuta.Size = new System.Drawing.Size(414, 20);
            this.txtDataValuta.TabIndex = 14;
            this.txtDataValuta.Tag = "";
            this.txtDataValuta.Leave += new System.EventHandler(this.txtDataValuta_Leave);
            // 
            // txtRifBanca
            // 
            this.txtRifBanca.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRifBanca.Location = new System.Drawing.Point(96, 16);
            this.txtRifBanca.Name = "txtRifBanca";
            this.txtRifBanca.Size = new System.Drawing.Size(414, 20);
            this.txtRifBanca.TabIndex = 10;
            this.txtRifBanca.Tag = "";
            // 
            // txtDataOperaz
            // 
            this.txtDataOperaz.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataOperaz.Location = new System.Drawing.Point(96, 40);
            this.txtDataOperaz.Name = "txtDataOperaz";
            this.txtDataOperaz.Size = new System.Drawing.Size(414, 20);
            this.txtDataOperaz.TabIndex = 12;
            this.txtDataOperaz.Tag = "";
            this.txtDataOperaz.Leave += new System.EventHandler(this.txtDataOperaz_Leave);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Data operazione";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Data valuta:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Rif. banca";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalva.Location = new System.Drawing.Point(540, 53);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(171, 32);
            this.btnSalva.TabIndex = 18;
            this.btnSalva.Text = "Esita";
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // FrmPaymentview_esitazionemultipla
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(741, 451);
            this.Controls.Add(this.gridMandati);
            this.Controls.Add(this.btnSeleziona);
            this.Controls.Add(this.txtDocumentiSelezionati);
            this.Controls.Add(this.txtSelezione);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPaymentview_esitazionemultipla";
            this.Text = "FrmPaymentview_esitazionemultipla";
            ((System.ComponentModel.ISupportInitialize) (this.gridMandati)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region aggiornaDataGrid: in base al radiobutton selezionato aggiorna il grid

        private void aggiornaDataGrid(string tipoMovimenti) {
            Cursor = Cursors.WaitCursor;
            label1.Text = MESSAGGIO + tipoMovimenti;
            txtSelezione.Text = null;
            txtDocumentiSelezionati.Text = null;
            fillExpenseView();
            string dataMember = gridMandati.DataMember;
            CurrencyManager cm = (CurrencyManager) gridMandati.BindingContext[DS, dataMember];
            DataView view = cm.List as DataView;
            if (view != null) {
                for (int i = 0; i < cm.Count; i++) {
                    gridMandati.UnSelect(i);
                }
                new formatgrids(gridMandati).AutosizeColumnWidth();
                btnSalva.Enabled = false;
            }
            Cursor = null;
        }

        #endregion

        #region selezioneRigheCambiata: in base alla selezione nel grid aggiorna tutto il resto del form

        private int getPrimaRigaSelezionata(DataView view) {
            for (int i = 0; i < view.Count; i++) {
                if (gridMandati.IsSelected(i)) {
                    return i;
                }
            }
            return -1;
        }

        private DateTime getDateTime(object o) {
            if (o is DBNull) return QueryCreator.EmptyDate();
            return (DateTime) o;
        }

        bool AbilitaAggiornamento = true;

        /// <summary>
        /// In base alle righe selezionate nel grid aggiorna i campi rifbanca, flagesito, dataoperazione e datavaluta
        /// </summary>
        /// 

        private void selezioneRigheCambiata() {
            if (!AbilitaAggiornamento) return;
            CurrencyManager cm = (CurrencyManager) gridMandati.BindingContext[DS, gridMandati.DataMember];
            DataView view = cm.List as DataView;
            if (view == null) {
                return;
            }
            string elenco = "";
            for (int i = 0; i < view.Count; i++) {
                if (gridMandati.IsSelected(i)) {
                    elenco += "," + view[i]["nmov"];
                }
            }

            if (elenco != "") elenco = elenco.Remove(0, 1);

            DS.banktransaction.Clear();
            bool esisteSelezione = elenco != "";
            btnSalva.Enabled = esisteSelezione;

            txtDocumentiSelezionati.Text = elenco;
        }

        #endregion

        #region selezionaIDocumentiInBaseATextBox: in base al contenuto di txtSelezione seleziona le righe del grid

        /// <summary>
        /// In base al contenuto di txtSelezione seleziona le righe del grid
        /// </summary>
        private void selezionaIDocumentiInBaseATextBox() {
            string dataMember = gridMandati.DataMember;
            CurrencyManager cm = (CurrencyManager) gridMandati.BindingContext[DS, dataMember];
            DataView view = cm.List as DataView;
            if (view == null) return;

            if (txtSelezione.Text == "") {
                txtDocumentiSelezionati.Text = null;
                for (int i = 0; i < cm.Count; i++) {
                    gridMandati.UnSelect(i);
                }
                btnSalva.Enabled = false;
                return;
            }
            int max = int.MinValue;
            int min = int.MaxValue;
            foreach (DataRowView r in view) {
                int numDoc = CfgFn.GetNoNullInt32(r["nmov"]);
                if (numDoc < min) {
                    min = numDoc;
                }
                if (numDoc > max) {
                    max = numDoc;
                }
            }

            ArrayList al = new ArrayList();
            string[] valori = txtSelezione.Text.Split(new char[] {','});
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
                    MessageBox.Show(this,
                        "Errore nella selezione desiderata: " + valore +
                        "\nImmettere i numeri dei movimenti e/o gli intervalli dei movimenti separati da virgole.");
                    return;
                }
            }
            for (int i = 0; i < cm.Count; i++) {
                int numDoc = (int) view[i]["nmov"];
                int pos = al.IndexOf(numDoc);
                if (pos != -1) {
                    gridMandati.Select(i);
                }
                else {
                    gridMandati.UnSelect(i);
                }
            }
            selezioneRigheCambiata();
        }

        #endregion

        private EP_Manager epm;

        public void MetaData_AfterLink() {
            meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = meta.Conn.GetQueryHelper();
            esercizio = (int) meta.GetSys("esercizio");
            HelpForm.SetAllowMultiSelection(DS.expenseview, true);
            GetData.SetSorting(DS.expenseview, "ymov, nmov");
            MetaData.SetDefault(DS.banktransaction, "kind", "D");
            MetaData.SetDefault(DS.banktransaction, "yban", esercizio);

            
        }

        private void impostaCaption() {
            if (DS.expenseview == null) return;

            foreach (DataColumn C in DS.expenseview.Columns) {
                DS.expenseview.Columns[C.ColumnName].Caption = "";
            }
            //int pos = 1;
            //DS.expenseview.Columns["ymov"].Caption = ""; // "Eserc. Mov.";
            //MetaData.DescribeAColumn(DS.expenseview, "nmov", "Num. Mov.", pos++);
            //MetaData.DescribeAColumn(DS.expenseview, "description", "Descrizione", pos++);
            //MetaData.DescribeAColumn(DS.expenseview, "registry", "Percipiente", pos++);
            //MetaData.DescribeAColumn(DS.expenseview, "curramount", "Importo", pos++);
            //MetaData.DescribeAColumn(DS.expenseview, "npay", "Num. Mandato", pos++);
            //MetaData.DescribeAColumn(DS.expenseview, "idpay", "Num. Operazione", pos++);

            DS.expenseview.Columns["nmov"].Caption = "Num. Mov.";
            DS.expenseview.Columns["description"].Caption = "Descrizione";
            DS.expenseview.Columns["registry"].Caption = "Percipiente";
            DS.expenseview.Columns["curramount"].Caption = "Importo";
            DS.expenseview.Columns["ypay"].Caption = ""; // "Eserc. Mandato";
            DS.expenseview.Columns["npay"].Caption = "Num. Mandato";
            DS.expenseview.Columns["idpay"].Caption = "Num. Operazione";
        }

        private void fillExpenseView() {
            DS.expenseview.Clear();
            object esercizio = meta.GetSys("esercizio");

            string q1 = QHS.AppAnd(QHS.IsNotNull("idpay"), QHS.CmpEq("ayear", esercizio), QHS.CmpGe("curramount", 0));
            string q2 = " NOT EXISTS(SELECT * FROM banktransaction B WHERE ";
            q2 += QHS.AppAnd(QHS.CmpEq("B.idexp", QHS.Field("expenseview.idexp")),
                QHS.CmpEq("B.kpay", QHS.Field("expenseview.kpay")),
                QHS.CmpEq("B.idpay", QHS.Field("expenseview.idpay"))) + ")";
            q2 = QHS.DoPar(q2);

            string filtro = QHS.AppAnd(q1, q2)
//                + " and (select count(*) from expenseview e2 where e2.ypay=expenseview.ypay and e2.npay=expenseview.npay)>1"
                            +
                            " and exists (select * from paymentview where paymentview.kpay=expenseview.kpay and kpaymenttransmission is not null and isnull(notperformed,0) > 0)";

            meta.Conn.RUN_SELECT_INTO_TABLE(DS.expenseview, null, filtro, null, false);

            if (gridMandati.DataSource == null) {
                HelpForm.SetDataGrid(gridMandati, DS.expenseview);
                new formatgrids(gridMandati).AutosizeColumnWidth();
            }
        }

        public void MetaData_AfterActivation() {
            impostaCaption();
            fillExpenseView();
            btnSalva.Enabled = false;
        }

        private void esita() {
            if (txtDataOperaz.Text == "") {
                MessageBox.Show(this, "Inserire la data di operazione");
                txtDataOperaz.Focus();
                return;
            }
            string dataMember = gridMandati.DataMember;
            CurrencyManager cm = (CurrencyManager) gridMandati.BindingContext[DS, dataMember];
            DataView view = cm.List as DataView;
            if (view == null) return;

            object bankReference = txtRifBanca.Text;
            object transactionDate = HelpForm.GetObjectFromString(typeof(DateTime), txtDataOperaz.Text, "x.y");
            if (transactionDate != DBNull.Value) {
                {
                    try {
                        DateTime a = (DateTime) transactionDate;
                    }
                    catch {
                        MessageBox.Show(this, "Data operazione non valida");
                        return;
                    }
                }
            }
            object valueDate = HelpForm.GetObjectFromString(typeof(DateTime), txtDataValuta.Text, "x.y");
            if (valueDate != DBNull.Value) {
                try {
                    DateTime a = (DateTime) valueDate;
                }
                catch {
                    MessageBox.Show(this, "Data valuta non valida");
                    return;
                }
            }
            string messaggio = "";
            MetaData metaBT = MetaData.GetMetaData(this, "banktransaction");
            MetaData metaBI = MetaData.GetMetaData(this, "bankimport");
            metaBT.SetDefaults(DS.banktransaction);
            metaBI.SetDefaults(DS.bankimport);


            DS.bankimport.Clear();
            DS.banktransaction.Clear();
            DataRow rBI = metaBI.Get_New_Row(null, DS.bankimport);

            for (int i = 0; i < view.Count; i++) {
                if (gridMandati.IsSelected(i)) {
                    messaggio += "," + view[i]["nmov"];
                    meta.SetDefaults(DS.banktransaction);
                    DataRow r = metaBT.Get_New_Row(rBI, DS.banktransaction);
                    r["bankreference"] = bankReference;
                    r["transactiondate"] = transactionDate;
                    r["valuedate"] = valueDate;
                    r["amount"] = view[i]["curramount"];
                    r["kpay"] = view[i]["kpay"];
                    r["idpay"] = view[i]["idpay"];
                    r["idexp"] = view[i]["idexp"];

                }
            }
            if (messaggio != "") {
                messaggio = "Per esitare i seguenti movimenti: " + messaggio.Substring(1)
                            + "\nsono stati creati gli esiti assegnando i seguenti valori:"
                            + "\nrif. banca: '" + bankReference
                            + "'\ndata operazione: '" + HelpForm.StringValue(transactionDate, "x.y")
                            + "'\ndata valuta: '" + HelpForm.StringValue(valueDate, "x.y") + "'";
            }
            metaBI.DS = DS;
            epm = new EP_Manager(metaBI, null, null, null, null, null, null, null, null, "bankimport");
            epm.beforePost();

            PostData pd = meta.Get_PostData();
            pd.InitClass(DS, meta.Conn);
            if (pd.DO_POST()) {
                epm.afterPost();
                MessageBox.Show(this, messaggio, "DB AGGIORNATO CORRETTAMENTE");
            }
            else {
                MessageBox.Show(this, "Errore durante l'aggiornamento del D.B.!", "ERRORE");
            }
            aggiornaDataGrid("MOVIMENTI non esitati");
            decimal importoTot = ricalcolaImportoTotale();
            txtImporto.Text = importoTot.ToString("c");
        }

        private void btnSalva_Click(object sender, System.EventArgs e) {
            AbilitaAggiornamento = false;
            esita();
            AbilitaAggiornamento = true;
            selezioneRigheCambiata();
        }

        private void txtDataOperaz_Leave(object sender, System.EventArgs e) {
            HelpForm.ExtLeaveDateTimeTextBox(txtDataOperaz, "x.y");
        }

        private void txtDataValuta_Leave(object sender, System.EventArgs e) {
            HelpForm.ExtLeaveDateTimeTextBox(txtDataValuta, "x.y");
        }

        private void btnSeleziona_Click(object sender, System.EventArgs e) {
            selezionaIDocumentiInBaseATextBox();
            decimal importoTot = ricalcolaImportoTotale();
            txtImporto.Text = importoTot.ToString("c");
        }

        private void gridMandati_MouseClick(object sender, MouseEventArgs e) {
            selezioneRigheCambiata();
            decimal importoTot = ricalcolaImportoTotale();
            txtImporto.Text = importoTot.ToString("c");
        }

        private void gridMandati_CurrentCellChanged(object sender, EventArgs e) {
            selezioneRigheCambiata();
        }

        private decimal ricalcolaImportoTotale() {
            decimal importoTot = 0;
            CurrencyManager cm = (CurrencyManager) gridMandati.BindingContext[DS, gridMandati.DataMember];
            DataView view = cm.List as DataView;
            if (view == null) {
                return importoTot;
            }

            for (int i = 0; i < view.Count; i++) {
                if (gridMandati.IsSelected(i)) {
                    importoTot += CfgFn.GetNoNullDecimal(view[i]["curramount"]);
                }
            }
            return importoTot;
        }
    }
}