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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using funzioni_configurazione;


namespace proceedspart_detail//assegnazioneincassidetail//
{
	/// <summary>
	/// Summary description for frmassegnazioneincassidetail.
	/// </summary>
    public class Frm_proceedspart_detail : System.Windows.Forms.Form {
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpBilancio;
        private System.Windows.Forms.TextBox txtDescrBilancio;
        private System.Windows.Forms.TextBox txtBilancio;
        private System.Windows.Forms.Button btnBilancio;
        private System.Windows.Forms.GroupBox grpAssegnazione;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumAssegnazione;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercAssegnazione;
        private System.Windows.Forms.GroupBox grpAccertamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumEntrata;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEsercEntrata;
        MetaData Meta;
        string filterupb;
        public /*Rana:assegnazioneincassidetail.*/vistaForm DS;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ImageList imageList1;
        private GroupBox gboxUpb;
        private TextBox txtDescrizioneUpb;
        private TextBox txtUpb;
        private Button btnUpb;
        private System.ComponentModel.IContainer components;
        object idunderwriting = DBNull.Value;
        object idaccertamento = DBNull.Value;

        public Frm_proceedspart_detail() {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_proceedspart_detail));
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpBilancio = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpAssegnazione = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumAssegnazione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercAssegnazione = new System.Windows.Forms.TextBox();
            this.grpAccertamento = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumEntrata = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEsercEntrata = new System.Windows.Forms.TextBox();
            this.DS = new proceedspart_detail.vistaForm();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gboxUpb = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneUpb = new System.Windows.Forms.TextBox();
            this.txtUpb = new System.Windows.Forms.TextBox();
            this.btnUpb = new System.Windows.Forms.Button();
            this.grpBilancio.SuspendLayout();
            this.grpAssegnazione.SuspendLayout();
            this.grpAccertamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gboxUpb.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(200, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 94;
            this.label7.Text = "Data contabile:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(288, 96);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(104, 20);
            this.txtDataContabile.TabIndex = 4;
            this.txtDataContabile.Tag = "proceedspart.adate?proceedspartview.adate";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 92;
            this.label6.Text = "Importo:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(88, 96);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(96, 20);
            this.txtImporto.TabIndex = 3;
            this.txtImporto.Tag = "proceedspart.amount?proceedspartview.amount";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(88, 24);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(304, 64);
            this.txtDescrizione.TabIndex = 2;
            this.txtDescrizione.Tag = "proceedspart.description?proceedspartview.description";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 89;
            this.label5.Text = "Descrizione:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpBilancio
            // 
            this.grpBilancio.Controls.Add(this.txtDescrBilancio);
            this.grpBilancio.Controls.Add(this.txtBilancio);
            this.grpBilancio.Controls.Add(this.btnBilancio);
            this.grpBilancio.Location = new System.Drawing.Point(414, 93);
            this.grpBilancio.Name = "grpBilancio";
            this.grpBilancio.Size = new System.Drawing.Size(400, 138);
            this.grpBilancio.TabIndex = 3;
            this.grpBilancio.TabStop = false;
            this.grpBilancio.Tag = "AutoManage.txtBilancio.treesupb";
            this.grpBilancio.Text = "Bilancio";
            // 
            // txtDescrBilancio
            // 
            this.txtDescrBilancio.Location = new System.Drawing.Point(136, 16);
            this.txtDescrBilancio.Multiline = true;
            this.txtDescrBilancio.Name = "txtDescrBilancio";
            this.txtDescrBilancio.ReadOnly = true;
            this.txtDescrBilancio.Size = new System.Drawing.Size(256, 90);
            this.txtDescrBilancio.TabIndex = 54;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "finview.title";
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(11, 112);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(381, 20);
            this.txtBilancio.TabIndex = 52;
            this.txtBilancio.Tag = "finview.codefin?proceedspartview.codefin";
            // 
            // btnBilancio
            // 
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.ImageList = this.imageList1;
            this.btnBilancio.Location = new System.Drawing.Point(11, 82);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(104, 24);
            this.btnBilancio.TabIndex = 62;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // grpAssegnazione
            // 
            this.grpAssegnazione.Controls.Add(this.label1);
            this.grpAssegnazione.Controls.Add(this.txtNumAssegnazione);
            this.grpAssegnazione.Controls.Add(this.label2);
            this.grpAssegnazione.Controls.Add(this.txtEsercAssegnazione);
            this.grpAssegnazione.Location = new System.Drawing.Point(232, 8);
            this.grpAssegnazione.Name = "grpAssegnazione";
            this.grpAssegnazione.Size = new System.Drawing.Size(176, 80);
            this.grpAssegnazione.TabIndex = 1;
            this.grpAssegnazione.TabStop = false;
            this.grpAssegnazione.Text = "Assegnazione";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumAssegnazione
            // 
            this.txtNumAssegnazione.Location = new System.Drawing.Point(72, 48);
            this.txtNumAssegnazione.Name = "txtNumAssegnazione";
            this.txtNumAssegnazione.Size = new System.Drawing.Size(96, 20);
            this.txtNumAssegnazione.TabIndex = 10;
            this.txtNumAssegnazione.TabStop = false;
            this.txtNumAssegnazione.Tag = "proceedspart.nproceedspart?proceedspartview.nproceedspart";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Esercizio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercAssegnazione
            // 
            this.txtEsercAssegnazione.Location = new System.Drawing.Point(72, 16);
            this.txtEsercAssegnazione.Name = "txtEsercAssegnazione";
            this.txtEsercAssegnazione.ReadOnly = true;
            this.txtEsercAssegnazione.Size = new System.Drawing.Size(56, 20);
            this.txtEsercAssegnazione.TabIndex = 8;
            this.txtEsercAssegnazione.TabStop = false;
            this.txtEsercAssegnazione.Tag = "proceedspart.yproceedspart?proceedspartview.yproceedspart";
            // 
            // grpAccertamento
            // 
            this.grpAccertamento.Controls.Add(this.label3);
            this.grpAccertamento.Controls.Add(this.txtNumEntrata);
            this.grpAccertamento.Controls.Add(this.label4);
            this.grpAccertamento.Controls.Add(this.txtEsercEntrata);
            this.grpAccertamento.Location = new System.Drawing.Point(8, 8);
            this.grpAccertamento.Name = "grpAccertamento";
            this.grpAccertamento.Size = new System.Drawing.Size(176, 80);
            this.grpAccertamento.TabIndex = 0;
            this.grpAccertamento.TabStop = false;
            this.grpAccertamento.Tag = "";
            this.grpAccertamento.Text = "Movimento di entrata";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Numero:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumEntrata
            // 
            this.txtNumEntrata.Location = new System.Drawing.Point(72, 48);
            this.txtNumEntrata.Name = "txtNumEntrata";
            this.txtNumEntrata.ReadOnly = true;
            this.txtNumEntrata.Size = new System.Drawing.Size(96, 20);
            this.txtNumEntrata.TabIndex = 6;
            this.txtNumEntrata.TabStop = false;
            this.txtNumEntrata.Tag = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Esercizio:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercEntrata
            // 
            this.txtEsercEntrata.Location = new System.Drawing.Point(72, 16);
            this.txtEsercEntrata.Name = "txtEsercEntrata";
            this.txtEsercEntrata.ReadOnly = true;
            this.txtEsercEntrata.Size = new System.Drawing.Size(56, 20);
            this.txtEsercEntrata.TabIndex = 4;
            this.txtEsercEntrata.TabStop = false;
            this.txtEsercEntrata.Tag = "";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(414, 380);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(296, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Annulla";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescrizione);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtImporto);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDataContabile);
            this.groupBox1.Location = new System.Drawing.Point(8, 237);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 128);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dati Contabili";
            // 
            // gboxUpb
            // 
            this.gboxUpb.Controls.Add(this.txtDescrizioneUpb);
            this.gboxUpb.Controls.Add(this.txtUpb);
            this.gboxUpb.Controls.Add(this.btnUpb);
            this.gboxUpb.Location = new System.Drawing.Point(8, 93);
            this.gboxUpb.Name = "gboxUpb";
            this.gboxUpb.Size = new System.Drawing.Size(400, 138);
            this.gboxUpb.TabIndex = 2;
            this.gboxUpb.TabStop = false;
            this.gboxUpb.Tag = "AutoChoose.txtUpb.default.(active=\'S\')";
            // 
            // txtDescrizioneUpb
            // 
            this.txtDescrizioneUpb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneUpb.Location = new System.Drawing.Point(136, 16);
            this.txtDescrizioneUpb.Multiline = true;
            this.txtDescrizioneUpb.Name = "txtDescrizioneUpb";
            this.txtDescrizioneUpb.ReadOnly = true;
            this.txtDescrizioneUpb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizioneUpb.Size = new System.Drawing.Size(256, 90);
            this.txtDescrizioneUpb.TabIndex = 0;
            this.txtDescrizioneUpb.TabStop = false;
            this.txtDescrizioneUpb.Tag = "upb.title";
            // 
            // txtUpb
            // 
            this.txtUpb.Location = new System.Drawing.Point(11, 112);
            this.txtUpb.Name = "txtUpb";
            this.txtUpb.Size = new System.Drawing.Size(381, 20);
            this.txtUpb.TabIndex = 1;
            this.txtUpb.Tag = "upb.codeupb? proceedspartview.codeupb";
            // 
            // btnUpb
            // 
            this.btnUpb.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpb.Location = new System.Drawing.Point(11, 86);
            this.btnUpb.Name = "btnUpb";
            this.btnUpb.Size = new System.Drawing.Size(105, 20);
            this.btnUpb.TabIndex = 0;
            this.btnUpb.TabStop = false;
            this.btnUpb.Tag = "";
            this.btnUpb.Text = "U.P.B.";
            this.btnUpb.UseVisualStyleBackColor = false;
            this.btnUpb.Click += new System.EventHandler(this.btnUpb_Click);
            // 
            // Frm_proceedspart_detail
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(823, 416);
            this.Controls.Add(this.gboxUpb);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpBilancio);
            this.Controls.Add(this.grpAssegnazione);
            this.Controls.Add(this.grpAccertamento);
            this.Name = "Frm_proceedspart_detail";
            this.Text = "frmassegnazioneincassidetail";
            this.grpBilancio.ResumeLayout(false);
            this.grpBilancio.PerformLayout();
            this.grpAssegnazione.ResumeLayout(false);
            this.grpAssegnazione.PerformLayout();
            this.grpAccertamento.ResumeLayout(false);
            this.grpAccertamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxUpb.ResumeLayout(false);
            this.gboxUpb.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            string nomeTabella = "";
            if (Meta.edit_type == "detail") {
                nomeTabella = "incomeyear";
            }
            if (Meta.edit_type == "variazione") {
                nomeTabella = "incomeview";
            }
            DataRow Padre = Meta.SourceRow.Table.DataSet.Tables[nomeTabella].Rows[0];
            filterupb = QHS.CmpEq("idupb", Padre["idupb"]);
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string f = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", 'S'), filterupb);
            GetData.SetStaticFilter(DS.finview, f);

            DataRow ParentIncome;
            if (Meta.edit_type == "detail") {
                nomeTabella = "income";
            }
            if (Meta.edit_type == "variazione") {
                nomeTabella = "incomeview";
            }

            ParentIncome = Meta.SourceRow.Table.DataSet.Tables[nomeTabella].Rows[0];
            idunderwriting = ParentIncome["idunderwriting"];

            object parentid = ParentIncome["parentidinc"];

            idaccertamento = Meta.Conn.DO_READ_VALUE("incomelink",
                    QHS.AppAnd(QHS.CmpEq("idchild", parentid),
                                QHS.CmpEq("nlevel", Meta.GetSys("incomefinphase"))), "idparent");
            if (idaccertamento == null) idaccertamento = DBNull.Value;

            GetData.CacheTable(DS.config, filteresercizio, null, false);


        }


        public void MetaData_AfterFill() {
            if (!Meta.FirstFillForThisRow) return;
            string esercMov = "";
            string numMov = "";
            string descrFase = "";
            if (Meta.edit_type == "detail") {
                DataRow R = Meta.SourceRow.GetParentRow("incomeproceedspart");
                esercMov = R["ymov"].ToString();
                if (R.RowState == DataRowState.Added) {
                    numMov = "";
                }
                else {
                    numMov = R["nmov"].ToString();
                }

                object faseObj = Meta.Conn.DO_READ_VALUE("incomephase", QHS.CmpEq("nphase", Meta.GetSys("maxincomephase")), "description");
                if (faseObj != null) descrFase = faseObj.ToString();

                //				DataRow fase = R.GetParentRow("incomephaseincome");
                //				if (fase!=null) descrFase = fase["description"].ToString();
            }
            if (Meta.edit_type == "variazione") {
                if (DS.proceedspart.Rows.Count == 0) return;
                DataRow Curr = DS.proceedspart.Rows[0];
                string filterMov = "(idinc = " + QueryCreator.quotedstrvalue(Curr["idinc"], true) + ")";
                DataTable movTable = DataAccess.RUN_SELECT(Meta.Conn, "income", "ymov,nmov,nphase", null, filterMov, null, null, true);
                if (movTable == null) return;
                esercMov = movTable.Rows[0]["ymov"].ToString();
                numMov = movTable.Rows[0]["nmov"].ToString();
                object faseObj = Meta.Conn.DO_READ_VALUE("incomephase", QHS.CmpEq("nphase", movTable.Rows[0]["nphase"]), "description");
                if (faseObj != null) descrFase = faseObj.ToString();
            }
            txtEsercEntrata.Text = esercMov;
            txtNumEntrata.Text = numMov;
            if (descrFase != "") grpAccertamento.Text = descrFase;
        }

        private void btnBilancio_Click(object sender, System.EventArgs e) {
            string filter;
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            string filteridfin = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.CmpEq("finpart", 'S'));

            //Il filtro sull'UPB c'Ë sempre
            filter = QHS.AppAnd(filteridfin, filterupb);
            DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
            MetaData.DoMainCommand(this, "manage.finview.treesupb");
        }

        bool UsaCrediti() {
            if (DS.config.Rows.Count == 0) return false;
            if (DS.config.Rows[0]["flagcredit"].ToString().ToUpper() == "S") return true;
            return false;
        }




        private void btnUpb_Click(object sender, EventArgs e) {
            // era manage.upb.tree
            if (UsaCrediti()) {
                Meta.GetFormData(true);
                string filter = QHS.AppAnd(QHS.CmpEq("idinc", idaccertamento),
                                    QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                                    QHS.CmpGt("credit", QHS.Field("proceeds"))
                                    );

                MetaData MetaCP = MetaData.GetMetaData(this, "creditproceedsview");


                MetaCP.DS = new DataSet();
                MetaCP.linkedForm = this;
                MetaCP.FilterLocked = true;
                DataRow CP = MetaCP.SelectOne("lista", filter, "creditproceedsview", null);
                if (CP == null) return;
                object idfin = CP["idfin"];
                object idupb = CP["idupb"];
                decimal amount_needed = CfgFn.GetNoNullDecimal(CP["credit"])
                                            - CfgFn.GetNoNullDecimal(CP["proceeds"]);

                DataRow Curr = DS.proceedspart.Rows[0];

                Curr["idfin"] = idfin;
                Curr["idupb"] = idupb;
                //if (Curr["description"].ToString()=="") Curr["description"] = CP["description"]; 

                decimal amount_assignable = GetAssignableAmount();
                //sceglie il minimo tra i due
                decimal amount = amount_needed > amount_assignable ? amount_assignable : amount_needed;
                Curr["amount"] = amount;


                Meta.FreshForm(true);
                return;
            }
            if (idunderwriting != DBNull.Value) {
                Meta.GetFormData(true);
                string filter = QHS.AppAnd(QHS.CmpGt("paymentprevavailable", QHS.Field("proceedsavailable")),
                                            QHS.CmpEq("finpart", "S"), 
                                            QHS.CmpEq("idunderwriting", idunderwriting),
                                            QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
                MetaData MetaUnder = MetaData.GetMetaData(this, "upbunderwritingyearview");
                MetaUnder.DS = new DataSet();
                MetaUnder.linkedForm = this;
                MetaUnder.FilterLocked = true;
                DataRow Und = MetaUnder.SelectOne("crediti", filter, "upbunderwritingyearview", null);
                if (Und == null) return;
                DataRow Curr = DS.proceedspart.Rows[0];
                Curr["idupb"] = Und["idupb"];
                Curr["idfin"] = Und["idfin"];
                decimal amount_needed = CfgFn.GetNoNullDecimal(Und["paymentprevavailable"]) - CfgFn.GetNoNullDecimal(Und["proceedsavailable"]);
                decimal amount_assignable = GetAssignableAmount();
                //sceglie il minimo tra i due
                decimal amount = amount_needed > amount_assignable ? amount_assignable : amount_needed;
                Curr["amount"] = amount;

                Meta.FreshForm(true);
            }
            else {
                Meta.GetFormData(true);
                string filter = QHS.AppAnd(QHS.CmpGt("paymentprevavailable", QHS.Field("proceedsavailable")),
                                            QHS.CmpEq("finpart", "S"),
                                            QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
                MetaData MetaUY = MetaData.GetMetaData(this, "upbfinyearview");
                MetaUY.DS = new DataSet();
                MetaUY.linkedForm = this;
                MetaUY.FilterLocked = true;
                DataRow Und = MetaUY.SelectOne("crediti", filter, "upbfinyearview", null);
                if (Und == null) return;
                DataRow Curr = DS.proceedspart.Rows[0];
                Curr["idupb"] = Und["idupb"];
                Curr["idfin"] = Und["idfin"];
                decimal amount_needed = CfgFn.GetNoNullDecimal(Und["paymentprevavailable"]) - CfgFn.GetNoNullDecimal(Und["proceedsavailable"]);
                decimal amount_assignable = GetAssignableAmount();
                //sceglie il minimo tra i due
                decimal amount = amount_needed > amount_assignable ? amount_assignable : amount_needed;
                Curr["amount"] = amount;

                Meta.FreshForm(true);
            }


        }

        decimal GetAssignableAmount() {
            DataTable SourceTable = Meta.SourceRow.Table;
            decimal default_amount = CfgFn.GetNoNullDecimal(SourceTable.Columns["amount"].DefaultValue);
            if (Meta.InsertMode) return default_amount;
            decimal original_amount = CfgFn.GetNoNullDecimal(DS.proceedspart.Rows[0]["amount", DataRowVersion.Original]);
            return default_amount + original_amount;
        }

    }
}
